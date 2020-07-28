using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SentrifugoDev.CommonLip;
using SentrifugoDev.Enums;
using SentrifugoDev.PageObjects.SelfServicePageFolder.MyDetailsTabFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentrifugoDev.PageObjects.SelfServicePageFolder
{
    public class SelfServicePage
    {
        private IWebDriver driver;
        protected CommonMethods commonMethods;
        public LeaveRequestTab leaveRequestTab;
        public MyLeaveTab myLeaveTab;
        public FrameContent frameContent;
        public AppliedLeavePage appliedLeavePage;
        public MyDetailsTab myDetailsTab;

        public SelfServicePage(IWebDriver driver)
        {
            this.driver = driver;
            commonMethods = new CommonMethods(driver);
            leaveRequestTab = new LeaveRequestTab(driver);
            myLeaveTab = new MyLeaveTab(driver);
            frameContent = new FrameContent(driver);
            appliedLeavePage = new AppliedLeavePage(driver);
            myDetailsTab = new MyDetailsTab(driver);
        }

        #region Self Service Menu Elements

        private const string xpathBredCrumbs = "//div[@class='breadcrumbs']";
        private readonly By BredCrumbsLocator = By.XPath(xpathBredCrumbs);

        private const string xpathAddOrRemoveShortcutsButton = "//div[@id='pageshortcut']";
        private readonly By AddOrRemoveShortcutsButtonLocator = By.XPath(xpathAddOrRemoveShortcutsButton);

        private const string xpathSelfServiceMenu = "//div[contains(@class,'selected_menu_class')]";
        private readonly By SelfServiceMenuLocator = By.XPath(xpathSelfServiceMenu);

        private const string xpathLeavesDropdown = "//span[@id='acc_li_toggle_31']";
        private readonly By LeavesDropdownLocator = By.XPath(xpathLeavesDropdown);

        private const string xpathLeavesDropDownList = "//div[contains(@class,'selected_menu_class')]//ul[@style='display: block;']";
        private readonly By LeavesDropdownListLocator = By.XPath(xpathLeavesDropDownList);

        private const string xpathLeaveRequestButton = "//a[@id='61']";
        private readonly By LeaveRequestButtonLocator = By.XPath(xpathLeaveRequestButton);

        private const string xpathMyLeaveButton = "//a[@id='62']";
        private readonly By MyLeaveButtonLocator = By.XPath(xpathMyLeaveButton);

        private const string xpathEmployeeLeaveButton = "//a[@id='65']";
        private readonly By EmployeeLeaveButtonLocator = By.XPath(xpathEmployeeLeaveButton);

        private const string xpathMyDetailsButton = "//a[@id='32']";
        private readonly By MyDetailsButtonLocator = By.XPath(xpathMyDetailsButton);

        private const string xpathMyHolidayCalendarButton = "//a[@id='43']";
        private readonly By MyHolidayCalendarButtonLocator = By.XPath(xpathMyHolidayCalendarButton);

        private const string xpathMyTeamButton = "//a[@id='34']";
        private readonly By MyTeamButtonLocator = By.XPath(xpathMyTeamButton);

        #endregion


        #region Self Service Menu Methods

        /// <summary>
        /// Method checks if Bred Crumbs is present on the opened tab
        /// </summary>
        public bool IsBredCrumbsPresentOnOpenedTab()
        {
            LogUtil.WriteDebug("Checks if Bred Crumbs is present on the opened tab");
            return commonMethods.IsElementPresent(BredCrumbsLocator);
        }

        /// <summary>
        /// Method clicks on Add or Remove Shortcuts button on the opened tab
        /// </summary>
        public void ClickAddOrRemoveShortcutsButtonOnOpenedTab()
        {
            commonMethods.GetElementByWithLogs(driver, AddOrRemoveShortcutsButtonLocator, "Can NOT click 'Add or Remove Shortcuts' button").Click();
            LogUtil.WriteDebug("Clicked on Add or Remove Shortcuts button on the opened tab");
        }

        /// <summary>
        /// Method clicks on Leaves dropdown in Self Service Menu
        /// </summary>
        public void ClickLeavesDropdown()
        {
            commonMethods.GetElementByWithLogs(driver, LeavesDropdownLocator, "Can NOT click 'Leaves' dropdown").Click();
            LogUtil.WriteDebug("Clicked on Leaves dropdown in Self Service Menu");
        }

        /// <summary>
        /// Method clicks on Leave Request button in Self Service Menu
        /// </summary>
        public void ClickLeaveRequestButton()
        {
            OpenLeavesDropdownList();
            commonMethods.GetElementByWithLogs(driver, LeaveRequestButtonLocator, "Can NOT click 'Leave Request' button").Click();
            LogUtil.WriteDebug("Clicked on Leave Request button in Self Service Menu");
        }

        /// <summary>
        /// Method clicks on My Leave button in Self Service Menu
        /// </summary>
        public void ClickMyLeaveButton()
        {
            OpenLeavesDropdownList();
            commonMethods.GetElementByWithLogs(driver, MyLeaveButtonLocator, "Can NOT click 'My Leave' button").Click();
            LogUtil.WriteDebug("Clicked on My Leave button in Self Service Menu");
        }

        /// <summary>
        /// Method clicks on Employee Leave button in Self Service Menu
        /// </summary>
        public void ClickEmployeeLeavebutton()
        {
            OpenLeavesDropdownList();
            commonMethods.GetElementByWithLogs(driver, EmployeeLeaveButtonLocator, "Can NOT click 'Employee Leave' button").Click();
            LogUtil.WriteDebug("Clicked on Employee Leave button in Self Service Menu");
        }

        /// <summary>
        /// Method clicks on 'My Details' button in Self Service Menu
        /// </summary>
        public void ClickMyDetailsButton()
        {
            commonMethods.GetElementByWithLogs(driver, MyDetailsButtonLocator, "Can NOT click 'My Details' button").Click();
            LogUtil.WriteDebug("Clicked on 'My Details' button in Self Service Menu");
        }

        /// <summary>
        /// Method clicks on My Holiday Calendar button in Self Service Menu
        /// </summary>
        public void ClickMyHolidayCalendarButton()
        {
            commonMethods.GetElementByWithLogs(driver, MyHolidayCalendarButtonLocator, "Can NOT click 'My Holiday Calendar' button").Click();
            LogUtil.WriteDebug("Clicked on My Holiday Calendar button in Self Service Menu");
        }

        /// <summary>
        /// Method clicks on My Team button in Self Service Menu
        /// </summary>
        public void ClickMyTeamButton()
        {
            commonMethods.GetElementByWithLogs(driver, MyTeamButtonLocator, "Can NOT click 'My Team' button").Click();
            LogUtil.WriteDebug("Clicked on My Team button in Self Service Menu");
        }

        /// <summary>
        /// Methid check if element present and returns true oe false
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        public bool OpenLeavesDropdownList()
        {
            try
            {
                commonMethods.WaitForElementIsVisable(driver, LeavesDropdownListLocator);
                return true;
            }
            catch (WebDriverTimeoutException e)
            {
                commonMethods.GetElementByWithLogs(driver, LeavesDropdownLocator, "Can not open Leaves dropdown ").Click();
                return false;
            }
        }


        #endregion


    }

}
