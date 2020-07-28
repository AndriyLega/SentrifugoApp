using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SentrifugoDev.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SentrifugoDev.UITests
{
    public class LogInPageTests:BaseTest
    {
        /// <summary>
        /// This test checks if Email field is required
        /// </summary>
        [Test, Order(1), Category("Login page"), Category("Login Form")]
        public void CheckIfEmailFieldIsRequired()
        {
            logInPage.FillInPasswordField(loginModel.ValidPassword);
            logInPage.ClickOnLogInButton();
            string warningMessageEmailField = logInPage.GetTextFromWarningMessageEmailField();
            Assert.IsTrue(warningMessageEmailField.Equals(loginModel.EmptyEmailWarningMessage), "Warning message is NOT correct. Actual result: "
                + warningMessageEmailField + "  Expected result: " + loginModel.EmptyEmailWarningMessage);
        }

        /// <summary>
        /// This test checks if Password field is required
        /// </summary>
        [Test, Order(2), Category("Login page"), Category("Login Form")]
        public void CheckIFPasswordFieldIsRequired()
        {
            logInPage.FillInEmailField(loginModel.ValidUserName);
            logInPage.ClickOnLogInButton();
            string warningMessagePasswordField = logInPage.GetTextFromWarningMessagePasswordField();
            Assert.IsTrue(warningMessagePasswordField.Equals(loginModel.EmptyPasswordWarningMessage), "Warning message is NOT correct. Actual result: "
                + warningMessagePasswordField + "  Expected result: " + loginModel.EmptyPasswordWarningMessage);
        }

        /// <summary>
        /// This test checks validation of Email field 
        /// </summary>
        [Test, Order(3), Category("Login page"), Category("Login Form")]
        [TestCase("emp002")]
        [TestCase("@gmail.com")]
        [TestCase("test@gmail.")]
        [TestCase("test@gmailcom")]
        [TestCase("testgmail.com")]
        public void CheckValidationOfEmailField(string invalidEmail)
        {
            logInPage.FillInEmailField(invalidEmail);
            logInPage.FillInPasswordField(loginModel.ValidPassword);
            logInPage.ClickOnLogInButton();
            string warningMessageOfIncorrectCreds = logInPage.GetTextFromWarningMessageOfIncorrectCreds();
            Assert.IsTrue(warningMessageOfIncorrectCreds.Equals(loginModel.IncorrectCredsWarningMessage), "Warning message is NOT correct. Actual result: "
                + warningMessageOfIncorrectCreds + "  Expected result: " + loginModel.IncorrectCredsWarningMessage);
        }

        /// <summary>
        /// This test checks validation of Password field 
        /// </summary>
        [Test, Order(4), Category("Login page"), Category("Login Form")]
        [TestCase("123@#$")]
        [TestCase("qwe@#$")]
        [TestCase("qwe123")]
        [TestCase("Qw12@")]
        public void CheckValidationOfPasswordField(string invalidPassword)
        {
            logInPage.FillInEmailField(loginModel.ValidUserName);
            logInPage.FillInPasswordField(invalidPassword);
            logInPage.ClickOnLogInButton();
            string warningMessageOfIncorrectCreds = logInPage.GetTextFromWarningMessageOfIncorrectCreds();
            Assert.IsTrue(warningMessageOfIncorrectCreds.Equals(loginModel.IncorrectCredsWarningMessage), "Warning message is NOT correct. Actual result: "
                + warningMessageOfIncorrectCreds + "  Expected result: " + loginModel.IncorrectCredsWarningMessage);
        }

        /// <summary>
        /// This test checks if it is ppossible to log In to system
        /// </summary>
        [Test, Order(5), Category("Login page"), Category("Login Form")]
        public void CheckSuccessfulLogIn()
        {
            logInPage.FillInEmailField(loginModel.ValidUserName);
            logInPage.FillInPasswordField(loginModel.ValidPassword);
            logInPage.ClickOnLogInButton();
            header.WaitUntilHomePageAppears();
            bool isUserProfileMenuPresent = header.IsUserProfileMenuPresent();

            Assert.Multiple(() =>
            {
                //Assert.IsTrue(successMessage.Equals("Successfully logged in"), "Warning message is NOT correct. Actual result: " + successMessage + "  Expected result: Successfully logged in");
                Assert.IsTrue(isUserProfileMenuPresent, "The User menu  is NOT displayed in the header on Home page");
            });
        }

        /// <summary>
        /// This test checks if Forgot password  form appears 
        /// </summary>
        [Test, Order(6), Category("Login page"), Category("Forgot Password Form")]
        public void CheckIfForgotPasswordFormAppears()
        {
            logInPage.ClickOnForgotPasswordLink();
            bool isForgotPasswordFormAppeared = logInPage.IsForgotPasswordFormAppeared();
            Assert.IsTrue(isForgotPasswordFormAppeared, "The 'Forgot Password' form is NOT appeared on LogIn page");
        }

        /// <summary>
        /// This test checks if Forgot password form has Email field and 'Send password' button 
        /// </summary>
        [Test, Order(7), Category("Login page"), Category("Forgot Password Form")]
        public void AreEmailFieldAndSendPasswordButtonPresent()
        {
            logInPage.ClickOnForgotPasswordLink();
            bool isEmailFieldInForgotPasswordFormPresent = logInPage.IsEmailFieldInForgotPasswordFormPresent();
            bool isSendPasswordButtonInForgotPasswordFormPresent = logInPage.IsSendPasswordButtonInForgotPasswordFormPresent();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(isEmailFieldInForgotPasswordFormPresent, "The 'Email' field in 'Forgot Password' form is NOT present on LogIn page");
                Assert.IsTrue(isSendPasswordButtonInForgotPasswordFormPresent, "The 'Send Password' button in 'Forgot Password' form is NOT present on LogIn page");
            });
  
        }

        /// <summary>
        /// This test checks if the Email field in Forgot password form is required 
        /// </summary>
        [Test, Order(8), Category("Login page"), Category("Forgot Password Form")]
        public void CheckIFEmailFieldIsRequiredInForgotPasswordForm()
        {
            logInPage.ClickOnForgotPasswordLink();
            logInPage.ClickOnSendPasswordButtonInForgotPasswordForm();
            string errorMessageEmailFieldInForgotPasswordForm = logInPage.GetTextFromErrorMessageEmailFieldInForgotPasswordForm();
            Assert.IsTrue(errorMessageEmailFieldInForgotPasswordForm.Equals(loginModel.EmptyEmailWarningMessageInForgotPasswordForm), "Warning message is NOT correct. Actual result: "
                + errorMessageEmailFieldInForgotPasswordForm + "  Expected result: " + loginModel.EmptyEmailWarningMessageInForgotPasswordForm);
        }

        /// <summary>
        /// This test checks validation of invalid Email in Forgot Password form 
        /// </summary>
        [Test, Order(9), Category("Login page"), Category("Forgot Password Form")]
        [TestCase("@gmail.com")]
        [TestCase("test@gmail.")]
        [TestCase("test@gmailcom")]
        [TestCase("testgmail.com")]
        public void CheckValidationOfEmailFieldInForgotPasswordForm(string invalidEmail)
        {
            logInPage.ClickOnForgotPasswordLink();
            logInPage.FillInEmailFieldInForgotPasswordForm(invalidEmail);
            logInPage.ClickOnSendPasswordButtonInForgotPasswordForm();
            string errorMessageEmailFieldInForgotPasswordForm = logInPage.GetTextFromErrorMessageEmailFieldInForgotPasswordForm();
            Assert.IsTrue(errorMessageEmailFieldInForgotPasswordForm.Equals(loginModel.InvalidEmailWarningMessageInForgotPasswordFform), "Warning message is NOT correct. Actual result: "
                + errorMessageEmailFieldInForgotPasswordForm + "  Expected result: " + loginModel.InvalidEmailWarningMessageInForgotPasswordFform);
        }

        /// <summary>
        /// This test checks validation of NOT exist Email in Forgot Password form 
        /// </summary>
        [Test, Order(10), Category("Login page"), Category("Forgot Password Form")]
        public void CheckNOTExistEmailValidationOfEmailFieldInForgotPasswordForm()
        {
            logInPage.ClickOnForgotPasswordLink();
            logInPage.FillInEmailFieldInForgotPasswordForm(loginModel.NotExistEmail);
            logInPage.ClickOnSendPasswordButtonInForgotPasswordForm();
            logInPage.WaitUntilErrorMessageAppearsInForgotPasswordForm();
            string errorMessageEmailFieldInForgotPasswordForm = logInPage.GetTextFromErrorMessageEmailFieldInForgotPasswordForm();
            Assert.IsTrue(errorMessageEmailFieldInForgotPasswordForm.Equals(loginModel.NotExistEmailWarningMessageInForgotPasswordForm), "Warning message is NOT correct. Actual result: "
                + errorMessageEmailFieldInForgotPasswordForm + "  Expected result: " + loginModel.NotExistEmailWarningMessageInForgotPasswordForm);
        }

        /// <summary>
        /// This test checks successful send of new password 
        /// </summary>
        [Test, Order(11), Category("Login page"), Category("Forgot Password Form")]
        public void CheckSuccessfulResendPassword()
        {
            logInPage.ClickOnForgotPasswordLink();
            logInPage.FillInEmailFieldInForgotPasswordForm(loginModel.ValidEmail);
            logInPage.ClickOnSendPasswordButtonInForgotPasswordForm();
            logInPage.WaitTillNewPasswordSends();
            string successMessageEmailFieldInForgotPasswordForm = logInPage.GetTextFromSuccessMessageEmailFieldInForgotPasswordForm();
            Assert.IsTrue(successMessageEmailFieldInForgotPasswordForm.Equals(loginModel.SuccessSendPasswordMessage), "Warning message is NOT correct. Actual result: "
                + successMessageEmailFieldInForgotPasswordForm + "  Expected result: " + loginModel.SuccessSendPasswordMessage);
        }

        /// <summary>
        /// This test checks corretly work of Help button 
        /// </summary>
        [Test, Order(12), Category("Login page")]
        public void CheckThatHelpButtonWorksCorrectly()
        {
            logInPage.ClickOnHelpButton();
            var browserTabs = new List<string>(driver.WindowHandles);
            var newTab = browserTabs[1];
            string currentUrl = driver.SwitchTo().Window(newTab).Url;
            Assert.IsTrue(currentUrl.Equals(loginModel.GetingStartedPdfFile), "Url of Getting Started file is NOT correct. Actual result: "
                + currentUrl + "  Expected result: " + loginModel.GetingStartedPdfFile);
        }
    }
}

