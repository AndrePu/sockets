using SocketCommon.Logging;
using SocketTcpDbServer.DAL;
using SocketTcpDbServer.Sockets;

namespace SocketTcpDbServer
{
    class Program
    {
        static void Main(string[] args)
        {
            IMatrixDataService dataService = new MockMatrixDataService();
            ILogger logger = new ConsoleLogger();
            var socket = new MatrixDataSocket(dataService.GetData(), logger);
            socket.StartListening();
        }
    }
}
