using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class UDPSocket
{
    public Socket _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
    public State state = new State();
    public EndPoint epFrom = new IPEndPoint(IPAddress.Any, 0);
    public AsyncCallback recv = null;

    public class State
    {
        public byte[] buffer = new byte[8192];
    }

    public void Client(string address, int port)
    {
        _socket.Connect(IPAddress.Parse(address), port);
    }

    public void Send(string text)
    {
        byte[] data = Encoding.ASCII.GetBytes(text);
        _socket.BeginSend(data, 0, data.Length, SocketFlags.None, (ar) =>
        {
            State so = (State)ar.AsyncState;
            int bytes = _socket.EndSend(ar);
        }, state);
    }

}