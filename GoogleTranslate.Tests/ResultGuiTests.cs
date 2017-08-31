using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GoogleTranslate.Core;
using Rhino.Mocks;
using System.Windows.Forms;

namespace GoogleTranslate.Tests
{
    [TestFixture]
    public class ResultGuiTests
    {
        [Test]
        public void TestFormSize()
        {
            answerForm testForm = new answerForm();
            testForm.ShowText = "qweqweqeqe qwe qe qwe qwe qw qwe sa dasd asd asd ";
            Assert.That(testForm.DebugLinesCount == 2);
            Assert.That(testForm.Width >= 200);
            testForm.ShowText = "qweqw";
            Assert.That(testForm.DebugLinesCount == 0);
            Assert.That(testForm.Width <= 200);
        }

    }
}
