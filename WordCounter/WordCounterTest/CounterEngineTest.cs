using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounter;

namespace WordCounterTest
{
    [TestFixture]
    public class CounterEngineTest
    {
        [Test]
        public void LoadInputStatementFromArgs_InputArgsHasValue_Pass()
        {
            // arrange
            string[] args = { "aaa,bbb,ccc", "" };

            // act
            CounterEngine.Instance.LoadInputStatementFromArgs(args);

            // assert
            // since the funtion does not return anything, there is no need for assertion
        }

        [Test]
        public void LoadInputStatementFromArgs_InputArgsNoValue_ThrowEx()
        {
            // arrange
            string[] args = { };

            // assert
            Assert.Throws<ArgumentException>(() =>
            {
                // act
                CounterEngine.Instance.LoadInputStatementFromArgs(args);
            });
        }

        [Test]
        public void ProcessStatement_InputIsEmptyStr_Pass()
        {
            // arrange
            CounterEngine.Instance.InputStatement = string.Empty;

            // Act
            CounterEngine.Instance.ProcessStatement();
        }

        [Test]
        public void ProcessStatement_InputIsNull_ThrowException()
        {
            // arrange
            CounterEngine.Instance.InputStatement = null;

            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                CounterEngine.Instance.ProcessStatement();
            });
        }

        [Test]
        public void ProcessStatement_NormalInput_PassWithCorrectResult()
        {
            // arrange
            CounterEngine.Instance.InputStatement = "This is a statement this is not a file";

            // act
            CounterEngine.Instance.ProcessStatement();

            // assert
            Assert.Multiple(() =>
            {
                Assert.That(CounterEngine.Instance.WordCountDictionary["this"], Is.EqualTo(2));
                Assert.That(CounterEngine.Instance.WordCountDictionary["is"], Is.EqualTo(2));
                Assert.That(CounterEngine.Instance.WordCountDictionary["a"], Is.EqualTo(2));
                Assert.That(CounterEngine.Instance.WordCountDictionary["statement"], Is.EqualTo(1));
                Assert.That(CounterEngine.Instance.WordCountDictionary["not"], Is.EqualTo(1));
                Assert.That(CounterEngine.Instance.WordCountDictionary["file"], Is.EqualTo(1));
            });
        }
    }
}
