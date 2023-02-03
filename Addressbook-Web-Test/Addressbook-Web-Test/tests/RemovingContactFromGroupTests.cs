using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using NUnit.Framework;
using WebAddressbookTests;

namespace WebAddressbookTests
{
    [TestFixture]
    public class RemovingContactFromGroupTests : AuthTestBase
    {
        [SetUp]
        public void Setup()
        {
            ContactData contact = new ContactData("rem", "asdf");
            contact.Email = "asdf@s.s";

            if (!app.Contact.CheckIsThereContact())

            {
                app.Contact.Create(contact);
            }

            GroupData newgroup = new GroupData("fff");
            newgroup.Header = "sdf";
            newgroup.Footer = "ddd";

            if (!app.Groups.CheckIsThereGroup())

            {
                app.Groups.Create(newgroup);
            }
        }

        [Test]
        public void TestRemovingContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            app.Contact.CheckContactNotExist(group);
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = oldList.First();

            app.Contact.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
