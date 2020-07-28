using OpenQA.Selenium;
using SentrifugoDev.CommonLip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SentrifugoDev.CommonLip.CommonMethods;

namespace SentrifugoDev.PageObjects.SelfServicePageFolder
{
    public class MyLeaveTab
    {
        private IWebDriver driver;
        protected CommonMethods commonMethods;
        protected DatePickerCalendarPlugin datePickerCalendarPlugin;
        protected TablePlugin tablePlugin;

        public MyLeaveTab(IWebDriver driver)
        {
            this.driver = driver;
            commonMethods = new CommonMethods(driver);
            datePickerCalendarPlugin = new DatePickerCalendarPlugin(driver);
            tablePlugin = new TablePlugin(driver);
        }

        #region My Leave Tab Elements

        private const string xpathSuccessfullActionMessage = "//div[@id='messageData']";
        private readonly By SuccessfullActionMessageLocator = By.XPath(xpathSuccessfullActionMessage);

        #region Filter Block Elements

        private const string xpathAllLeavesButton = "//div[@id='filter_all']";
        private readonly By AllLeavesButtonLocator = By.XPath(xpathAllLeavesButton);

        private const string xpathPendingLeavesButton = "//div[@id='filter_pendingleaves']";
        private readonly By PendingLeavesButtonLocator = By.XPath(xpathPendingLeavesButton);

        private const string xpathCanceledLeavesButton = "//div[@id='filter_cancelleaves']";
        private readonly By CanceledLeavesButtonLocator = By.XPath(xpathCanceledLeavesButton);

        private const string xpathApprovedLeavesButton = "//div[@id='filter_approvedleaves']";
        private readonly By ApprovedLeavesButtonLocator = By.XPath(xpathApprovedLeavesButton);

        private const string xpathRejectedLeavesButton = "//div[@id='filter_rejectedleaves']";
        private readonly By RejectedLeavesButtonLocator = By.XPath(xpathRejectedLeavesButton);

        #endregion

        #region Popup Window Elements

        private const string xpathPopupTitle = "//h1[@id = 'popup_title']";
        private readonly By PopupTitleLocator = By.XPath(xpathPopupTitle);

        private const string xpathPopupMessage = "//div[@id = 'popup_message']";
        private readonly By PopupMessageLocator = By.XPath(xpathPopupMessage);

        private const string xpathOkPopupButton = "//input[@id = 'popup_ok']";
        private readonly By OkPopupButtonLocator = By.XPath(xpathOkPopupButton);

        private const string xpathCancelPopupButton = "//input[@id = 'popup_cancel']";
        private readonly By CancelPopupButtonLocator = By.XPath(xpathCancelPopupButton);

        #endregion

        #endregion

        #region My Leave Tab Methods

        /// <summary>
        /// Method gets text from Successfull action message in My Leave tab and returns this value
        /// </summary>
        public string GetTextFromSuccessfullActionMessage()
        {
            LogUtil.WriteDebug("Getting text Successfull action message in My Leave tab");
            return commonMethods.GetElementByWithLogs(driver, SuccessfullActionMessageLocator, "Can NOT get text from Successfully created Leave request message in My Leave tab").Text;
        }

        #region Filter Block Methods

        /// <summary>
        /// Method clicks on 'All' filter button what shows all requested leaves in My Leave table
        /// </summary>
        public void ClickAllFilterButton()
        {
            commonMethods.GetElementByWithLogs(driver, AllLeavesButtonLocator, "Can NOT click 'All' filter button").Click();
            LogUtil.WriteDebug("Clicked on 'All' filter button in My Leave  tab");
        }

        /// <summary>
        /// Method clicks on 'Pending Leaves' filter button what shows requested leaves with status 'Pending' in My Leave table
        /// </summary>
        public void ClickPendingLeavesFilterButton()
        {
            commonMethods.GetElementByWithLogs(driver, PendingLeavesButtonLocator, "Can NOT click 'Pending Leaves' filter button").Click();
            LogUtil.WriteDebug("Clicked on 'Pending Leaves' filter button in My Leave  tab");
        }

        /// <summary>
        /// Method clicks on 'Canceled Leaves' filter button what shows requested leaves with status 'Canceled' in My Leave table
        /// </summary>
        public void ClickCanceledLeavesFilterButton()
        {
            commonMethods.GetElementByWithLogs(driver, CanceledLeavesButtonLocator, "Can NOT click 'Canceled Leaves' filter button").Click();
            LogUtil.WriteDebug("Clicked on 'Canceled Leaves' filter button in My Leave  tab");
        }

        /// <summary>
        /// Method clicks on 'Approved Leaves' filter button what shows requested leaves with status 'Approved' in My Leave table
        /// </summary>
        public void ClickApprovedLeavesFilterButton()
        {
            commonMethods.GetElementByWithLogs(driver, ApprovedLeavesButtonLocator, "Can NOT click 'Approved Leaves' filter button").Click();
            LogUtil.WriteDebug("Clicked on 'Approved Leaves' filter button in My Leave  tab");
        }

        /// <summary>
        /// Method clicks on 'Rejected Leaves' filter button what shows requested leaves with status 'Rejected' in My Leave table
        /// </summary>
        public void ClickRejectedLeavesFilterButton()
        {
            commonMethods.GetElementByWithLogs(driver, RejectedLeavesButtonLocator, "Can NOT click 'Rejected Leaves' filter button").Click();
            LogUtil.WriteDebug("Clicked on 'Rejected Leaves' filter button in My Leave tab");
        }

        /// <summary>
        /// Method gets the number of leaves of filter section in My Leave tab
        /// </summary>
        public string GetTheNumberOfLeavesInFilterButtonBadge(string xPath)
        {
            LogUtil.WriteDebug("Got the number of leaves of filter section in My Leave tab");
            return commonMethods.GetElementByWithLogs(driver, By.XPath(xPath + "//label"), "Can NOT find filter button").Text;
            
        }

        /// <summary>
        /// Method checks if thr number of records in the table is the same as number in the All Leaves filter button on My Leave table
        /// </summary>
        public bool CheckIfNumberOfLeavesCountedCorrectlyInAllLeavesFilterButtonBadge()
        {
            int allLeavesBadgeNumber = Int32.Parse(GetTheNumberOfLeavesInFilterButtonBadge(xpathAllLeavesButton));
            int countOfRecords = tablePlugin.CountOfAllRecordsInTheTable();
            if (!allLeavesBadgeNumber.Equals(countOfRecords))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Method checks if thr number of records in the table is the same as number in the Pending Leaves filter button on My Leave table
        /// </summary>
        public bool CheckIfNumberOfLeavesCountedCorrectlyInPendingLeavesFilterButtonBadge()
        {
            int pendingLeavesBadgeNumber = Int32.Parse(GetTheNumberOfLeavesInFilterButtonBadge(xpathPendingLeavesButton));
            int countOfRecords = tablePlugin.CountOfAllRecordsInTheTable();
            if (!pendingLeavesBadgeNumber.Equals(countOfRecords))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Method checks if thr number of records in the table is the same as number in the Canceled Leaves filter button on My Leave table
        /// </summary>
        public bool CheckIfNumberOfLeavesCountedCorrectlyInCanceledLeavesFilterButtonBadge()
        {
            int canceledLeavesBadgeNumber = Int32.Parse(GetTheNumberOfLeavesInFilterButtonBadge(xpathCanceledLeavesButton));
            int countOfRecords = tablePlugin.CountOfAllRecordsInTheTable();
            if (!canceledLeavesBadgeNumber.Equals(countOfRecords))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Method checks if thr number of records in the table is the same as number in the Approved Leaves filter button on My Leave table
        /// </summary>
        public bool CheckIfNumberOfLeavesCountedCorrectlyInApprovedLeavesFilterButtonBadge()
        {
            int approvedLeavesBadgeNumber = Int32.Parse(GetTheNumberOfLeavesInFilterButtonBadge(xpathApprovedLeavesButton));
            int countOfRecords = tablePlugin.CountOfAllRecordsInTheTable();
            if (!approvedLeavesBadgeNumber.Equals(countOfRecords))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Method checks if thr number of records in the table is the same as number in the Rejected Leaves filter button on My Leave table
        /// </summary>
        public bool CheckIfNumberOfLeavesCountedCorrectlyInRejectedLeavesFilterButtonBadge()
        {
            int rejectedLeavesBadgeNumber = Int32.Parse(GetTheNumberOfLeavesInFilterButtonBadge(xpathRejectedLeavesButton));
            int countOfRecords = tablePlugin.CountOfAllRecordsInTheTable();
            if (!rejectedLeavesBadgeNumber.Equals(countOfRecords))
            {
                return false;
            }
            return true;
        }

        #endregion

        #region Popup Window Methods

        /// <summary>
        /// Method gets title of popup window in My Leave tab and returns this value
        /// </summary>
        public string GetTitleOfPopupWindow()
        {
            LogUtil.WriteDebug("Getting title of popup window in My Leave tab");
            return commonMethods.GetElementByWithLogs(driver, PopupTitleLocator, "Can NOT get title of popup window in My Leave tab").Text;
        }

        /// <summary>
        /// Method gets text from popup message in My Leave tab and returns this value
        /// </summary>
        public string GetTextFromMessageOfPopupWindow()
        {
            LogUtil.WriteDebug("Getting text from popup message in My Leave tab");
            return commonMethods.GetElementByWithLogs(driver, PopupMessageLocator, "Can NOT get text from popup message in My Leave tab").Text;
        }

        /// <summary>
        /// Method clicks on 'Ok' button of appeared popup window in My Leave table
        /// </summary>
        public void ClickOkButtonOfPopupWindow()
        {
            commonMethods.GetElementByWithLogs(driver, OkPopupButtonLocator, "Can NOT click 'Ok' button of appeared popup window").Click();
            LogUtil.WriteDebug("Clicked on 'Ok' button of appeared popup window in My Leave  tab");
        }

        /// <summary>
        /// Method clicks on 'Cancel' button of appeared popup window in My Leave table
        /// </summary>
        public void ClickCancelButtonOfPopupWindow()
        {
            commonMethods.GetElementByWithLogs(driver, CancelPopupButtonLocator, "Can NOT click 'Cancel' button of appeared popup window").Click();
            LogUtil.WriteDebug("Clicked on 'Cancel' button of appeared popup window in My Leave  tab");
        }

        #endregion

        #endregion
    }

}
