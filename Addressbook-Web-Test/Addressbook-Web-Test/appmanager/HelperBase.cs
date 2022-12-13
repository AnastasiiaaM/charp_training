using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class HelperBase
    {
        protected WebDriver driver;

        public HelperBase (WebDriver driver)
        {
            this.driver = driver;
        }
    }
}