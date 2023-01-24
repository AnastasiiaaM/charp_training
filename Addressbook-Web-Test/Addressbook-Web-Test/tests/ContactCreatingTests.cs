using System;
using System.IO;
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
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreatingTests : ContactTestBase
    {
        public static IEnumerable<ContactData> RandomGroupDataProvider()
        {
            List<ContactData> contact = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contact.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Middlename = GenerateRandomString(100),
                    HomePhone = GenerateRandomString(100),
                    Email = GenerateRandomString(100)
                });
            }
            return contact;
        }

        public static IEnumerable<ContactData> GroupDataFromXmlFile()
        {
            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void ContactCreatingTest(ContactData contact)
        {
            List<ContactData> oldContacts = ContactData.GetAll();

            app.Contact.Create(contact);

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
