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
    public class FrameContent
    {
        private IWebDriver driver;
        protected CommonMethods commonMethods;

        public FrameContent(IWebDriver driver)
        {
            this.driver = driver;
            commonMethods = new CommonMethods(driver);
        }



        #region Leave Request Window Elements

        private const string xpathLeaveRequestFrameDetail = "//iframe[@id= 'leaverequestCont']";
        private readonly By LeaveRequestFrameDetailLocator = By.XPath(xpathLeaveRequestFrameDetail);

        private const string xpathLeaveRequestWindowTitle = "//span[@id = 'ui-id-1']";
        private readonly By LeaveRequestWindowTitleLocator = By.XPath(xpathLeaveRequestWindowTitle);

        private const string xpathCloseLeaveRequestWindowButton = "//button[@role= 'button']";
        private readonly By CloseLeaveRequestWindowButtonLocator = By.XPath(xpathCloseLeaveRequestWindowButton);

        private const string xpathLeaveRequestStatusDropdown = "//select[@id= 'leaveactionid']";
        private readonly By LeaveRequestStatusDropdownLocator = By.XPath(xpathLeaveRequestStatusDropdown);

        private const string xpathCommentTextArea = "//textarea";
        private readonly By CommentTextAreaLocator = By.XPath(xpathCommentTextArea);

        private const string xpathSaveButton = "//input[@id= 'submitbutton']";
        private readonly By SaveButtonLocator = By.XPath(xpathSaveButton);

        private const string xpathSuccesMessage = "//div[@id = 'leave_success_div']//div";
        private readonly By SuccesMessageLocator = By.XPath(xpathSuccesMessage);

        #endregion

        

        #region Leave Request Window Methods

        /// <summary>
        /// Method Swichs to frame of Leave Request window 
        /// </summary>
        public void SwitchToFrameOfLeaveRequestWindow()
        {
            driver.SwitchTo().Frame(commonMethods.GetElementByWithLogs(driver, LeaveRequestFrameDetailLocator, "Can NOT find rame of Leave Request window "));
            LogUtil.WriteDebug("Swiched to frame of Leave Request window ");
        }

        /// <summary>
        /// Method Swichs to default content of page 
        /// </summary>
        public void SwitchToDefaultContent()
        {
            driver.SwitchTo().DefaultContent();
            LogUtil.WriteDebug("Swiched to default content of page");
        }

        /// <summary>
        /// Method gets title of Leave Request window and returns this value
        /// </summary>
        public string GetTitleOfLeaveRequestWindow()
        {
            LogUtil.WriteDebug("Getting title of Leave Request window");
            return commonMethods.GetElementByWithLogs(driver, LeaveRequestWindowTitleLocator, "Can NOT get title of Leave Request window").Text;
        }

        /// <summary>
        /// Method gets title of Leave Request window and returns this value
        /// </summary>
        public string GetTextFromSeccessMessageOfLeaveRequestWindow()
        {
            LogUtil.WriteDebug("Getting text from success messgae of Leave Request window");
            return commonMethods.GetElementByWithLogs(driver, SuccesMessageLocator, "Can NOT get text from success messgae of Leave Request window").Text;
        }

        /// <summary>
        /// Method clicks on 'Close' button of Leave Request window 
        /// </summary>
        public void ClickCloseButtonOfLeaveRequestWindow()
        {
            commonMethods.GetElementByWithLogs(driver, CloseLeaveRequestWindowButtonLocator, "Can NOT click 'Close' button of Leave Request window ").Click();
            LogUtil.WriteDebug("Clicked on 'Close' button of Leave Request window ");
        }

        /// <summary>
        /// Method selects option in 'Staus' dropdown by value or text in Leave Request window 
        /// </summary>
        /// <param name="by"></param>
        /// <param name="value"></param>
        public void SelectOptionInStatusDropDown(SelectBy by, string value)
        {
            var dropDown = commonMethods.GetElementByWithLogs(driver, LeaveRequestStatusDropdownLocator, "Can NOT find 'Status' dropdown in Leave Request window ");
            commonMethods.SelectOptionInDropDownBy(by, dropDown, value);
            LogUtil.WriteDebug("Selected option " + value + " in 'Status' dropdown in Leave Request window ");
        }

        /// <summary>
        /// Method clicks on 'Save' button in Leave Request window
        /// </summary>
        public void ClickSaveButtonOfLeaveRequestWindow()
        {
            commonMethods.GetElementByWithLogs(driver, SaveButtonLocator, "Can NOT click 'Save' button in Leave Request window").Click();
            LogUtil.WriteDebug("Clicked on 'Save' button in Leave Request window");
        }

        /// <summary>
        /// Method fills in 'Reason' text area in Leave Request window
        /// </summary>
        public void FillInCommentTextAreaOfLeaveRequestWindow(string comment)
        {
            commonMethods.GetElementByWithLogs(driver, CommentTextAreaLocator, "Can NOT fill in 'Comment' field").SendKeys(comment);
            LogUtil.WriteDebug("Filled in 'Comment' text area in Leave Request window with data: " + comment);
        }

        #endregion
    }

}
