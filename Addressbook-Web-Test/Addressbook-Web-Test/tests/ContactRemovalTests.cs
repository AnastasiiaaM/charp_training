using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using WebAddressbookTests;

namespace WebAddressbookTests
{
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            ContactData contact = new ContactData("rem", "asdf");
            contact.Email = "asdf@s.s";

            if (!app.Contact.CheckIsThereContact())

            {
                app.Contact.Create(contact);
            }

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[1];

            app.Contact.Remove(toBeRemoved);

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.RemoveAt(1);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
