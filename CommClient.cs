using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp
{
    public class CommClient : ICommClient
    {
        Socket sender;
        public void connect(string ip, int port)
        {
            IPHostEntry host = Dns.GetHostEntry("localhost");//save local host ip
            IPAddress ipaddress = host.AddressList[1];//save ip address for the socket to use
            IPEndPoint remote_ep = new IPEndPoint(ipaddress, port);//remote server socket
            sender = new Socket(ipaddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);//create client socket
            sender.Connect(remote_ep);//connect the client to the server
        }

        public void disconnect()//close connection and the socket
        {
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }

        public void send(string command)
        {
            if(sender.Send(Encoding.ASCII.GetBytes(command+"\r\n")) < 0){
                throw new Exception(command);
            }
        }
        ~CommClient()
        {
            disconnect();
        }
    }
}
