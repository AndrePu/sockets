using SocketTcpServer.Sockets;
using SocketCommon.Logging;

namespace SocketTcpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            var dbSocket = new MatrixDBServerSocket(logger);
            var socket = new MatrixServerSocket(dbSocket, logger);
            socket.StartListening();
        }
    }
}
