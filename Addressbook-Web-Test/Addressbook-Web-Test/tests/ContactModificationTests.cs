﻿using System;
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
            ContactData newContact = new ContactData ("Андрей", "Зимов");
            newContact.Email = "new@s.s";

            if (! app.Contact.CheckIsThereContact())

            {
                ContactData contact = new ContactData("Иван", "Зимов");
                contact.Email = "asdf@s.s";

                app.Contact.Create(contact);
            }

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Modify(1, newContact);

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts[0].Firstname = newContact.Firstname;
            oldContacts[0].Lastname = newContact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void ContactModificationNameTest()
        {
            ContactData newContact = new ContactData("Алексей", "Петров");
            newContact.Middlename = "Владимирович";
            ContactData contact = new ContactData("Вася", "Голубев");
            contact.Email = "asdf@s.s";

            if (!app.Contact.CheckIsThereContact())

            {
                app.Contact.Create(contact);
            }

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Modify(1, newContact);

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts[0].Firstname = newContact.Firstname;
            oldContacts[0].Lastname = newContact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
