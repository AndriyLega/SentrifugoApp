using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using SentrifugoDev.CommonLip;
using SentrifugoDev.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentrifugoDev.PageObjects
{
    public class UserProfilePage
    {
        private IWebDriver driver;
        protected DashboardPage dashboardPage;
        protected CommonMethods commonMethods;
        protected LoginPage logInPage;

        #region User Profile Page Elements
        
        private const string xpathViewProfileTab = "//div[contains(@class,'profile-icon view-profile')]";
        private readonly By ViewProfileTabLocator = By.XPath(xpathViewProfileTab);

        private const string xpathSettingsTab = "//div[contains(@class,'profile-icon view-settings')]";
        private readonly By SettingsTabLocator = By.XPath(xpathSettingsTab);

        private const string xpathChangePasswordTab = "//div[contains(@class,'profile-icon view-password')]";
        private readonly By ChangePasswordTabLocator = By.XPath(xpathChangePasswordTab);

        private const string xpathBackToDashboardButton = "//div[@class='profile-tabs']/a";
        private readonly By BackToDashboardButtonLocator = By.XPath(xpathBackToDashboardButton);

        #endregion

        #region View Profiel Tab Elements

        private const string xpathUploadUserPhotoButton = "//div[@class='profile-tabs-right-2']//span";
        private readonly By UploadUserPhotoButtonLocator = By.XPath(xpathUploadUserPhotoButton);

        #endregion

        #region Settings Tab Elements

        private const string xpathWidgetsButton = "//div[@id='widgetsspan']";
        private readonly By WidgetsButtonLocator = By.XPath(xpathWidgetsButton);

        private const string xpathShortcutsButton = "//div[@id='shortcutspan']";
        private readonly By ShortcutsButtonLocator = By.XPath(xpathShortcutsButton);

        private const string xpathSaveButtonOfDragAndDrop = "//span[@class='save-div']/input";
        private readonly By SaveButtonOfDragAndDropLocator = By.XPath(xpathSaveButtonOfDragAndDrop);

        private const string xpathCancelButtonOfDragAndDrop = "//span[@class='cancel-div']/input";
        private readonly By CancelButtonOfDragAndDropLocator = By.XPath(xpathCancelButtonOfDragAndDrop);

        private const string xpathDragAndDropBoxForWidgets = "//div[@id='settingstab']";
        private readonly By DragAndDropBoxForWidgetsLocator = By.XPath(xpathDragAndDropBoxForWidgets);

        private const string xpathDragAndDropBoxForShortcuts = "//div[@id='shortcuticontab']";
        private readonly By DragAndDropBoxForShortcutsLocator = By.XPath(xpathDragAndDropBoxForShortcuts);

        private const string xpathDragAndDropBoxLoader = "//div[@id='loaderdragimg']";
        private readonly By DragAndDropBoxLoaderLocator = By.XPath(xpathDragAndDropBoxLoader);

        #endregion

        #region Change Password Tab  Elements

        private const string xpathCurrentPasswordField = "//input[@id='password']";
        private readonly By CurrentPasswordFieldLocator = By.XPath(xpathCurrentPasswordField);

        private const string xpathNewPasswordField = "//input[@id='newpassword']";
        private readonly By NewPasswordFieldLocator = By.XPath(xpathNewPasswordField);

        private const string xpathConfirmPasswordField = "//input[@id='passwordagain']";
        private readonly By ConfirmPasswordFieldLocator = By.XPath(xpathConfirmPasswordField);

        private const string xpathSaveButtonInChangePasswordTab = "//input[@type='submit']";
        private readonly By SaveButtonInChangePasswordTabLocator = By.XPath(xpathSaveButtonInChangePasswordTab);

        private const string xpathCancelButtonInChangePasswordTab = "//button[@id='Cancel']";
        private readonly By CancelButtonInChangePasswordTabLocator = By.XPath(xpathCancelButtonInChangePasswordTab);

        private const string xpathCurrentPasswordWarningMessage = "//span[@id='errors-password']";
        private readonly By CurrentPasswordWarningMessageLocator = By.XPath(xpathCurrentPasswordWarningMessage);

        private const string xpathNewPasswordWarningMessage = "//span[@id='errors-newpassword']";
        private readonly By NewPasswordWarningMessageLocator = By.XPath(xpathNewPasswordWarningMessage);

        private const string xpathConfirmPasswordWarningMessage = "//span[@id='errors-passwordagain']";
        private readonly By ConfirmPasswordWarningMessageLocator = By.XPath(xpathConfirmPasswordWarningMessage);

        private const string xpathChangedPasswordSuccessMessage = "//div[@id='error_message']";
        private readonly By ChangedPasswordSuccessMessageLocator = By.XPath(xpathChangedPasswordSuccessMessage);

        #endregion

        public UserProfilePage(IWebDriver driver)
        {
            this.driver = driver;
            dashboardPage = new DashboardPage(driver);
            commonMethods = new CommonMethods(driver);
        }

        #region User Profile Page Methods

        /// <summary>
        /// Method opens View Profile tab on User Profile page
        /// </summary>
        public void OpenViewProfileTab()
        {
            commonMethods.GetElementByWithLogs(driver, ViewProfileTabLocator, "Can NOT open 'View Profile' tap").Click();
            LogUtil.WriteDebug("Opened View Profile tab on User Profile page");
        }

        /// <summary>
        /// Method opens Settings tab on User Profile page
        /// </summary>
        public void OpenSettingsTab()
        {
            commonMethods.GetElementByWithLogs(driver, SettingsTabLocator, "Can NOT open 'Settings' tap").Click();
            LogUtil.WriteDebug("Opened Settings tab on User Profile page");
        }

        /// <summary>
        /// Method opens Change Password tab on User Profile page
        /// </summary>
        public void OpenChangePasswordTab()
        {
            commonMethods.GetElementByWithLogs(driver, ChangePasswordTabLocator, "Can NOT open 'Change Password' tap").Click();
            LogUtil.WriteDebug("Opened Change Password tab on User Profile page");
        }

        /// <summary>
        /// Method navigates user back to Dashboard page
        /// </summary>
        public void GoBackToDashboardPage()
        {
            commonMethods.GetElementByWithLogs(driver, BackToDashboardButtonLocator, "Can NOT go back to 'Dashboard' page").Click();
            LogUtil.WriteDebug("Returned to Dashboard page");
        }

        #endregion

        #region View Profile Tab Methods

        /// <summary>
        /// Method opens Upload Photo window
        /// </summary>
        public void OpenUploadPhotoWindow()
        {
            commonMethods.GetElementByWithLogs(driver, UploadUserPhotoButtonLocator, "Can NOT open upload photo window").Click();
            LogUtil.WriteDebug("Opened Upload Photo window");
        }

        #endregion

        #region Settings Tab Methods

        /// <summary>
        /// Method opens widgets list in the Settings tap
        /// </summary>
        public void ClickWidgetsButtonInSettingsTap()
        {
            commonMethods.GetElementByWithLogs(driver, WidgetsButtonLocator, "Can NOT click 'Widgets' button").Click();
            LogUtil.WriteDebug("Opened widgets list in the Settings tap");
        }

        /// <summary>
        /// Method opens shortcuts list in the Settings tap
        /// </summary>
        public void ClickShortcutsButtonInSettingsTap()
        {
            commonMethods.GetElementByWithLogs(driver, ShortcutsButtonLocator, "Can NOT click 'Shortcuts' button").Click();
            LogUtil.WriteDebug("Open Shortcuts list in the Settings tap");
        }

        /// <summary>
        /// Method clicks the 'Save' button at the botton of the Darg & Drop box in the Settings tap
        /// </summary>
        public void ClickSaveButtonOfDragAndDropInSettingsTap()
        {
            commonMethods.GetElementByWithLogs(driver, SaveButtonOfDragAndDropLocator, "Can NOT click 'Save' button of Darg & Drop box in the Settings").Click();
            LogUtil.WriteDebug("Clicked 'Save' button of Darg & Drop box in the Settings tap and navigated to the Dashboard page");
        }

        /// <summary>
        /// Method oclicks the 'Cancel' button at the botton of the Darg & Drop box in the Settings tap
        /// </summary>
        public void ClickCancelButtonOfDragAndDropInSettingsTap()
        {
            commonMethods.GetElementByWithLogs(driver, CancelButtonOfDragAndDropLocator, "Can NOT click 'Cancel' button of Darg & Drop box in the Settings").Click();
            LogUtil.WriteDebug("Click 'Cancel' button of Darg & Drop box in the Settings tap");
        }

        /// <summary>
        /// Method calls the action what move Widget to the Drag and Drop box on Settings tap 
        /// </summary>
        public void DragAndDropWidgetsAction(By locator)
        {
            var source = driver.FindElement(locator);
            var target = commonMethods.GetElementByWithLogs(driver, DragAndDropBoxForWidgetsLocator, "Can NOT find Drag & Drop box");
            Actions action = new Actions(driver);
            action.DragAndDrop(source, target);
            action.Build().Perform();
            LogUtil.WriteDebug("Moving Widget:" + locator + "to the Drag and Drop box on Settings tap");
        }

        /// <summary>
        /// Method calls the action what move Shortcut to the Drag and Drop box on Settings tap 
        /// </summary>
        public void DragAndDropShortcutsAction(By locator)
        {
            var source = driver.FindElement(locator);
            var target = commonMethods.GetElementByWithLogs(driver, DragAndDropBoxForShortcutsLocator, "Can NOT find Drag & Drop box");
            Actions action = new Actions(driver);
            action.DragAndDrop(source, target);
            action.Build().Perform();
            LogUtil.WriteDebug("Moving Shortcut:" + locator + "to the Drag and Drop box on Settings tap");
        }

        #endregion

        #region Change Password Tab Methods

        /// <summary>
        /// Method fills in 'Current Password' field in the ChangePasswordTab on User Profile page
        /// </summary>
        public void FillInCurrentPasswordFieldInChangePasswordTab(string currentPassword)
        {
            commonMethods.GetElementByWithLogs(driver, CurrentPasswordFieldLocator, "Can NOT fill in 'Current Password' field in Change Password tab").SendKeys(currentPassword);
            LogUtil.WriteDebug("Filled in Current password field with data:" + currentPassword);
        }

        /// <summary>
        /// Method fills in 'New Password' field in the ChangePasswordTab on User Profile page
        /// </summary>
        public void FillInNewPasswordFieldInChangePasswordTab(string newPassword)
        {
            commonMethods.GetElementByWithLogs(driver, NewPasswordFieldLocator, "Can NOT fill in 'New Password' field in Change Password tab").SendKeys(newPassword);
            LogUtil.WriteDebug("Filled in New password field with data:" + newPassword);

        }

        /// <summary>
        /// Method fills in 'Confirm Password' field in the ChangePasswordTab on User Profile page
        /// </summary>
        public void FillInConfirmPasswordFieldInChangePasswordTab(string confirmPassword)
        {
            commonMethods.GetElementByWithLogs(driver, ConfirmPasswordFieldLocator, "Can NOT fill in 'Confirm Password' field in Change Password tab").SendKeys(confirmPassword);
            LogUtil.WriteDebug("Filled in Confirm password field with data:" + confirmPassword);

        }

        /// <summary>
        /// Method clicks save button in Change password tap
        /// </summary>
        public void ClickSaveButtonInChangePasswordTab()
        {
            commonMethods.GetElementByWithLogs(driver, SaveButtonInChangePasswordTabLocator, "Can NOT click 'Save' button in Change Password tab").Click();
            LogUtil.WriteDebug("Clicked Save button in Change Password tap");
        }

        /// <summary>
        /// Method clicks cancel button in Change password tap
        /// </summary>
        public void ClickCancelButtonInChangePasswordTab()
        {
            commonMethods.GetElementByWithLogs(driver, CancelButtonInChangePasswordTabLocator, "Can NOT click 'Cancel' button in Change Password tab").Click();
            LogUtil.WriteDebug("Click Cancel button in Change password tap");
        }

        /// <summary>
        /// Method gets text from warning message for Current Password field and returns this value
        /// </summary>
        public string GetTextFromWarningMessageCurrentPasswordField()
        {
            LogUtil.WriteDebug("Getting text from warning message of Current Password field");
            return commonMethods.GetElementByWithLogs(driver, CurrentPasswordWarningMessageLocator, "Can NOT get the warning message from 'Current Password' field in Change Password tab").Text;
        }

        /// <summary>
        /// Method gets text from warning message for New Password field and returns this value
        /// </summary>
        public string GetTextFromWarningMessageNewPasswordField()
        {
            LogUtil.WriteDebug("Getting text from warning message of New Password field");
            return commonMethods.GetElementByWithLogs(driver, NewPasswordWarningMessageLocator, "Can NOT get the warning message from 'New Password' field in Change Password tab").Text;
        }

        /// <summary>
        /// Method gets text from warning message for Confirm Password field and returns this value
        /// </summary>
        public string GetTextFromWarningMessageConfirmPasswordField()
        {
            LogUtil.WriteDebug("Getting text from warning message of Confirm Password field");
            return commonMethods.GetElementByWithLogs(driver, ConfirmPasswordWarningMessageLocator, "Can NOT get the warning message from 'Confirm Password' field in Change Password tab").Text;
        }

        /// <summary>
        /// Method gets text from warning message for Confirm Password field and returns this value
        /// </summary>
        public string GetTextFromSuccessMessageOfChangedPassword()
        {
            LogUtil.WriteDebug("Getting text from success message of Changed Password ");
            return commonMethods.GetElementByWithLogs(driver, ChangedPasswordSuccessMessageLocator, "Can NOT get the succes message of Changed Password in Change Password tab").Text;

        }

        /// <summary>
        /// Method WAIT till warning message appears
        /// </summary>
        public void WaitTillWarningMessageAppears()
        {
            commonMethods.WaitForElementIsPresent(CurrentPasswordWarningMessageLocator);
            LogUtil.WriteDebug("Waiting till warning message appears");
        }

        /// <summary>
        /// Method WAIT UNTIL the loader disappeared of the Drag & Drop box
        /// </summary>
        public void WaitUntilDragAndDropBoxLoaderDisappears()
        {
            commonMethods.WaitForElementDisappears(DragAndDropBoxLoaderLocator);
            LogUtil.WriteDebug("Waiting till the loader disappeared of the Drag & Drop box");
        }

        #endregion







    }
}
