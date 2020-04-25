using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SocketTcpServer.Tools;
using Tests.Helpers;

namespace Tests
{
    [TestClass]
    public class MatrixOperationsTest
    {
        [TestMethod]
        public void MX3x3Test()
        {
            var mx1 = new List<List<int>>()
            {
                new List<int>() { 3, 2, 5 },
                new List<int>() { 24, 1, 3 },
                new List<int>() { 4, 5, 2 }
            };

            var mx2 = new List<List<int>>()
            {
                new List<int>() { 1, 2, 3 },
                new List<int>() { 4, 10, 2 },
                new List<int>() { 2, 1, 4 }
            };

            var expected = new List<List<int>>()
            {
                new List<int>() { 21, 31, 33 },
                new List<int>() { 34, 61, 86 },
                new List<int>() { 28, 60, 30 }
            };

            var res = MatrixOperations.MultiplyMatrices(mx1, mx2);
            Assert.IsTrue(TwoDimensionalListsComparator.Compare(res, expected));

        }

        [TestMethod]
        public void MultiplyConditionTrue()
        {
            var mx1 = new List<List<int>>()
            {
                new List<int>() { 3, 2, 5 },
                new List<int>() { 24, 1, 3 },
                new List<int>() { 4, 5, 2 }
            };

            var mx2 = new List<List<int>>()
            {
                new List<int>() { 1, 2, 3 },
                new List<int>() { 4, 10, 2 },
                new List<int>() { 2, 1, 4 }
            };

            Assert.IsTrue(MatrixOperations.CheckMultiplyCondition(mx1, mx2));
        }

        [TestMethod]
        public void MultiplyConditionFalse()
        {
            var mx1 = new List<List<int>>()
            {
                new List<int>() { 3, 2, 5 },
                new List<int>() { 24, 1, 3 }
            };

            var mx2 = new List<List<int>>()
            {
                new List<int>() { 1, 2, 3 },
                new List<int>() { 4, 10, 2 },
                new List<int>() { 2, 1, 4 }
            };

            Assert.IsFalse(MatrixOperations.CheckMultiplyCondition(mx1, mx2));
        }
    }
}
