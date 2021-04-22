using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp
{
    public interface ICommClient
    {
        void connect(string ip, int port);
        void send(string command);
        void disconnect();
    }
}
