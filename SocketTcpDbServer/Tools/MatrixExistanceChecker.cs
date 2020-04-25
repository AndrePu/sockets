using System.Collections.Generic;
using SocketTcpDbServer.Models;

namespace SocketTcpDbServer.Tools
{
    public class MatrixExistanceChecker
    {
        public static bool Check(string matrixName, List<Matrix> matricesData, out string matrixData)
        {
            bool res = false;
            matrixData = null;
            foreach (var matrix in matricesData)
            {
                if (matrixName == matrix.Name)
                {
                    matrixData = matrix.Data;
                    res = true;
                    break;
                }
            }
            return res;
        }
    }
}
