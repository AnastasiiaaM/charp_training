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

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(0, newGroup);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newGroup.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
