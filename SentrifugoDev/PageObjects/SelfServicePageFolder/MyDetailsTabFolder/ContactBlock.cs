using OpenQA.Selenium;
using SentrifugoDev.CommonLip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentrifugoDev.PageObjects.SelfServicePageFolder.MyDetailsTabFolder
{
    public class ContactBlock
    {
        private IWebDriver driver;
        protected CommonMethods commonMethods;
        protected DatePickerCalendarPlugin datePickerCalendarPlugin;
        protected TablePlugin tablePlugin;

        public ContactBlock(IWebDriver driver)
        {
            this.driver = driver;
            commonMethods = new CommonMethods(driver);
            datePickerCalendarPlugin = new DatePickerCalendarPlugin(driver);
            tablePlugin = new TablePlugin(driver);
        }

        #region Contact Block Elements

        private const string xpathPersonalEmailField = "//input[@id='personalemail']";
        private readonly By PersonalEmailFieldLocator = By.XPath(xpathPersonalEmailField);

        #region Parnament Address Section

        #endregion

        #endregion
    }
}
