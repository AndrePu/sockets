using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SocketTcpServer.Tools;
using Tests.Helpers;

namespace Tests
{
    [TestClass]
    public class MatrixStringParserTest
    {
        [DataTestMethod]
        [DataRow("[[3,2,5],[24,1,3],[4,5,2]]")]
        public void MX3x3Test(string data)
        {
            var listToCompare = new List<List<int>>()
            {
                new List<int>() { 3, 2, 5 },
                new List<int>() { 24, 1, 3 },
                new List<int>() { 4, 5, 2 }
            };
            var res = MatrixStringParser.Parse(data);
            Assert.IsTrue(TwoDimensionalListsComparator.Compare(res, listToCompare));
        }
    }
}
