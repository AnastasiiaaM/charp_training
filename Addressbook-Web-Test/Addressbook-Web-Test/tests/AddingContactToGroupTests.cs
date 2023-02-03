using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddingContactToGroupTests : AuthTestBase
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

        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            app.Contact.CheckContactExist(group);
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();

            app.Contact.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }

    }
}
