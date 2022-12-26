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
    public class ContactRemovalTests : AuthTestBase
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

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Remove(1);

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
