using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dane;
using Moq;

namespace DaneTest
{
    [TestClass]
    public class AbstractClassDataTests
    {
        [TestMethod]
        public void ID_MockTest()
        {
            var mockObject = new Mock<Data>();
            var resultMock = mockObject.Object;

            Assert.AreEqual(resultMock.objectID, 0);
        }

        [TestMethod]
        public void X_MockTest()
        {
            var mockObject = new Mock<Data>();
            mockObject.Setup(obj => obj.objectX).Returns(1);
            var resultMock = mockObject.Object;

            Assert.AreEqual(resultMock.objectX, 1);
        }

        [TestMethod]
        public void Y_MockTest()
        {
            var mockObject = new Mock<Data>();
            mockObject.Setup(obj => obj.objectY).Returns(1);
            var resultMock = mockObject.Object;

            Assert.AreEqual(resultMock.objectY, 1);
        }

        [TestMethod]
        public void Velocity_MockTest()
        {
            var mockObject = new Mock<Data>();
            mockObject.Setup(obj => obj.objectVelocity).Returns(1.0);
            var resultMock = mockObject.Object;

            Assert.AreEqual(resultMock.objectVelocity, 1.0);
        }

        [TestMethod]
        public void Mass_MockTest()
        {
            var mockObject = new Mock<Data>();
            mockObject.Setup(obj => obj.objectMass).Returns(1.0);
            var resultMock = mockObject.Object;

            Assert.AreEqual(resultMock.objectMass, 1.0);
        }
    }

    [TestClass]
    public class BallClassDataTests
    {
        [TestMethod]
        public void ID_Test()
        {
            Ball resultBall = new(1, 1, 1, 1.0, 1.0);

            Assert.AreEqual(resultBall.objectID, 1);
        }

        [TestMethod]
        public void X_Test()
        {
            Ball resultBall = new(1, 1, 1, 1.0, 1.0);
            Assert.AreEqual(resultBall.objectX, 1);

            resultBall.objectX = 2;

            Assert.AreEqual(resultBall.objectX, 2);
        }

        [TestMethod]
        public void Y_Test()
        {
            Ball resultBall = new(1, 1, 1, 1.0, 1.0);
            Assert.AreEqual(resultBall.objectY, 1);

            resultBall.objectY = 2;

            Assert.AreEqual(resultBall.objectY, 2);
        }

        [TestMethod]
        public void Velocity_Test()
        {
            Ball resultBall = new(1, 1, 1, 1.0, 1.0);
            Assert.AreEqual(resultBall.objectVelocity, 1.0);

            resultBall.objectVelocity = 0.5;

            Assert.AreEqual(resultBall.objectVelocity, 0.5);
        }

        [TestMethod]
        public void Mass_Test()
        {
            Ball resultBall = new(1, 1, 1, 1.0, 1.0);

            Assert.AreEqual(resultBall.objectMass, 1.0);
        }
    }
}