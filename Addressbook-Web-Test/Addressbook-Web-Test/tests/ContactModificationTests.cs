using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using WebAddressbookTests;

namespace WebAddressbookTests
{
    public class ContactModificationTests : AuthTestBase
    {

        [Test]
        public void ContactModificationTest()
        {
            ContactData newContact = new ContactData ("assdfdf", "assddf");
            newContact.Email = "new@s.s";
            ContactData contact = new ContactData("asdf", "asdf");
            contact.Email = "asdf@s.s";

            if (!app.Contact.CheckIsThereContact())

            {
                app.Contact.Create(contact);
            }
            app.Contact.Modify(3, newContact);
        }

        [Test]
        public void ContactModificationNameTest()
        {
            ContactData newContact = new ContactData("assdfdf", "assddf");
            newContact.Middlename = "sdfgsdf";
            ContactData contact = new ContactData("asdf", "asdf");
            contact.Email = "asdf@s.s";

            if (!app.Contact.CheckIsThereContact())

            {
                app.Contact.Create(contact);
            }
            app.Contact.Modify(2, newContact);
        }
    }
}
