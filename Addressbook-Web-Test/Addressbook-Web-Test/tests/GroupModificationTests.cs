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
    public class GroupModificationTests : GroupTestBase
    {

        [Test]
        public void GroupModificationTest()
        {
            GroupData editGroup = new GroupData("new");
            editGroup.Header = null;
            editGroup.Footer = null;


            if (! app.Groups.CheckIsThereGroup())

            {
                GroupData group = new GroupData("fff");
                group.Header = "sdf";
                group.Footer = "ddd";

                app.Groups.Create(group);
            }

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(oldData, editGroup);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = editGroup.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(editGroup.Name, group.Name);
                }
            }
        }
    }
}
