using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocketTcpDbServer.Models;
using SocketTcpDbServer.Tools;

namespace SocketTcpDbServerTests
{
    [TestClass]
    public class MatrixExistanceCheckerTests
    {
        [DataTestMethod]
        [DataRow("matrix")]
        public void matrixExists(string matrixName)
        {
            var matricesData = new List<Matrix>()
            {
                new Matrix("maytrix", "[[1]]"),
                new Matrix("matrix", "[[0],[0]]")
            };

            bool doesExist = MatrixExistanceChecker.Check(matrixName, matricesData, out string matrixData);

            Assert.IsTrue(doesExist && matrixData != null);
        }

        [DataTestMethod]
        [DataRow("matrix")]
        public void matrixDoesNotExists(string matrixName)
        {
            var matricesData = new List<Matrix>()
            {
                new Matrix("Neo", "0101010010100101010"),
                new Matrix("Morphious", "0000000000110")
            };

            bool doesExist = MatrixExistanceChecker.Check(matrixName, matricesData, out string matrixData);

            Assert.IsTrue(!doesExist && matrixData == null);
        }
    }
}
