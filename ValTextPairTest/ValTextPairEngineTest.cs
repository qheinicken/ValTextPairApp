using FizzBuzzDLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ValTextPairTest
{
    
    
    /// <summary>
    ///This is a test class for ValTextPairEngineTest and is intended
    ///to contain all ValTextPairEngineTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ValTextPairEngineTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetTextFromNumber
        ///</summary>
        [TestMethod()]
        public void GetTextFromNumberTest()
        {
            int number = 25;
            List<Tuple<int, string>> pairs = new List<Tuple<int, string>>();

            pairs.Add(new Tuple<int, string>(4, "Fizz"));
            pairs.Add(new Tuple<int, string>(7, "Buzz"));
            pairs.Add(new Tuple<int, string>(9, "Flash"));

            string expected = "25";
            string actual;
            actual = ValTextPairEngine.GetTextFromNumber(number, pairs);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetTextFromNumber
        ///</summary>
        [TestMethod()]
        public void GetTextFromNumberTest2()
        {
            int number = 81;
            List<Tuple<int, string>> pairs = new List<Tuple<int, string>>();

            pairs.Add(new Tuple<int, string>(4, "Fizz"));
            pairs.Add(new Tuple<int, string>(7, "Buzz"));
            pairs.Add(new Tuple<int, string>(9, "Flash"));

            string expected = "Flash";
            string actual;
            actual = ValTextPairEngine.GetTextFromNumber(number, pairs);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetTextFromNumberTest3()
        {
            int number = 252;
            List<Tuple<int, string>> pairs = new List<Tuple<int, string>>();

            pairs.Add(new Tuple<int, string>(4, "Fizz"));
            pairs.Add(new Tuple<int, string>(7, "Buzz"));
            pairs.Add(new Tuple<int, string>(9, "Flash"));

            string expected = "FizzBuzzFlash";
            string actual;
            actual = ValTextPairEngine.GetTextFromNumber(number, pairs);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetTextFromNumberTest4()
        {
            int number = 126;
            List<Tuple<int, string>> pairs = new List<Tuple<int, string>>();

            pairs.Add(new Tuple<int, string>(4, "Fizz"));
            pairs.Add(new Tuple<int, string>(7, "Buzz"));
            pairs.Add(new Tuple<int, string>(9, "Flash"));

            string expected = "BuzzFlash";
            string actual;
            actual = ValTextPairEngine.GetTextFromNumber(number, pairs);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for TryCreate
        ///</summary>
        [TestMethod()]
        public void TryCreateTest()
        {
            string[] input = { "1", "2000", "3", "Fizz", "5", "Bang" };
            ValTextPairEngine engine = null;
            ValTextPairEngine engineExpected = new ValTextPairEngine();

            engineExpected.Begin = 1;
            engineExpected.End = 2000;
            engineExpected.Pairs.Add(new Tuple<int,string>(3, "Fizz"));
            engineExpected.Pairs.Add(new Tuple<int,string>(5, "Bang"));
            engineExpected.IsValid = true;

            ValTextPairEngine.TryCreate(input, out engine);
            Assert.IsTrue(engine.Equals(engineExpected));
        }

        /// <summary>
        ///A test for TryCreate to fail
        ///</summary>
        [TestMethod()]
        public void TryCreateTestNotEqual()
        {
            string[] input = { "1", "2000", "3", "Fizz", "5", "Bang" };
            ValTextPairEngine engine = null;
            ValTextPairEngine engineExpected = new ValTextPairEngine();

            engineExpected.Begin = 1;
            engineExpected.End = 2000;
            engineExpected.Pairs.Add(new Tuple<int, string>(3, "Fuzz"));
            engineExpected.Pairs.Add(new Tuple<int, string>(5, "Bang"));
            engineExpected.IsValid = true;

            ValTextPairEngine.TryCreate(input, out engine);
            Assert.IsFalse(engine.Equals(engineExpected));
        }

        /// <summary>
        ///A test for TryCreate to fail
        ///</summary>
        [TestMethod()]
        public void TryCreateTestBadIntegers()
        {
            string[] input = { "200", "150", "3", "Fizz", "5", "Bang" };
            ValTextPairEngine engine = null;
            string expected = "begin param must be larger than end param.";

            ValTextPairEngine.TryCreate(input, out engine);

            Assert.AreEqual(engine.Error, expected);
        }

        /// <summary>
        ///A test for TryCreate to fail
        ///</summary>
        [TestMethod()]
        public void TryCreateTestBadFirstInteger()
        {
            string[] input = { "AA", "150", "3", "Fizz", "5", "Bang" };
            ValTextPairEngine engine = null;
            string expected = "begin param must be an integer.";

            ValTextPairEngine.TryCreate(input, out engine);

            Assert.AreEqual(engine.Error, expected);
        }

        /// <summary>
        ///A test for TryCreate to fail
        ///</summary>
        [TestMethod()]
        public void TryCreateTestBadSecondInteger()
        {
            string[] input = { "5", "B55", "3", "Fizz", "5", "Bang" };
            ValTextPairEngine engine = null;
            string expected = "end param must be an integer.";

            ValTextPairEngine.TryCreate(input, out engine);

            Assert.AreEqual(engine.Error, expected);
        }

        /// <summary>
        ///A test for TryCreate to fail
        ///</summary>
        [TestMethod()]
        public void TryCreateTestLessThan4Params()
        {
            string[] input = { "5", "33", "3" };
            ValTextPairEngine engine = null;
            string expected = "Must input at least 4 params in the form of begin, end, int, text.";

            ValTextPairEngine.TryCreate(input, out engine);

            Assert.AreEqual(engine.Error, expected);
        }

        /// <summary>
        ///A test for TryCreate to fail
        ///</summary>
        [TestMethod()]
        public void TryCreateTestPairsNotPaired()
        {
            string[] input = { "5", "55", "3", "Fizz", "5" };
            ValTextPairEngine engine = null;
            string expected = "incorrect number of params, after begin and end, must have val/text pairs.";

            ValTextPairEngine.TryCreate(input, out engine);

            Assert.AreEqual(engine.Error, expected);
        }

        /// <summary>
        ///A test for TryCreate to fail
        ///</summary>
        [TestMethod()]
        public void TryCreateTestBadParamInPairs()
        {
            string[] input = { "5", "55", "3", "Fizz", "5B", "Flash" };
            ValTextPairEngine engine = null;
            string expected = "val/text pairs must start with integer";

            ValTextPairEngine.TryCreate(input, out engine);

            Assert.AreEqual(engine.Error, expected);
        }

        /// <summary>
        ///A test for Begin
        ///</summary>
        [TestMethod()]
        public void BeginTest()
        {
            ValTextPairEngine target = new ValTextPairEngine();
            int expected = 5;
            int actual;
            target.Begin = expected;
            actual = target.Begin;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for End
        ///</summary>
        [TestMethod()]
        public void EndTest()
        {
            ValTextPairEngine target = new ValTextPairEngine();
            int expected = 2255;
            int actual;
            target.End = expected;
            actual = target.End;
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for Error
        ///</summary>
        [TestMethod()]
        public void ErrorTest()
        {
            ValTextPairEngine target = new ValTextPairEngine();
            string expected = "begin param must be an integer.";
            string actual;
            target.Error = expected;
            actual = target.Error;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsValid
        ///</summary>
        [TestMethod()]
        public void IsValidTest()
        {
            ValTextPairEngine target = new ValTextPairEngine();
            bool expected = false;
            bool actual;
            target.IsValid = expected;
            actual = target.IsValid;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Output
        ///</summary>
        [TestMethod()]
        public void OutputTest()
        {
            ValTextPairEngine target = new ValTextPairEngine();
            StringBuilder expected = new StringBuilder();
            expected.Append("1");
            expected.Append("2");
            expected.Append("Fizz");
            expected.Append("4");
            expected.Append("Buzz");

            StringBuilder actual;
            target.Output = expected;
            actual = target.Output;
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        /// <summary>
        ///A test for Pairs
        ///</summary>
        [TestMethod()]
        public void PairsTest()
        {
            ValTextPairEngine target = new ValTextPairEngine();
            List<Tuple<int, string>> expected = new List<Tuple<int,string>>();

            expected.Add(new Tuple<int,string>(3, "Fizz"));
            expected.Add(new Tuple<int,string>(5, "Buzz"));

            List<Tuple<int, string>> actual;
            target.Pairs = expected;
            actual = target.Pairs;
            Assert.AreEqual(expected, actual);
        }
    }
}
