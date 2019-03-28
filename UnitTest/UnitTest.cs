using Microsoft.VisualStudio.TestTools.UnitTesting;
using DIP.Public;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void AddTest()
        {
            string str = "abcdefg.bmp";
            string tp = COMUtil.getType(str);

            Assert.AreEqual(tp, "bmp");
        }
        
    }
}
