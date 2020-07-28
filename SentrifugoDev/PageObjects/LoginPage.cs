using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SentrifugoDev.CommonLip;
using SentrifugoDev.Models;
using SentrifugoDev.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentrifugoDev.PageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;
        protected DashboardPage dashboardPage;
        protected CommonMethods commonMethods;
        protected Header header;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            dashboardPage = new DashboardPage(driver);
            commonMethods = new CommonMethods(driver);
            header = new Header(driver);
        }


        private const string xpathHelpButton = "//a[@id='abouttab']";
        private readonly By HelpButtonLocator = By.XPath(xpathHelpButton);

        #region LogIn Form Elements

        private const string xpathLogInForm = "//div[@class='fltleft fullwidth']";
        private readonly By LogInFormLocator = By.XPath(xpathLogInForm);

        private const string xpathEmailField = "//input[@id='username']";
        private readonly By EmailFieldLocator = By.XPath(xpathEmailField);

        private const string xpathPasswordField = "//input[@id='password']";
        private readonly By PasswordFieldLocator = By.XPath(xpathPasswordField);

        private const string xpathLogInButton = "//input[@type='submit']";
        private readonly By LogInButtonLocator = By.XPath(xpathLogInButton);

        private const string xpathEmailWarningMessage = "//div[@class='login-fields'][1]//div[@id='usernameerror']";
        private readonly By EmailWarningMessageLocator = By.XPath(xpathEmailWarningMessage);

        private const string xpathPasswordWarningMessage = "//div[@class='login-fields'][2]//div[@id='usernameerror'or @id='pwderror']";
        private readonly By PasswordWarningMessageLocator = By.XPath(xpathPasswordWarningMessage);

        private const string xpathIncorrectCredsWarningMessage = "//div[@class='login-fields'][2]//div[@id='usernameerror']";
        private readonly By IncorrectCredsWarningMessageLocator = By.XPath(xpathIncorrectCredsWarningMessage);

        #endregion

        #region Forgot Password Form Elements

        private const string xpathForgotPasswordLink = "//a[@id='forgotpwdtext']";
        private readonly By ForgotPasswordLinkLocator = By.XPath(xpathForgotPasswordLink);

        private const string xpathForgotPasswordForm = "//div[@id='forgotpassworddiv']";
        private readonly By ForgotPasswordFormLocator = By.XPath(xpathForgotPasswordForm);

        private const string xpathEmailFieldInForgotPasswordForm = "//input[@id='emailaddress']";
        private readonly By EmailFieldInForgotPasswordFormLocator = By.XPath(xpathEmailFieldInForgotPasswordForm);

        private const string xpathSendPasswordButton = "//input[@id='forgotpwdbutton']";
        private readonly By SendPasswordButtonLocator = By.XPath(xpathSendPasswordButton);

        private const string xpathEmailFieldWarningMessageInForgotPasswordForm = "//div[@id='forgot_error_message']";
        private readonly By EmailFieldWarningMessageInForgotPasswordFormLocator = By.XPath(xpathEmailFieldWarningMessageInForgotPasswordForm);

        private const string xpathEmailFieldSuccessMessageInForgotPasswordForm = "//div[@id='forgot_succ_message']";
        private readonly By SuccessMessageInForgotPasswordFormLocator = By.XPath(xpathEmailFieldSuccessMessageInForgotPasswordForm);
        #endregion

        #region Login Form Methods

        /// <summary>
        /// Method WAITS UNTIL Login page appears (commit)
        /// </summary>
        public void WaitUntilLoginPageAppears()
        {
            commonMethods.GetElementByWithLogs(driver, LogInFormLocator, "Login page is NOT opened");
            LogUtil.WriteDebug("Waiting for Login page");
        }

        /// <summary>
        /// Method clicks on 'Log In' button on LogIn page
        /// </summary>
        public void ClickOnLogInButton()
        {
            commonMethods.GetElementByWithLogs(driver, LogInButtonLocator, "Can NOT click on 'Log In' button").Click();
            LogUtil.WriteDebug("Clicked on Login button");
        }

        /// <summary>
        /// Method fills in 'Email' field
        /// </summary>
        public void FillInEmailField(string emailValue)
        {
            commonMethods.GetElementByWithLogs(driver, EmailFieldLocator, "Can NOT fill in 'Email' field").SendKeys(emailValue);
            LogUtil.WriteDebug("Filled in Email field with data:" + emailValue);
        }

        /// <summary>
        /// Method fills in 'Password' field
        /// </summary>
        public void FillInPasswordField(string paswordValue)
        {
            commonMethods.GetElementByWithLogs(driver, PasswordFieldLocator, "Can NOT fill in 'Password' field").SendKeys(paswordValue);
            LogUtil.WriteDebug("Filled in Password field with data:" + paswordValue);
        }

        /// <summary>
        /// Method gets text from warning message for Email field and returns this value
        /// </summary>
        public string GetTextFromWarningMessageEmailField()
        {
            LogUtil.WriteDebug("Getting text from warning message from Email field");
            return commonMethods.GetElementByWithLogs(driver, EmailWarningMessageLocator, "Can NOT get the warning message from 'Email' field").Text; 
        }

        /// <summary>
        /// Method gets text from warning message for Password field and returns this value
        /// </summary>
        public string GetTextFromWarningMessagePasswordField()
        {
            LogUtil.WriteDebug("Getting text from warning message from Password field");
            return commonMethods.GetElementByWithLogs(driver, PasswordWarningMessageLocator, "Can NOT get the warning message from 'Password' field").Text;
        }

        /// <summary>
        /// Method gets text from warning message about incorrect Username or Password and returns this value
        /// </summary>
        public string GetTextFromWarningMessageOfIncorrectCreds()
        {
            LogUtil.WriteDebug("Getting text from warning message of incorrect creds");
            return commonMethods.GetElementByWithLogs(driver, IncorrectCredsWarningMessageLocator, "Can NOT get the warning message of incorrect creds").Text;
        }

        /// <summary>
        /// Method clicks on 'Help' button on LogIn page
        /// </summary>
        public void ClickOnHelpButton()
        {
            commonMethods.GetElementByWithLogs(driver, HelpButtonLocator, "Can NOT click on 'Help' button").Click();
            LogUtil.WriteDebug("Clicked on Help button");
        }

        #endregion

        #region Forgot Password From Mehtods

        /// <summary>
        /// Method clicks on 'Forgot Password?' link on LogIn page
        /// </summary>
        public void ClickOnForgotPasswordLink()
        {
            commonMethods.GetElementByWithLogs(driver, ForgotPasswordLinkLocator, "Can NOT click on 'ForgotPassword' link").Click();
            LogUtil.WriteDebug("Clicked on Forgot Password Link");
        }

        /// <summary>
        /// Method checks if the forgot password form is appeared
        /// </summary>
        public bool IsForgotPasswordFormAppeared()
        {
            LogUtil.WriteDebug("Checks if the forgot password form is appeared");
            return commonMethods.IsElementPresent(ForgotPasswordFormLocator);
        }

        /// <summary>
        /// Method checks if Email field in Forgot Password form is present
        /// </summary>
        public bool IsEmailFieldInForgotPasswordFormPresent()
        {
            LogUtil.WriteDebug("Checks if Email field in Forgot Password form is present");
            return commonMethods.IsElementPresent(EmailFieldInForgotPasswordFormLocator);
        }

        /// <summary>
        /// Method checks if Send Password button in Forgot Password form is present
        /// </summary>
        public bool IsSendPasswordButtonInForgotPasswordFormPresent()
        {
            LogUtil.WriteDebug("Checks if Send Password button in Forgot Password form is present");
            return commonMethods.IsElementPresent(SendPasswordButtonLocator);
        }

        /// <summary>
        /// Method fills in 'Email' field in the Forgot Password Form
        /// </summary>
        public void FillInEmailFieldInForgotPasswordForm(string emailValue)
        {
            commonMethods.GetElementByWithLogs(driver, EmailFieldInForgotPasswordFormLocator, "Can NOT fill in 'Email' field").SendKeys(emailValue);
            LogUtil.WriteDebug("Filled in Email field in Forgot password form with data:" + emailValue);
        }

        /// <summary>
        /// Method clicks on 'Send Password' button in Forgot Password form on LogIn page
        /// </summary>
        public void ClickOnSendPasswordButtonInForgotPasswordForm()
        {
            commonMethods.GetElementByWithLogs(driver, SendPasswordButtonLocator, "Can NOT click on 'Send Password' button").Click();
            LogUtil.WriteDebug("Clicked on Send Password button in the Forgot Password Form");
        }

        /// <summary>
        /// Method gets text from error message for Email field in the Forgot Password form and returns this value
        /// </summary>
        public string GetTextFromErrorMessageEmailFieldInForgotPasswordForm()
        {
            LogUtil.WriteDebug("Getting text from error message from Email field in the Forgot Password form");
            return commonMethods.GetElementByWithLogs(driver, EmailFieldWarningMessageInForgotPasswordFormLocator, "Can NOT get text from warning message from 'Email' field in Forgot Password form").Text;
        }

        /// <summary>
        /// Method gets text from success message for Email field in the Forgot Password form and returns this value
        /// </summary>
        public string GetTextFromSuccessMessageEmailFieldInForgotPasswordForm()
        {
            LogUtil.WriteDebug("Getting text from success message of the Forgot Password");
            return commonMethods.GetElementByWithLogs(driver, SuccessMessageInForgotPasswordFormLocator, "Can NOT get text from success message of Forgot Password form").Text;
        }

        /// <summary>
        /// Method WAIT till the new password is sending  in Forgot Password form
        /// </summary>
        public void WaitTillNewPasswordSends()
        {
            commonMethods.GetElementByWithLogs(driver, SuccessMessageInForgotPasswordFormLocator, "New password did NOT send", 20);
            LogUtil.WriteDebug("Waiting till the new password is sending ");
        }

        /// <summary>
        /// Method WAIT UNTIL the error message appears in the Forgot Password form
        /// </summary>
        public void WaitUntilErrorMessageAppearsInForgotPasswordForm()
        {
            commonMethods.GetElementByWithLogs(driver, EmailFieldWarningMessageInForgotPasswordFormLocator, "Warning message od Email field in Forgot Password form did NOT appear");
            LogUtil.WriteDebug("Waiting till the error message appears in the Forgot Password form");
        }

        #endregion
    }

}
