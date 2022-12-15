using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactModificationTests : TestBase
    {

        [Test]
        public void ContactModificationTest()
        {
            ContactData  newContact = new ContactData ("assdfdf", "assddf");
            newContact.Email = "new@s.s";

            app.Contact.Modify(3, newContact);
            app.Auth.Logout();
        }

        [Test]
        public void ContactModificationNameTest()
        {
            ContactData newContact = new ContactData("assdfdf", "assddf");
            newContact.Middlename = "sdfgsdf";

            app.Contact.Modify(4, newContact);
            app.Auth.Logout();
        }
    }
}
