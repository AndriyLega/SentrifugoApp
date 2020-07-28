using NUnit.Framework;
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
    public class AppliedLeavePage
    {
        private IWebDriver driver;
        protected CommonMethods commonMethods;

        public AppliedLeavePage(IWebDriver driver)
        {
            this.driver = driver;
            commonMethods = new CommonMethods(driver);
        }

        #region Applied Leave Page Elements

        private const string xpathAppliedLeaveDataTable = "//div[@class = 'main_view']";
        private readonly By AppliedLeaveDataTableLocator = By.XPath(xpathAppliedLeaveDataTable);

        private const string xpathFieldsNamesOfAppliedLeave = "//div[@class = 'main_view']//div[@class = 'width_20']//label";
        private readonly By FieldsNamesOfAppliedLeaveLocator = By.XPath(xpathFieldsNamesOfAppliedLeave);

        private const string xpathFieldsDataOfAppliedLeave = "//div[@class = 'main_view']//div[@class = 'width_80']//label";
        private readonly By FieldsDataOfAppliedLeaveLocator = By.XPath(xpathFieldsDataOfAppliedLeave);

        private const string xpathLeaveRequestHistoryOfAppliedLeave = "//div[@class = 'history-flow']//span";
        private readonly By LeaveRequestHistoryOfAppliedLeaveLocator = By.XPath(xpathLeaveRequestHistoryOfAppliedLeave);

        private const string xpathLeaveRequestStatusDropdown = "//select[@id= 'managerstatus']";
        private readonly By AppliedLeaveStatusDropdownLocator = By.XPath(xpathLeaveRequestStatusDropdown);

        private const string xpathCommentTextArea = "//textarea";
        private readonly By CommentTextAreaLocator = By.XPath(xpathCommentTextArea);

        private const string xpathSaveButton = "//input[@id = 'submitbutton']";
        private readonly By SaveButtonLocator = By.XPath(xpathSaveButton);

        private const string xpathCancelButton = "//button[@id = 'Cancel']";
        private readonly By CancelButtonLocator = By.XPath(xpathCancelButton);

        #endregion

        #region Applied Leave Page Methods

        /// <summary>
        /// Method checks if the Applied leave page opened
        /// </summary>
        public bool IsAppliedLeavePageOpened()
        {
            bool pageOpened = commonMethods.IsElementPresent(AppliedLeaveDataTableLocator);
            return pageOpened;
        }

        /// <summary>
        /// Method gets fields names datalist of Applied leave
        /// </summary>
        public List<string> GetFieldsNamesListOfAppliedLeave()
        {
            List<string> listOfFieldsNames = new List<string>();
            var listOfFieldsNamesElements = driver.FindElements(FieldsNamesOfAppliedLeaveLocator);
            for (int k = 0; k < listOfFieldsNamesElements.Count; k++)
            {
                listOfFieldsNames.Add(listOfFieldsNamesElements[k].Text);
            }
            LogUtil.WriteDebug("Got the list of all fields names of applied leave");
            return listOfFieldsNames;
        }

        /// <summary>
        /// Method gets fields data datalist of Applied leave
        /// </summary>
        public List<string> GetFieldsDataListOfAppliedLeave()
        {
            List<string> listOfFieldsData = new List<string>();
            var listOfFieldsDataElements = driver.FindElements(FieldsDataOfAppliedLeaveLocator);
            for (int k = 0; k < listOfFieldsDataElements.Count; k++)
            {
                listOfFieldsData.Add(listOfFieldsDataElements[k].Text);
            }
            LogUtil.WriteDebug("Got the list of all fields names of applied leave");
            return listOfFieldsData;
        }

        /// <summary>
        /// Method gets history flow datalist of Applied leave
        /// </summary>
        public List<string> GetHistoryFlowListOfAppliedLeave()
        {
            List<string> listOfHidtoryFlow = new List<string>();
            var listOfHistoryFlowElements = driver.FindElements(LeaveRequestHistoryOfAppliedLeaveLocator);
            for (int k = 0; k < listOfHistoryFlowElements.Count; k++)
            {
                listOfHidtoryFlow.Add(listOfHistoryFlowElements[k].Text);
            }
            LogUtil.WriteDebug("Got the list of hispory flow of applied leave");
            return listOfHidtoryFlow;
        }

        /// <summary>
        /// Method selects option in 'Staus' dropdown by value or text on Applied Leave page
        /// </summary>
        /// <param name="by"></param>
        /// <param name="value"></param>
        public void SelectOptionInStatusDropDownOfAppliedLeave(SelectBy by, string value)
        {
            var dropDown = commonMethods.GetElementByWithLogs(driver, AppliedLeaveStatusDropdownLocator, "Can NOT find 'Status' dropdown on Applied Leave page");
            commonMethods.SelectOptionInDropDownBy(by, dropDown, value);
            LogUtil.WriteDebug("Selected option " + value + " in 'Status' dropdown on Applied Leave page ");
        }

        /// <summary>
        /// Method clicks on 'Save' button on Applied Leave page
        /// </summary>
        public void ClickSaveButtonOfAppliedLeave()
        {
            commonMethods.GetElementByWithLogs(driver, SaveButtonLocator, "Can NOT click 'Save' button on Applied Leave page").Click();
            LogUtil.WriteDebug("Clicked on 'Save' button on Applied Leave page");
        }

        /// <summary>
        /// Method clicks on 'Cancel' button on Applied Leave page
        /// </summary>
        public void ClickCancelButtonOfAppliedLeave()
        {
            commonMethods.GetElementByWithLogs(driver, CancelButtonLocator, "Can NOT click 'Cancel' button on Applied Leave page").Click();
            LogUtil.WriteDebug("Clicked on 'cancel' button on Applied Leave page");
        }

        /// <summary>
        /// Method fills in 'Comment' text area on Applied Leave page
        /// </summary>
        public void FillInCommentTextAreaOfAppliedLeave(string comment)
        {
            commonMethods.GetElementByWithLogs(driver, CommentTextAreaLocator, "Can NOT fill in 'Comment' field").SendKeys(comment);
            LogUtil.WriteDebug("Filled in 'Comment' text area on Applied Leave page with data: " + comment);
        }

        #endregion
    }
}
