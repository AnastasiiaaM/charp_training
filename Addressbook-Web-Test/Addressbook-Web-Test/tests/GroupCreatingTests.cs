using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreatingTests : TestBase
    {
        [Test]
        public void GroupCreatingTest()
        {
            GroupData group = new GroupData("fff");
            group.Header = "sdf";
            group.Footer = "ddd";

            app.Groups.Create(group);
        }

        [Test]
        public void EmptyGroupCreatingTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);
        }
    }
}
