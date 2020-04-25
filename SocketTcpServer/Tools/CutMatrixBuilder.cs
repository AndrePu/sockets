using System.Collections.Generic;

namespace SocketTcpServer.Tools
{
    public class CutMatrixBuilder
    {
        public static List<List<int>> Build(List<List<int>> list, int rowBegin, int rowEnd, int colBegin, int colEnd)
        {
            List<List<int>> res = new List<List<int>>(rowEnd - rowBegin + 1);
            for (int i = rowBegin - 1; i < rowEnd; i++)
            {
                res.Add(new List<int>(colEnd - colBegin + 1));
                for (int j = colBegin - 1; j < colEnd; j++)
                {
                    int row = i - rowBegin + 1;
                    res[row].Add(list[i][j]);
                }
            }
            return res;
        }
    }
}
