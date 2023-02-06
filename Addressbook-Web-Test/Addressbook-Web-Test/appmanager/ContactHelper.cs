using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper: HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToAddNewPage();

            FillContactForm(contact);
            SaveNewContact();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper Modify(int v, ContactData newContact)
        {
 

            SelectContactForEdit(v);
            FillContactForm(newContact);
            SubmitContactModification();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper Modify(ContactData oldData, ContactData newData)
        {
            manager.Navigator.GoToHomePage();

            SelectContactForEdit(oldData.Id);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper Remove(int v)
        {
            manager.Navigator.GoToHomePage();

            SelectContactForEdit(v);
            RemoveContact();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper Remove(ContactData contact)
        {
            manager.Navigator.GoToHomePage();

            SelectContactForEdit(contact.Id);
            RemoveContact();
            ReturnToHomePage();
            return this;
        }

        public bool CheckIsThereContact()
        {
            manager.Navigator.GoToHomePage();
            return IsElementPresent(By.Name("selected[]"));
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCashe = null;
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[22]")).Click();
            contactCashe = null;
            return this;
        }

        public ContactHelper SelectContactForEdit(int index)
        {            
             driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            
            return this;
        }

        public ContactHelper SelectContactForEdit(String id)
        {
            driver.FindElement(By.XPath("//input[@id='" + id + "']/../.."))
                 .FindElements(By.TagName("td"))[7]
                 .FindElement(By.TagName("a")).Click();

            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("homepage"), contact.Homepage);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }
        public ContactHelper SaveNewContact()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contactCashe = null;
            return this;
        }
        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }
        public ContactHelper Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }

        private List<ContactData> contactCashe = null;

        public List<ContactData> GetContactList()
        {
            if (contactCashe == null)
            {
                contactCashe = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name = 'entry']"));
                foreach (IWebElement element in elements)
                {
                    var firstName = element.FindElement(By.XPath("td[3]")).Text;
                    var lastName = element.FindElement(By.XPath("td[2]")).Text;
                    contactCashe.Add(new ContactData(firstName, lastName));
                }
            }
            return new List<ContactData>(contactCashe);
        }

        public ContactData GetContactInformationTable(int v)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[v]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }

        public ContactData GetContactInformationEditForm(int v)
        {
            manager.Navigator.GoToHomePage();
            SelectContactForEdit(v);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Middlename = middlename,
                Address = address, 
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        public ContactData GetContactInformationDetails(int v)
        {

            manager.Navigator.GoToHomePage();
            driver.FindElements(By.Name("entry"))[v]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
            string allDetails = driver.FindElement(By.Id("content")).Text;
            return new ContactData("", "")
            {
                AllDetails = allDetails
            };
        }


        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);

        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            ComitAddingContactToGroup();
              new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                  .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void ComitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void SelectContact(string contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
        }

        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public void RemoveContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            SelectGroupFromFilter(group.Name);
            SelectContact(contact.Id);
            CommitRemovingContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);

        }

        private void CommitRemovingContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        private void SelectGroupFromFilter(string groupName)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(groupName);
        }

        public void CheckContactExist(GroupData group)
        {
            if (ContactData.GetAll().Except(group.GetContacts()).Count() == 0)
            {
                ContactData contact = group.GetContacts().First();
                RemoveContactFromGroup(contact, group);
            }
        }

        public void CheckContactNotExist(GroupData group)
        {
            if (group.GetContacts().Count() == 0)
            {
                ContactData contact = ContactData.GetAll().First();
                AddContactToGroup(contact, group);
            }
        }
    }
}
