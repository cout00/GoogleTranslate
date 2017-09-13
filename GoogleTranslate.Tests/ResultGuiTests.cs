using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleTranslate.Core;
using Rhino.Mocks;
using System.Windows.Forms;
using NUnit.Framework;

namespace GoogleTranslate.Tests
{
    [TestFixture]
    public class ResultGuiTests
    {
        ObjectPool<IShowTypeForm> MockOfPool;

        [SetUp]
        public void InitAll()
        {
            MockOfPool = MockRepository.GenerateMock<ObjectPool<IShowTypeForm>>();
            Pool.GetDerivativeTypes().ForEach(instanse =>
            {
                MockOfPool.Add((IShowTypeForm)Activator.CreateInstance(instanse));
            });

     

        }
        [Test]
        public void PoolContainsRightValues()
        {
            var types = Pool.GetDerivativeTypes();
            CollectionAssert.AreEqual(MockOfPool.Select(a => a.GetType()), types);
        }
        [Test]
        public void PoolIsSingltoneCollection()
        {
            var oldCount = MockOfPool.Count();
            MockOfPool.Add(new answerBalloonTip());
            var newCount = MockOfPool.Count;
            Assert.That(oldCount, Is.EqualTo(newCount));
        }

        //#KOLHOZ STYLE
        [Test]        
        public void PoolWorksRight()
        {
            MockOfPool.Remove(typeof(answerBalloonTip));
            Assert.That(() =>
            {
                CollectionAssert.Contains(MockOfPool.Select(a => a.GetType()), typeof(answerBalloonTip));
            }, Throws.TypeOf<AssertionException>());
        }
        [Test]
        public void TestFormSize()
        {
            answerForm testForm = new answerForm();

            //testForm.ShowText = "qweqweqeqe qwe qe qwe qwe qw qwe sa dasd asd asd ";
            Assert.That(testForm.DebugLinesCount == 2);
            Assert.That(testForm.Width >= 200);
            //testForm.ShowText = "qweqw";
            Assert.That(testForm.DebugLinesCount == 0);
            Assert.That(testForm.Width <= 200);
        }

    }
}
