using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using WebAddressbookTests;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            GroupData group = new GroupData("fff");
            group.Header = "sdf";
            group.Footer = "ddd";

            if (!app.Groups.CheckIsThereGroup())

            {
                app.Groups.Create(group);
            }

            app.Groups.Remove(1);
        }

    }
}
