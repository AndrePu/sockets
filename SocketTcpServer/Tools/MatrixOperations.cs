using System.Collections.Generic;

namespace SocketTcpServer.Tools
{
    public class MatrixOperations
    {
        public static List<List<int>> MultiplyMatrices(List<List<int>> mx1, List<List<int>> mx2)
        {
            var res = new List<List<int>>(mx1.Count);

            for (int i = 0; i < mx1.Count; i++)
            {
                res.Add(new List<int>(mx2[0].Count));
                for (int j = 0; j < mx2[0].Count; j++)
                {
                    int sum = 0;
                    for (int z = 0; z < mx2.Count; z++)
                    {
                        sum += mx1[i][z] * mx2[z][j];
                    }
                    res[i].Add(sum);
                }
            }
            return res;
        }

        public static bool CheckMultiplyCondition(List<List<int>> mx1, List<List<int>> mx2)
        {
            if (mx1.Count != mx2.Count)
            {
                return false;
            }

            for (int i = 0; i < mx1.Count; i++)
            {
                if (mx1[i].Count != mx2[i].Count)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
