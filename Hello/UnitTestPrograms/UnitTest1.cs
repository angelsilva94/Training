using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using threeN.Validator;
using Models;

namespace UnitTestPrograms {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1() {
            Validator val = new Validator(100, 40);
            ErrorDispose er = new ErrorDispose();
            Assert.IsFalse(val.Val(out er));
        }
    }
}
