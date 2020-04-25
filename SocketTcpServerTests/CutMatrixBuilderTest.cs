using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SocketTcpServer.Tools;
using Tests.Helpers;

namespace Tests
{
    [TestClass]
    public class CutMatrixBuilderTest
    {
        [TestMethod]
        public void MX3x3Text()
        {
            var list = new List<List<int>>()
            {
                new List<int>() { 3, 2, 5 },
                new List<int>() { 24, 1, 3 },
                new List<int>() { 4, 5, 2 }
            };

            var expected = new List<List<int>>()
            {
                new List<int>() { 1, 3 },
                new List<int>() { 5, 2 }
            };

            var res = CutMatrixBuilder.Build(list, 2, 3, 2, 3);
            Assert.IsTrue(TwoDimensionalListsComparator.Compare(res, expected));
        }
    }
}
