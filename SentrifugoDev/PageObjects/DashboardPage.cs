using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SentrifugoDev.CommonLip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentrifugoDev.PageObjects
{
    public class DashboardPage
    {
        private IWebDriver driver;
        private CommonMethods commonMethods;

        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
            commonMethods = new CommonMethods(driver);
        }
    }
}
