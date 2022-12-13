using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreatingTests : TestBase
    {
        [Test]
        public void GroupCreatingTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator. GoToGroupsPage();
            app.Groups.InitGroupCreating();
            GroupData group = new GroupData("fff");
            group.Header = "sdf";
            group.Footer = "ddd";
            app.Groups.FillGroupForm(group);
            app.Groups.SubmitGroupCreation();
            app.Groups.ReturnToGroupsPage();
            app.Auth.Logout();
        }
    }
}
