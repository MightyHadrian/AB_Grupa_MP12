using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProgram;

namespace Testy_AB_MD
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Modulo modulo=new();
            Assert.AreEqual(modulo.Calculate(5), 0);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Modulo modulo = new();
            Assert.AreEqual(modulo.Calculate(2), 1);
        }
    }
}