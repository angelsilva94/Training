using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace tests {
    [TestClass]
    public class SimpleTest {
        [TestMethod]
        public void Test() {
            Assert.AreEqual("a", "a", "same");
        }
    }
}