using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using KonsoleHelper;
using Moq;

namespace KonsoleHelper.Tests.AskForInput
{
    [TestFixture]
    public class WriteLine : Helpers
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void NoLinesAfter_ShouldWriteSpecifiedLineOnly()
        {
            var expected = GetOrAppendStrings(1);
            SetupLinesToPrintInOrder(expected);

            Konsole.WriteLine(expected[0], 0);

            MockConsole.Verify();
            MockConsole.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(expected.Length));
        }

        [Test]
        [Repeat(5)]
        public void LinesAfter_ShouldWriteSpecifiedLineAndLinesAfter()
        {
            var expected = GetOrAppendStrings(1);
            var numberOfLinesAfter = GetRandomInt(1, 10);
            expected = GetOrAppendStrings(expected, numberOfLinesAfter, true);

            SetupLinesToPrintInOrder(expected);

            Konsole.WriteLine(expected[0], numberOfLinesAfter);

            MockConsole.Verify();
            MockConsole.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(expected.Length));
        }
    }
}
