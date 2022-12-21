using System;
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
            ContactData contact = new ContactData("asdf", "asdf");
            contact.Email = "asdf@s.s";

            app.Contact.Create(contact);
        }
    }
}
