using System;
using System.Text;
using System.Text.Json;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using SocketCommon.TransportModel;
using SocketCommon.Interfaces;
using SocketCommon.Models;
using SocketCommon.Logging;

namespace DesktopClient.Sockets
{
    public class MatrixClientSocket : IClientSocketType<List<List<int>>, MxMultiplicationInputModel>
    {
        const int port = 8005;
        const string address = "127.0.0.1";
        private readonly ILogger logger;

        public MatrixClientSocket(ILogger logger)
        {
            this.logger = logger;
        }

        public OperationResult<List<List<int>>> GetData(MxMultiplicationInputModel inputModel)
        {
            OperationResult<List<List<int>>> result;

            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipPoint);
                string message = JsonSerializer.Serialize(inputModel);
                byte[] data = Encoding.Unicode.GetBytes(message);
                socket.Send(data);
                data = new byte[256];
                StringBuilder builder = new StringBuilder();
                int bytes = 0;

                do
                {
                    bytes = socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (socket.Available > 0);

                string answer = builder.ToString();
                result = JsonSerializer.Deserialize<OperationResult<List<List<int>>>>(answer);
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }

            return result;
        }
    }
}
