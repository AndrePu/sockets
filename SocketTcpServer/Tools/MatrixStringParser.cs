using System;
using System.Collections.Generic;
using System.Linq;

namespace SocketTcpServer.Tools
{
    public static class MatrixStringParser
    {
        /// <summary>
        /// Parses matrix presented as string (e.g. [[1,1,1],[1,1,1]])
        /// </summary>
        public static List<List<int>> Parse(string data)
        {
            List<List<int>> res = new List<List<int>>();

            if (!data.StartsWith("[") || !data.EndsWith("]"))
            {
                throw new Exception(data);
            }
            data = data.Substring(1, data.Length - 2);
            string[] rows = data.Split(']');

            for (int i = 0; i < rows.Length - 1; i++)
            {
                string row = rows[i].Trim('[', ',');
                var nums = row.Split(',').Select(num => int.Parse(num)).ToList();
                res.Add(nums);
            }
            return res;
        }
    }
}
