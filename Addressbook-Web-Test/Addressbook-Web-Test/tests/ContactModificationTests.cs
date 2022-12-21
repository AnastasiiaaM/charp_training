using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WebAddressbookTests;

namespace WebAddressbookTests
{
    public class ContactModificationTests : AuthTestBase
    {

        [Test]
        public void ContactModificationTest()
        {
            ContactData  newContact = new ContactData ("assdfdf", "assddf");
            newContact.Email = "new@s.s";

            app.Contact.Modify(3, newContact);
        }

        [Test]
        public void ContactModificationNameTest()
        {
            ContactData newContact = new ContactData("assdfdf", "assddf");
            newContact.Middlename = "sdfgsdf";

            app.Contact.Modify(4, newContact);
        }
    }
}
