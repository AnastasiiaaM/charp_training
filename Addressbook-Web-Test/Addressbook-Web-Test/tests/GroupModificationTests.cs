using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WebAddressbookTests;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {

        [Test]
        public void GroupModificationTest()
        {
            GroupData newGroup = new GroupData("new");
            newGroup.Header = null;
            newGroup.Footer = null;


            if (! app.Groups.CheckIsThereGroup())

            {
                GroupData group = new GroupData("fff");
                group.Header = "sdf";
                group.Footer = "ddd";

                app.Groups.Create(group);
            }

            app.Groups.Modify(1, newGroup);
        }
    }
}
