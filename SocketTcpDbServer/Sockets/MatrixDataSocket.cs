using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Net;
using System.Net.Sockets;
using SocketCommon.Logging;
using SocketCommon.Models;
using SocketCommon.Interfaces;
using SocketCommon.TransportModel;
using SocketTcpDbServer.Models;
using SocketTcpDbServer.Tools;

namespace SocketTcpDbServer.Sockets
{
    internal class MatrixDataSocket : IServerSocketType
    {
        const int port = 8004;
        const string ipAddress = "127.0.0.1";
        private readonly List<Matrix> matricesData;
        private readonly ILogger logger;

        public MatrixDataSocket(List<Matrix> matricesData, ILogger logger)
        {
            this.matricesData = matricesData;
            this.logger = logger;
        }

        public void StartListening()
        {
            var ipPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Socket handler = null;

            try
            {
                listenSocket.Bind(ipPoint);
                listenSocket.Listen(10);
                logger.Log(SocketServiceMessage.socketStartListening);

                while (true)
                {
                    handler = listenSocket.Accept();
                    var builder = new StringBuilder();
                    int bytes = 0;
                    byte[] data = new byte[256];

                    do
                    {
                        bytes = handler.Receive(data);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (handler.Available > 0);

                    string matrixName = builder.ToString();
                    logger.Log(matrixName);
                    var result = new OperationResult<string>();

                    if (MatrixExistanceChecker.Check(matrixName, matricesData, out string matrixData))
                    {
                        result.Status = OperationStatus.Ok;
                        result.Data = matrixData;
                    }
                    else
                    {
                        result.Status = OperationStatus.Error;
                        result.Message = Errors.WrongMatrixNameError;
                    }

                    string json = JsonSerializer.Serialize(result);
                    data = Encoding.Unicode.GetBytes(json);
                    handler.Send(data);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                handler?.Shutdown(SocketShutdown.Both);
                listenSocket.Close();
                logger.Error(SocketServiceMessage.socketReloading);
                StartListening();
            }
        }
    }
}
