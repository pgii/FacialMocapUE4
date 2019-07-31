using System.Collections.Generic;
using System.Drawing;
using Point = DlibDotNet.Point;

public class FacialBlendShapeController
{
    private int[] bottomJawPoint = new[] {8, 30};
    private int[] mouthCornerLeftPoint = new[] { 54, 30 };
    private int[] mouthCornerRightPoint = new[] { 48, 30 };
    private int[] browLeftPoint = new[] { 24, 30 };
    private int[] browRightPoint = new[] { 19, 30 };
    private int[] eyeBlinkLeftPoint = new[] { 43, 47 };
    private int[] eyeBlinkRightPoint = new[] { 38, 40 };

    private PointF bottomJawNormalOffset;
    private PointF bottomJawOffset;

    private PointF mouthCornerLeftNormalOffset;
    private PointF mouthCornerLeftOffset;

    private PointF mouthCornerRightNormalOffset;
    private PointF mouthCornerRightOffset;

    private PointF browLeftNormalOffset;
    private PointF browLeftOffset;

    private PointF browRightNormalOffset;
    private PointF browRightOffset;

    private PointF eyeBlinkLeftNormalOffset;
    private PointF eyeBlinkLeftOffset;

    private PointF eyeBlinkRightNormalOffset;
    private PointF eyeBlinkRightOffset;

    public void InitNormalOffset(List<Point> points)
    {
        bottomJawNormalOffset = new PointF(points[bottomJawPoint[0]].X - points[bottomJawPoint[1]].X, points[bottomJawPoint[0]].Y - points[bottomJawPoint[1]].Y);

        mouthCornerLeftNormalOffset = new PointF(points[mouthCornerLeftPoint[0]].X - points[mouthCornerLeftPoint[1]].X, points[mouthCornerLeftPoint[0]].Y - points[mouthCornerLeftPoint[1]].Y);
        mouthCornerRightNormalOffset = new PointF(points[mouthCornerRightPoint[1]].X - points[mouthCornerRightPoint[0]].X, points[mouthCornerRightPoint[0]].Y - points[mouthCornerRightPoint[1]].Y);

        browLeftNormalOffset = new PointF(points[browLeftPoint[0]].X - points[browLeftPoint[1]].X, points[browLeftPoint[0]].Y - points[browLeftPoint[1]].Y);
        browRightNormalOffset = new PointF(points[browRightPoint[1]].X - points[browRightPoint[0]].X, points[browRightPoint[0]].Y - points[browRightPoint[1]].Y);

        eyeBlinkLeftNormalOffset = new PointF(points[eyeBlinkLeftPoint[0]].X - points[eyeBlinkLeftPoint[1]].X, points[eyeBlinkLeftPoint[0]].Y - points[eyeBlinkLeftPoint[1]].Y);
        eyeBlinkRightNormalOffset = new PointF(points[eyeBlinkRightPoint[1]].X - points[eyeBlinkRightPoint[0]].X, points[eyeBlinkRightPoint[0]].Y - points[eyeBlinkRightPoint[1]].Y);
    }

    public void SetBottomJawOffset(List<Point> points)
    {
        bottomJawOffset = new PointF(points[bottomJawPoint[0]].X - points[bottomJawPoint[1]].X, points[bottomJawPoint[0]].Y - points[bottomJawPoint[1]].Y);
    }

    public PointF GetBottomJawPosition(List<Point> points)
    {
        PointF diff = new PointF(points[bottomJawPoint[0]].X - points[bottomJawPoint[1]].X, points[bottomJawPoint[0]].Y - points[bottomJawPoint[1]].Y);
        float resultX = (diff.X - bottomJawNormalOffset.X) / (bottomJawOffset.X - bottomJawNormalOffset.X);
        float resultY = (diff.Y - bottomJawNormalOffset.Y) / (bottomJawOffset.Y - bottomJawNormalOffset.Y);

        if (float.IsInfinity(resultX))
            resultX = 0;
        if (float.IsInfinity(resultY))
            resultY = 0;

        resultX = ClampNegPos(resultX);
        resultY = ClampNegPos(resultY);

        return new PointF(resultX, resultY);
    }

    public void SetSmileOffset(List<Point> points)
    {
        mouthCornerLeftOffset = new PointF(points[mouthCornerLeftPoint[0]].X - points[mouthCornerLeftPoint[1]].X, points[mouthCornerLeftPoint[0]].Y - points[mouthCornerLeftPoint[1]].Y);
        mouthCornerRightOffset = new PointF(points[mouthCornerRightPoint[1]].X - points[mouthCornerRightPoint[0]].X, points[mouthCornerRightPoint[0]].Y - points[mouthCornerRightPoint[1]].Y);
    }

    public PointF GetMouthCornerLeftPosition(List<Point> points)
    {
        PointF diff = new PointF(points[mouthCornerLeftPoint[0]].X - points[mouthCornerLeftPoint[1]].X, points[mouthCornerLeftPoint[0]].Y - points[mouthCornerLeftPoint[1]].Y);
        float resultX = (diff.X - mouthCornerLeftNormalOffset.X) / (mouthCornerLeftOffset.X - mouthCornerLeftNormalOffset.X);
        float resultY = (diff.Y - mouthCornerLeftNormalOffset.Y) / (mouthCornerLeftOffset.Y - mouthCornerLeftNormalOffset.Y);

        if (float.IsInfinity(resultX))
            resultX = 0;
        if (float.IsInfinity(resultY))
            resultY = 0;

        resultX = ClampNegPos(resultX);
        resultY = ClampNegPos(resultY);

        return new PointF(resultX, resultY);
    }

    public PointF GetMouthCornerRightPosition(List<Point> points)
    {
        PointF diff = new PointF(points[mouthCornerRightPoint[1]].X - points[mouthCornerRightPoint[0]].X, points[mouthCornerRightPoint[0]].Y - points[mouthCornerRightPoint[1]].Y);
        float resultX = (diff.X - mouthCornerRightNormalOffset.X) / (mouthCornerRightOffset.X - mouthCornerRightNormalOffset.X);
        float resultY = (diff.Y - mouthCornerRightNormalOffset.Y) / (mouthCornerRightOffset.Y - mouthCornerRightNormalOffset.Y);

        if (float.IsInfinity(resultX))
            resultX = 0;
        if (float.IsInfinity(resultY))
            resultY = 0;

        resultX = ClampNegPos(resultX);
        resultY = ClampNegPos(resultY);

        return new PointF(resultX, resultY);
    }

    public void SetBrowUpOffset(List<Point> points)
    {
        browLeftOffset = new PointF(points[browLeftPoint[0]].X - points[browLeftPoint[1]].X, points[browLeftPoint[0]].Y - points[browLeftPoint[1]].Y);
        browRightOffset = new PointF(points[browRightPoint[1]].X - points[browRightPoint[0]].X, points[browRightPoint[0]].Y - points[browRightPoint[1]].Y);
    }

    public PointF GetBrowLeftPosition(List<Point> points)
    {
        PointF diff = new PointF(points[browLeftPoint[0]].X - points[browLeftPoint[1]].X, points[browLeftPoint[0]].Y - points[browLeftPoint[1]].Y);
        float resultX = (diff.X - browLeftNormalOffset.X) / (browLeftOffset.X - browLeftNormalOffset.X);
        float resultY = (diff.Y - browLeftNormalOffset.Y) / (browLeftOffset.Y - browLeftNormalOffset.Y);

        if (float.IsInfinity(resultX))
            resultX = 0;
        if (float.IsInfinity(resultY))
            resultY = 0;

        resultX = ClampNegPos(resultX);
        resultY = ClampNegPos(resultY);

        return new PointF(resultX, resultY);
    }

    public PointF GetBrowRightPosition(List<Point> points)
    {
        PointF diff = new PointF(points[browRightPoint[1]].X - points[browRightPoint[0]].X, points[browRightPoint[0]].Y - points[browRightPoint[1]].Y);
        float resultX = (diff.X - browRightNormalOffset.X) / (browRightOffset.X - browRightNormalOffset.X);
        float resultY = (diff.Y - browRightNormalOffset.Y) / (browRightOffset.Y - browRightNormalOffset.Y);

        if (float.IsInfinity(resultX))
            resultX = 0;
        if (float.IsInfinity(resultY))
            resultY = 0;

        resultX = ClampNegPos(resultX);
        resultY = ClampNegPos(resultY);

        return new PointF(resultX, resultY);
    }


    public void SetEyeBlinkLeftOffset(List<Point> points)
    {
        eyeBlinkLeftOffset = new PointF(points[eyeBlinkLeftPoint[0]].X - points[eyeBlinkLeftPoint[1]].X, points[eyeBlinkLeftPoint[0]].Y - points[eyeBlinkLeftPoint[1]].Y);
    }

    public void SetEyeBlinkRightOffset(List<Point> points)
    {
        eyeBlinkRightOffset = new PointF(points[eyeBlinkRightPoint[1]].X - points[eyeBlinkRightPoint[0]].X, points[eyeBlinkRightPoint[0]].Y - points[eyeBlinkRightPoint[1]].Y);
    }

    public PointF GetEyeBlinkLeftPosition(List<Point> points)
    {
        PointF diff = new PointF(points[eyeBlinkLeftPoint[0]].X - points[eyeBlinkLeftPoint[1]].X, points[eyeBlinkLeftPoint[0]].Y - points[eyeBlinkLeftPoint[1]].Y);
        float resultX = (diff.X - eyeBlinkLeftNormalOffset.X) / (eyeBlinkLeftOffset.X - eyeBlinkLeftNormalOffset.X);
        float resultY = (diff.Y - eyeBlinkLeftNormalOffset.Y) / (eyeBlinkLeftOffset.Y - eyeBlinkLeftNormalOffset.Y);

        if (float.IsInfinity(resultX))
            resultX = 0;
        if (float.IsInfinity(resultY))
            resultY = 0;

        resultX = ClampNegPos(resultX);
        resultY = ClampNegPos(resultY);

        return new PointF(resultX, resultY);
    }

    public PointF GetEyeBlinkRightPosition(List<Point> points)
    {
        PointF diff = new PointF(points[eyeBlinkRightPoint[1]].X - points[eyeBlinkRightPoint[0]].X, points[eyeBlinkRightPoint[0]].Y - points[eyeBlinkRightPoint[1]].Y);
        float resultX = (diff.X - eyeBlinkRightNormalOffset.X) / (eyeBlinkRightOffset.X - eyeBlinkRightNormalOffset.X);
        float resultY = (diff.Y - eyeBlinkRightNormalOffset.Y) / (eyeBlinkRightOffset.Y - eyeBlinkRightNormalOffset.Y);

        if (float.IsInfinity(resultX))
            resultX = 0;
        if (float.IsInfinity(resultY))
            resultY = 0;

        resultX = ClampNegPos(resultX);
        resultY = ClampNegPos(resultY);

        return new PointF(resultX, resultY);
    }

    public static float ClampNegPos(float value)
    {
        if (value > 1F)
            return 1F;
        else if(value < -1F)
            return -1F;
        else
            return value;
    }
}

