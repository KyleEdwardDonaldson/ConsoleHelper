using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using KonsoleHelper;

namespace KonsoleHelper.Tests.AskForInput
{
    [TestFixture]
    public class AskForInput_Number : Helpers
    {
        [SetUp]
        public void SetUp()
        {
        }

        [TestCase("")]
        [TestCase("Custom - what input would you like?")]
        public void ShouldPrintRequestForInput(string request)
        {
        }

        [Test]
        public void ShouldCallReadLine()
        {
        }

        [Test]
        public void Empty_ShouldRecallReadLineUntilNotEmpty()
        {

        }

        [TestCase(typeof(decimal), "")]
        [TestCase(typeof(decimal), "Custom - input is invalid")]
        [TestCase(typeof(int), "")]
        [TestCase(typeof(int), "Custom - input is invalid")]
        [TestCase(typeof(long), "")]
        [TestCase(typeof(long), "Custom - input is invalid")]
        [TestCase(typeof(float), "")]
        [TestCase(typeof(float), "Custom - input is invalid")]
        [TestCase(typeof(double), "")]
        [TestCase(typeof(double), "Custom - input is invalid")]
        public void NonNumeric_ShouldPrintInvalidInputMessage(Type type, string invalidInputMessage)
        {

        }

        [TestCase(typeof(decimal))]
        [TestCase(typeof(int))]
        [TestCase(typeof(long))]
        [TestCase(typeof(float))]
        [TestCase(typeof(double))]
        public void NonNumeric_ShouldRecallReadLine(Type type)
        {
            
        }

        [TestCase(typeof(decimal))]
        [TestCase(typeof(int))]
        [TestCase(typeof(long))]
        [TestCase(typeof(float))]
        [TestCase(typeof(double))]
        public void Numeric_ShouldReturnNumber(Type type)
        {
            var number = <type>Convert.ChangeType(GetRandomNumberOfType(type), type);
        }

        [TestCase(typeof(decimal))]
        [TestCase(typeof(int))]
        [TestCase(typeof(long))]
        [TestCase(typeof(float))]
        [TestCase(typeof(double))]
        public void Numeric_NoLinesAfter_ShouldNotPrintLineAfter(Type type)
        {

        }

        [TestCase(typeof(decimal))]
        [TestCase(typeof(int))]
        [TestCase(typeof(long))]
        [TestCase(typeof(float))]
        [TestCase(typeof(double))]
        public void Numeric_LinesAfter_ShouldNotPrintLineAfter(Type type)
        {

        }
    }
}
