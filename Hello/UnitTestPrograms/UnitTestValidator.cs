using System;
using threeN.Validator;
using Models;
using BlocksProblem;
using threeN.Process;
using Moq;
using NUnit.Framework;

namespace UnitTestPrograms {
    [TestFixture]

    public class UnitTestValidator {
        [Test]
        public void TestMethodValidatorITrue() {
            int fisrtP = 10;
            int secondP = 100;
            Validator val = new Validator(fisrtP, secondP);
            ErrorDispose er = new ErrorDispose();
            Assert.IsTrue(val.Val(out er),"i es menor a 0");
        }
        [Test]
        public void TestMethodValidatorIFalse() {
            int fisrtP = 12000;
            int secondP = 200;
            Validator val = new Validator(fisrtP, secondP);
            ErrorDispose er = new ErrorDispose();
            Assert.IsFalse(val.Val(out er), "se comprueba la condicion de i < 10k");
        }
        [Test]
        public void TestMethodValidatorJTrue() {
            int fisrtP = 100;
            int secondP = 200;
            Validator val = new Validator(fisrtP, secondP);
            ErrorDispose er = new ErrorDispose();
            Assert.IsTrue(val.Val(out er), "j es menor a 0");

        }
        [Test]
        public void TestMethodValidatorJFalse() {
            int fisrtP = 150;
            int secondP = 200000;
            Validator val = new Validator(fisrtP, secondP);
            ErrorDispose er = new ErrorDispose();
            Assert.IsFalse(val.Val(out er), "se comprueba la condicion de j < 10k");
        }
        [Test]
        public void TestValidatorMock() {
            ErrorDispose er = new ErrorDispose();
            Mock<Validator> validator = new Mock<Validator>();
            validator.Setup(x => x.Val(out er)).Returns(true);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestExcepcionArray() {
            Block block = new Block(-2);
        }
        [Test]
        public void TestProcessInput() {
            ProcessInput processInput = new ProcessInput(10, 20);
            Assert.IsNotNull(processInput);
        }
        [Test]
        public void TestProcessInputMock() {
            Mock<ProcessInput> processInput = new Mock<ProcessInput>();
            processInput.SetupProperty(x => 2).SetupProperty(y => 21);
        }
    }
}
