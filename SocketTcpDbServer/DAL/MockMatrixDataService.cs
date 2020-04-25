using System.Collections.Generic;
using SocketTcpDbServer.Models;

namespace SocketTcpDbServer.DAL
{
    internal class MockMatrixDataService : IMatrixDataService
    {
        public List<Matrix> GetData()
        {
            var res = new List<Matrix>()
            {
                new Matrix("m3x3_1", "[[3,2,5],[24,1,3],[4,5,2]]"),
                new Matrix("m3x3_2", "[[3,2,1],[4,5,2],[24,1,3]]"),
                new Matrix("m5x5_1", "[[3,2,5,11,4],[24,1,3,3,5],[4,5,2,7,9],[7,3,3,10,3],[3,2,6,8,9]]"),
                new Matrix("m5x5_2", "[[3,2,1,2,1],[4,5,2,7,9],[24,1,3,3,5],[3,2,6,8,9],[7,3,3,10,3]]")
            };

            return res;
        }
    }
}
