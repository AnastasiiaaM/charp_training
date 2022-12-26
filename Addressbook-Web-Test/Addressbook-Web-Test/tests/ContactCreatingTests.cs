using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Addressbook_Web_Test;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using WebAddressbookTests;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreatingTests : AuthTestBase
    {

        [Test]
        public void ContactCreatingTest()
        {
            ContactData contact = new ContactData("eeee", "tttt");
            contact.Email = "asdf@s.s";

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Create(contact);

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
