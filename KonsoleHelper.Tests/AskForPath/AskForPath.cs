using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonsoleHelper;

namespace KonsoleHelper.Tests.AskForPath
{
    [TestFixture]
    public class AskForPath
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        [TestCase("")]
        [TestCase("Custom - what path would you like?")]
        public void ShouldPrintRequestForPath(string request)
        {
        }

        [Test]
        public void ShouldCallReadLine()
        {
        }

        [Test]
        public void EmptyInput_ShouldPrintEmptyInputMessage_AndRecallReadLine()
        {
        }

        [Test]
        public void PathDoesNotExist_ShouldPrintPathDoesNotExistMessage_AndRecallReadLine()
        {
        }

        [Test]
        public void RealPathWithoutSlash_IncludeSlashIsTrue_ReturnsPathWithSlash()
        {
        }

        [Test]
        public void RealPathWithSlash_IncludeSlashIsTrue_ReturnsPathWithSlash()
        {
        }

        [Test]
        public void RealPathWithoutSlash_IncludeSlashIsFalse_ReturnsPathWithoutSlash()
        {
        }

        [Test]
        public void RealPathWithSlash_IncludeSlashIsFalse_ReturnsPathWithoutSlash()
        {
        }
    }
}
