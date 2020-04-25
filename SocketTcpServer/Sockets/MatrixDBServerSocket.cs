using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Net;
using System.Net.Sockets;
using SocketCommon.Interfaces;
using SocketCommon.Logging;
using SocketCommon.Models;
using SocketTcpServer.Tools;
using SocketCommon.TransportModel;

namespace SocketTcpServer.Sockets
{
    internal class MatrixDBServerSocket : IClientSocketType<List<List<int>>, string>
    {
        const int port = 8004;
        const string ipAddress = "127.0.0.1";
        private readonly ILogger logger;

        public MatrixDBServerSocket(ILogger logger)
        {
            this.logger = logger;
        }

        public OperationResult<List<List<int>>> GetData(string matrixName)
        {
            var result = new OperationResult<List<List<int>>>();

            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipPoint);
                byte[] data = Encoding.Unicode.GetBytes(matrixName);
                socket.Send(data);
                logger.Log(SocketServiceMessage.socketSuccessfullyConnected);
                data = new byte[256];
                StringBuilder builder = new StringBuilder();
                int bytes = 0;

                do
                {
                    bytes = socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (socket.Available > 0);
                string receivedData = builder.ToString();
                logger.Log(receivedData);
                var response = JsonSerializer.Deserialize<OperationResult<string>>(receivedData);

                if (response.Status == OperationStatus.Ok)
                {
                    result.Status = OperationStatus.Ok;
                    result.Data = MatrixStringParser.Parse(response.Data);
                }
                else
                {
                    result.Status = OperationStatus.Error;
                    result.Message = response.Message;
                }
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
