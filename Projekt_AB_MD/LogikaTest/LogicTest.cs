using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logika;

namespace LogikaTest
{
    [TestClass]
    public class MainLogicFunctions
    {
        [TestMethod]
        public void addBallTest()
        {
            Logic logic = new();
            logic.addBall();

            Assert.IsFalse(logic.getListStatus());

            Assert.AreEqual(logic.getObjectID(0), 1);

            Assert.IsTrue(logic.getObjectX(0) != 0);

            Assert.IsTrue(logic.getObjectY(0) != 0);

            Assert.IsTrue(logic.getObjectVelocity(0) != 0);
        }

        [TestMethod]
        public void delBallTest()
        {
            Logic logic = new();
            logic.addBall();

            Assert.IsFalse(logic.getListStatus());

            logic.delBall(0);

            Assert.IsTrue(logic.getListStatus());
        }

        [TestMethod]
        public void resetBallTest()
        {
            Logic logic = new();
            logic.addBall();

            Assert.IsFalse(logic.getListStatus());

            logic.resetBalls();

            Assert.IsFalse(logic.getListStatus());
        }

        [TestMethod]
        public void calcKinEnergyBallTest()
        {
            Logic logic = new();
            logic.addBall();

            Assert.IsFalse(logic.getListStatus());

            Assert.IsTrue(logic.calcKinEnergy(logic.getObjectVelocity(0), logic.getObjectMass(0)) != 0.0);
        }
    }

    [TestClass]
    public class GetSetLogicFunctions
    {
        [TestMethod]
        public void getIDTest()
        {
            Logic logic = new();
            logic.addBall();

            Assert.AreEqual(logic.getObjectID(0), 1);
        }

        [TestMethod]
        public void getSetXTest()
        {
            Logic logic = new();
            logic.addBall();

            Assert.IsTrue(logic.getObjectX(0) != 0);

            logic.setObjectX(0, 100);
            Assert.AreEqual(logic.getObjectX(0), 100);
        }

        [TestMethod]
        public void getSetYTest()
        {
            Logic logic = new();
            logic.addBall();

            Assert.IsTrue(logic.getObjectY(0) != 0);

            logic.setObjectY(0, 100);
            Assert.AreEqual(logic.getObjectY(0), 100);
        }

        [TestMethod]
        public void getVelocityTest()
        {
            Logic logic = new();
            logic.addBall();

            Assert.IsTrue(logic.getObjectVelocity(0) != 0);
        }

        [TestMethod]
        public void getMassTest()
        {
            Logic logic = new();
            logic.addBall();

            Assert.IsTrue(logic.getObjectMass(0) != 0);
        }
    }
}