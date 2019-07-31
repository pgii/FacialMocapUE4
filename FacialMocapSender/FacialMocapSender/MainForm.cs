using DlibDotNet;
using DlibDotNet.Extensions;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static UDPSocket;
using Dlib = DlibDotNet.Dlib;
using Point = DlibDotNet.Point;

namespace FacialMocapSender
{
    public partial class MainForm : Form
    {
        private ShapePredictor poseModel = ShapePredictor.Deserialize(Application.StartupPath + "\\shape_predictor_68_face_landmarks.dat");
        private FrontalFaceDetector detector = Dlib.GetFrontalFaceDetector();
        
        private VideoCapture _capture;

        FacialBlendShapeController facialBlendShapeController = new FacialBlendShapeController();

        List<Point> landmarkPoint = new List<Point>(68);

        UDPSocket udpSocket = new UDPSocket();
        public State state = new State();

        public MainForm()
        {
            InitializeComponent();

            udpSocket.Client("127.0.0.1", 7755);

            _capture = new VideoCapture(0);
            _capture.SetCaptureProperty(CapProp.FrameWidth, 800);
            _capture.SetCaptureProperty(CapProp.FrameHeight, 600);
            _capture.ImageGrabbed += ProcessFrame;

            if (_capture != null)
            {
                try
                {
                    _capture.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void UdpSendMessage(string text)
        {
            udpSocket.Send(text);
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            Stopwatch SW = new Stopwatch();
            SW.Start();

            try
            {
                Mat temp = new Mat();
                _capture.Read(temp);

                var array = new byte[temp.Width * temp.Height * temp.ElementSize];
                temp.CopyTo(array);

                Array2D<RgbPixel> cimg = Dlib.LoadImageData<RgbPixel>(array, (uint) temp.Height, (uint) temp.Width, (uint) (temp.Width * temp.ElementSize));

                Rectangle[] faces = detector.Operator(cimg); 

                if (faces.Any())
                {
                    FullObjectDetection det = poseModel.Detect(cimg, faces[0]);
                    List<FullObjectDetection> shapes = new List<FullObjectDetection>();
                    shapes.Add(det);
                    FullObjectDetection shape = shapes[0];
                    ImageWindow.OverlayLine[] lines = Dlib.RenderFaceDetections(shapes);

                    if (chbShowLineOnly.Checked)
                        cimg = new Array2D<RgbPixel>(cimg.Rows, cimg.Columns);

                    foreach (var line in lines)
                        Dlib.DrawLine(cimg, line.Point1, line.Point2, new RgbPixel { Green = 255 });

                    pictureBoxImage.Image?.Dispose();
                    pictureBoxImage.Image = cimg.ToBitmap();

                    foreach (var line in lines)
                        line.Dispose();

                    for (uint i = 0; i < shape.Parts; i++)
                        landmarkPoint.Insert((int)i, new Point(shape.GetPart(i).X, shape.GetPart(i).Y));

                    GetFacialBlendShape();

                    foreach (var s in shapes)
                        s.Dispose();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
            }

            SW.Stop();
            Debug.WriteLine(string.Format("FPS: {0}", 1000 / SW.ElapsedMilliseconds));
        }

        public async void GetFacialBlendShape()
        {
            await Task.Run(() =>
            {
                float mouthOpen = facialBlendShapeController.GetBottomJawPosition(landmarkPoint).Y;
                float mouthTight = 0;

                if (mouthOpen < 0)
                {
                    mouthTight = Math.Abs(mouthOpen);
                    mouthOpen = 0;
                }

                float mouthSmileLeft = facialBlendShapeController.GetMouthCornerLeftPosition(landmarkPoint).X;
                float mouthNarrowLeft = 0;

                if (mouthSmileLeft < 0)
                {
                    mouthNarrowLeft = Math.Abs(mouthSmileLeft);
                    mouthSmileLeft = 0;
                }

                float mouthSmileRight = facialBlendShapeController.GetMouthCornerRightPosition(landmarkPoint).X;
                float mouthNarrowRight = 0;

                if (mouthSmileRight < 0)
                {
                    mouthNarrowRight = Math.Abs(mouthSmileRight);
                    mouthSmileRight = 0;
                }

                float browUpLeft = facialBlendShapeController.GetBrowLeftPosition(landmarkPoint).Y;
                float browUpRight = facialBlendShapeController.GetBrowRightPosition(landmarkPoint).Y;

                float eyeBlinkLeft = facialBlendShapeController.GetEyeBlinkLeftPosition(landmarkPoint).Y;
                if (eyeBlinkLeft < 0.75)
                    eyeBlinkLeft = 0;
                else
                    eyeBlinkLeft = 1;

                float eyeBlinkRight = facialBlendShapeController.GetEyeBlinkRightPosition(landmarkPoint).Y;
                if (eyeBlinkRight < 0.75)
                    eyeBlinkRight = 0;
                else
                    eyeBlinkRight = 1;

                FacialDataModel facialDataModel = new FacialDataModel();
                facialDataModel.type = "facialData";
                facialDataModel.mouthOpen = mouthOpen.ToString("N2", CultureInfo.InvariantCulture);
                facialDataModel.mouthTight = mouthTight.ToString("N2", CultureInfo.InvariantCulture);
                facialDataModel.mouthSmileLeft = mouthSmileLeft.ToString("N2", CultureInfo.InvariantCulture);
                facialDataModel.mouthSmileRight = mouthSmileRight.ToString("N2", CultureInfo.InvariantCulture);
                facialDataModel.mouthNarrowLeft = mouthNarrowLeft.ToString("N2", CultureInfo.InvariantCulture);
                facialDataModel.mouthNarrowRight = mouthNarrowRight.ToString("N2", CultureInfo.InvariantCulture);
                facialDataModel.browUpLeft = browUpLeft.ToString("N2", CultureInfo.InvariantCulture);
                facialDataModel.browUpRight = browUpRight.ToString("N2", CultureInfo.InvariantCulture);
                facialDataModel.eyeBlinkLeft = eyeBlinkLeft.ToString("N2", CultureInfo.InvariantCulture);
                facialDataModel.eyeBlinkRight = eyeBlinkRight.ToString("N2", CultureInfo.InvariantCulture);

                string jsonString = JsonConvert.SerializeObject(facialDataModel);

                UdpSendMessage(jsonString);

                Debug.WriteLine(string.Format("mouthOpen: {0} mouthTight: {1}", mouthOpen.ToString("N1"), mouthTight.ToString("N1")));
                Debug.WriteLine(string.Format("mouthSmileLeft: {0} mouthSmileRight: {1}", mouthSmileLeft.ToString("N1"), mouthSmileRight.ToString("N1")));
                Debug.WriteLine(string.Format("mouthNarrowLeft: {0} mouthNarrowRight: {1}", mouthNarrowLeft.ToString("N1"), mouthNarrowRight.ToString("N1")));
                Debug.WriteLine(string.Format("browUpLeft: {0} browUpRight: {1}", browUpLeft.ToString("N1"), browUpRight.ToString("N1")));
                Debug.WriteLine(string.Format("eyeBlinkLeft: {0} eyeBlinkRight: {1}", eyeBlinkLeft.ToString("N1"), eyeBlinkRight.ToString("N1")));
            });
        }
        
        private void btnMouthNormalCalib_Click(object sender, EventArgs e)
        {
            facialBlendShapeController.InitNormalOffset(landmarkPoint);
        }

        private void btnMouthOpenCalib_Click(object sender, EventArgs e)
        {
            facialBlendShapeController.SetBottomJawOffset(landmarkPoint);
        }

        private void btnMouthSmileCalib_Click(object sender, EventArgs e)
        {
            facialBlendShapeController.SetSmileOffset(landmarkPoint);
        }

        private void btnBrowUpCalib_Click(object sender, EventArgs e)
        {
            facialBlendShapeController.SetBrowUpOffset(landmarkPoint);
        }

        private void btnEyeBlinkLeft_Click(object sender, EventArgs e)
        {
            facialBlendShapeController.SetEyeBlinkLeftOffset(landmarkPoint);
        }

        private void btnEyeBlinkRight_Click(object sender, EventArgs e)
        {
            facialBlendShapeController.SetEyeBlinkRightOffset(landmarkPoint);
        }
    }
}
