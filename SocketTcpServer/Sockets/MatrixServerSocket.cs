using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text.Json;
using SocketCommon.Interfaces;
using SocketCommon.TransportModel;
using SocketCommon.Models;
using SocketCommon.Logging;
using SocketTcpServer.Tools;
using SocketTcpServer.Models;

namespace SocketTcpServer.Sockets
{
    internal class MatrixServerSocket : IServerSocketType
    {
        const int port = 8005;
        const string ipAddress = "127.0.0.1";
        private readonly IClientSocketType<List<List<int>>, string> dbSocket;
        private readonly ILogger logger;
        private List<List<int>> matrix1;
        private List<List<int>> matrix2;

        public MatrixServerSocket(IClientSocketType<List<List<int>>, string> dbSocket, ILogger logger)
        {
            this.dbSocket = dbSocket;
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

                    string inputInfo = builder.ToString();
                    var tpModel = JsonSerializer.Deserialize<MxMultiplicationInputModel>(inputInfo);
                    logger.Log(inputInfo);
                    var mxResponse1 = dbSocket.GetData(tpModel.MX1Name);
                    var mxResponse2 = dbSocket.GetData(tpModel.MX2Name);
                    var result = new OperationResult<List<List<int>>>();

                    if (mxResponse1.Status == OperationStatus.Ok && mxResponse2.Status == OperationStatus.Ok)
                    {
                        matrix1 = mxResponse1.Data;
                        matrix2 = mxResponse2.Data;

                        if (MatrixOperations.CheckMultiplyCondition(matrix1, matrix2))
                        {
                            List<List<int>> multiRes = MatrixOperations.MultiplyMatrices(matrix1, matrix2);
                            result.Data = CutMatrixBuilder.Build(multiRes, tpModel.RowBegin, tpModel.RowEnd, tpModel.ColBegin, tpModel.ColEnd);
                            result.Status = OperationStatus.Ok;
                        }
                        else
                        {
                            result.Status = OperationStatus.Error;
                            result.Message = Errors.MultiplyConditionFailed;
                        }
                    }
                    else
                    {
                        result.Status = OperationStatus.Error;
                        result.Message = mxResponse1.Status == OperationStatus.Error ? mxResponse1.Message : mxResponse2.Message;
                    }

                    
                    data = Encoding.Unicode.GetBytes(JsonSerializer.Serialize(result));
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
                logger.Log(SocketServiceMessage.socketReloading);
                StartListening();
            }
        }
    }
}
