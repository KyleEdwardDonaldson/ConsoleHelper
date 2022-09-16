using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonsoleHelper;
using Moq;

namespace KonsoleHelper.Tests.AskForInput
{
    [TestFixture]
    public class WriteLines : Helpers
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void NoLinesAfter_ShouldWriteSpecifiedLinesOnly()
        {
            var numberOfLines = GetRandomInt(5, 10);
            var expected = GetOrAppendStrings(numberOfLines);

            SetupLinesToPrintInOrder(expected);

            Konsole.WriteLines(expected, 0);

            MockConsole.Verify();
            MockConsole.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(expected.Length));
        }

        [Test]
        [Repeat(5)]
        public void LinesAfter_ShouldWriteSpecifiedLineAndLinesAfter()
        {
            var numberOfLines = GetRandomInt(5, 10);
            var numberOfLinesAfter = GetRandomInt(5, 10);
            var lines = GetOrAppendStrings(numberOfLines);

            var expected = GetOrAppendStrings(lines, numberOfLinesAfter, true);
            SetupLinesToPrintInOrder(expected);

            Konsole.WriteLines(lines, numberOfLinesAfter);

            MockConsole.Verify();
            MockConsole.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(expected.Length));
        }

        [Test]
        [Repeat(5)]
        public void RepeatedLine_NoLinesAfter_ShouldWriteRepeatedLineOnly()
        {
            var numberOfLines = GetRandomInt(5, 10);
            var expected = GetOrAppendStrings(GetRandomString(), numberOfLines);

            SetupLinesToPrintInOrder(expected);

            Konsole.WriteLines(numberOfLines, expected[0], 0);

            MockConsole.Verify();
            MockConsole.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(expected.Length));
        }

        [Test]
        [Repeat(5)]
        public void RepeatedLine_LinesAfter_ShouldWriteRepeatedLineWithLinesAfter()
        {
            var numberOfLines = GetRandomInt(5, 10);
            var numberOfLinesAfter = GetRandomInt(5, 10);
            var expected = GetOrAppendStrings(GetRandomString(), numberOfLines);
            expected = GetOrAppendStrings(expected, numberOfLinesAfter, true);

            SetupLinesToPrintInOrder(expected);

            Konsole.WriteLines(numberOfLines, expected[0], numberOfLinesAfter);

            MockConsole.Verify();
            MockConsole.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(expected.Length));
        }

        [Test]
        [Repeat(5)]
        public void NumberOfLinesOnly_ShouldRepeatExactNumberOfEmptyLines()
        {
            var numberOfLines = GetRandomInt(5, 10);
            var expected = GetOrAppendStrings(numberOfLines, true);

            SetupLinesToPrintInOrder(expected);

            Konsole.WriteLines(numberOfLines);

            MockConsole.Verify();
            MockConsole.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(expected.Length));
        }

        [Test]
        [Repeat(5)]
        public void LinesInBetween_NoLinesAfter_ShouldWriteLinesWithEmptyGapsBetween()
        {
            var numberOfLines = GetRandomInt(5, 10);
            var linesInbetween = GetRandomInt(5, 10);
            var lines = GetOrAppendStrings(GetRandomString(), numberOfLines);
            var listOfStrings = new List<string>();
            for (var indexOfLines = 0; indexOfLines < lines.Length; indexOfLines++)
            {
                var line = lines[indexOfLines];

                listOfStrings.Add(line);

                if (indexOfLines != lines.Length - 1)
                {
                    for (var indexOfLinesBetween = 0; indexOfLinesBetween < linesInbetween; indexOfLinesBetween++)
                    {
                        listOfStrings.Add(string.Empty);
                    }
                }
            }
            var expected = listOfStrings.ToArray();

            SetupLinesToPrintInOrder(expected);

            Konsole.WriteLines(lines, 0, linesInbetween);

            MockConsole.Verify();
            MockConsole.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(expected.Length));
        }

        [Test]
        [Repeat(5)]
        public void LinesInBetween_LinesAfter_ShouldWriteLinesWithEmptyGapsBetweenAndLinesAfter()
        {
            var numberOfLines = GetRandomInt(5, 10);
            var linesInbetween = GetRandomInt(5, 10);
            var linesAfter = GetRandomInt(5, 10);
            var lines = GetOrAppendStrings(numberOfLines);
            var listOfStrings = new List<string>();
            for (var indexOfLines = 0; indexOfLines < lines.Length; indexOfLines++)
            {
                var line = lines[indexOfLines];

                listOfStrings.Add(line);

                if (indexOfLines != lines.Length - 1)
                {
                    for (var indexOfLinesBetween = 0; indexOfLinesBetween < linesInbetween; indexOfLinesBetween++)
                    {
                        listOfStrings.Add(string.Empty);
                    }
                }
            }
            var expected = GetOrAppendStrings(listOfStrings, linesAfter, true);

            SetupLinesToPrintInOrder(expected);

            Konsole.WriteLines(lines, linesAfter, linesInbetween);

            MockConsole.Verify();
            MockConsole.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(expected.Length));
        }

        [Test]
        [Repeat(5)]
        public void OneLine_LinesInBetweenOverZero_ShouldThrowException()
        {
            var linesInbetween = GetRandomInt(2, 10);
            var lines = GetOrAppendStrings(1);

            Assert.Throws<ArgumentException>(() => Konsole.WriteLines(lines, GetRandomInt(5, 10), linesInbetween));
        }
    }
}
