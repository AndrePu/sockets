using System.Collections.Generic;
using SocketTcpDbServer.Models;

namespace SocketTcpDbServer.DAL
{
    internal interface IMatrixDataService
    {
        List<Matrix> GetData();
    }
}
