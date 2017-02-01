using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using threeN.Validator;
using Models;
using NUnit.Framework;

namespace Libraries {
    [TestFixture]
    class Test {
        [Test]
        public void testValidator() {
            var mock = new Mock<Validator>();
            ErrorDispose errorDispose = new ErrorDispose();
            mock.Setup(foo => foo.Val(out errorDispose)).Returns(true);
            for (int i = 0; i <= 5; i++) {
                switch (i) {
                    case 1:
                        mock.SetupSet(foo => foo.i = -1);
                        mock.SetupSet(foo => foo.j = 100);
                        mock.Setup(foo => foo.Val(out errorDispose)).Returns(false);
                        break;
                    case 2:
                        mock.SetupSet(foo => foo.i = 10);
                        mock.SetupSet(foo => foo.j = -1);
                        mock.Setup(foo => foo.Val(out errorDispose)).Returns(false);
                        break;
                    case 3:
                        mock.SetupSet(foo => foo.i = 11000);
                        mock.SetupSet(foo => foo.j = 100);
                        mock.Setup(foo => foo.Val(out errorDispose)).Returns(false);
                        break;
                    case 4:
                        mock.SetupSet(foo => foo.i = 10);
                        mock.SetupSet(foo => foo.j = 11000);
                        mock.Setup(foo => foo.Val(out errorDispose)).Returns(false);
                        break;
                    case 5:
                        mock.SetupSet(foo => foo.i = 10);
                        mock.SetupSet(foo => foo.j = 100);
                        mock.Setup(foo => foo.Val(out errorDispose)).Returns(true);
                        break;

                    default:
                        break;
                }
            }
        }

    }
}
