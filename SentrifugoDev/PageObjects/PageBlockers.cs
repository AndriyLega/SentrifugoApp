using OpenQA.Selenium;
using SentrifugoDev.CommonLip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentrifugoDev.PageObjects
{
     public class PageBlockers
    {
        private IWebDriver driver;
        protected CommonMethods commonMethods;

        public PageBlockers(IWebDriver driver)
        {
            this.driver = driver;
            commonMethods = new CommonMethods(driver);
        }

        private const string xpathPageUIBlocker = "//div[@class='blockUI blockMsg blockPage']";
        private readonly By PageUIBlockerLocator = By.XPath(xpathPageUIBlocker);

        private const string xpathMainLoader = "//div[@id='spinner']";
        private readonly By MainLoaderLocator = By.XPath(xpathMainLoader);

        /// <summary>
        /// Method opens View Profile tab on User Profile page
        /// </summary>
        public void WaitTillPageUIBlockerDisappeared()
        {
            commonMethods.WaitForElementDisappears(PageUIBlockerLocator);
            LogUtil.WriteDebug("Waiting till the Main Loader disappeared of the page");
        }

        /// <summary>
        /// Method waits till small loader disappears
        /// </summary>
        public void WaitUntilLoaderDisappears()
        {
            commonMethods.WaitForElementDisappears(MainLoaderLocator);
            LogUtil.WriteDebug("Waiting till the loader disappears");
        }
    }
}
