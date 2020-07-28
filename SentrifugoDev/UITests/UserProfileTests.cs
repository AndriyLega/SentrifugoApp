using NUnit.Framework;
using OpenQA.Selenium;
using SentrifugoDev.CommonLip;
using SentrifugoDev.Enums;
using SentrifugoDev.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SentrifugoDev.UITests
{
    public class UserProfileTests:BaseTest
    {
        [SetUp]
        public void LoginToSystem()
        {
            LogInToSystemWithEmployeeRole();
            header.SelectUserMenuOption(UserMenuDropDownOptions.ViewProfile);
        }

        [TearDown]
        public void LogOutFromSystem()
        {
            header.SelectUserMenuOption(UserMenuDropDownOptions.Logout);
            logInPage.WaitUntilLoginPageAppears();
        }

        [Test, Order(1), Category("UserProfile page"), Category("Settings Tab")]
        public void AddNewWidget()
        {
            userProfilePage.OpenSettingsTab();
            userProfilePage.ClickWidgetsButtonInSettingsTap();
            header.GoToAppraisalsPage();
            userProfilePage.DragAndDropWidgetsAction(By.XPath("//a[@id=161]"));
            userProfilePage.WaitUntilDragAndDropBoxLoaderDisappears();
            userProfilePage.ClickSaveButtonOfDragAndDropInSettingsTap();
            bool isNewWidgetAddedOnDashboard = commonMethods.IsElementPresent(By.XPath("//div[@class='left_dashboard']/div[contains(@class, 'dashboard')]"));
            Assert.IsTrue(isNewWidgetAddedOnDashboard, "New Widget is NOT displayed on Dashboard page");
            LogUtil.WriteDebug("Check if new Widget displayed on Dashboard page");
        }

        [Test, Order(2), Category("UserProfile page"), Category("Settings Tab")]
        public void AddNewShortcut()
        {
            userProfilePage.OpenSettingsTab();
            userProfilePage.ClickShortcutsButtonInSettingsTap();
            header.GoToAppraisalsPage();
            userProfilePage.DragAndDropShortcutsAction(By.XPath("//a[@id=174]"));
            userProfilePage.WaitUntilDragAndDropBoxLoaderDisappears();
            userProfilePage.ClickSaveButtonOfDragAndDropInSettingsTap();
            bool isNewShortcutAddedOnDashboard = commonMethods.IsElementPresent(By.XPath("//div[@class='shortcuts']//a"));
            LogUtil.WriteDebug("Check if new Shortcut displayed on Dashboard page");
            Assert.IsTrue(isNewShortcutAddedOnDashboard, "New Shortcut is NOT displayed on Dashboard page");
        }

        [Test, Order(3), Category("UserProfile page"), Category("Change Password Tab")]
        public void AreCurrentNewAndConfirmPasswordFieldsRequired()
        {
            userProfilePage.OpenChangePasswordTab();
            userProfilePage.ClickSaveButtonInChangePasswordTab();
            pageBlockers.WaitTillPageUIBlockerDisappeared();
            string warningMessageCurrentPasswordField = userProfilePage.GetTextFromWarningMessageCurrentPasswordField();
            string warningMessageNewPasswordField = userProfilePage.GetTextFromWarningMessageNewPasswordField();
            string warningMessageConfirmPasswordField = userProfilePage.GetTextFromWarningMessageConfirmPasswordField();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(warningMessageCurrentPasswordField.Equals(userProfileModel.EmptyCurrentPasswordWarningMessage), "Warning message is NOT correct. Actual result: "
                + warningMessageCurrentPasswordField + "  Expected result: " + userProfileModel.EmptyCurrentPasswordWarningMessage);
                Assert.IsTrue(warningMessageNewPasswordField.Equals(userProfileModel.EmptyNewPasswordWarningMessage), "Warning message is NOT correct. Actual result: "
                + warningMessageNewPasswordField + "  Expected result: " + userProfileModel.EmptyNewPasswordWarningMessage);
                Assert.IsTrue(warningMessageConfirmPasswordField.Equals(userProfileModel.EmptyConfirmPasswordWarningMessage), "Warning message is NOT correct. Actual result: "
                + warningMessageConfirmPasswordField + "  Expected result: " + userProfileModel.EmptyConfirmPasswordWarningMessage);
            });

        }

        [Test, Order(4), Category("UserProfile page"), Category("Change Password Tab")]
        public void CheckValidationOfChangePasswordForm()
        {
            userProfilePage.OpenChangePasswordTab();
            userProfilePage.FillInCurrentPasswordFieldInChangePasswordTab(userProfileModel.IncorrectCurrentPassword);
            userProfilePage.FillInNewPasswordFieldInChangePasswordTab(userProfileModel.InvalidNewPassword);
            userProfilePage.FillInConfirmPasswordFieldInChangePasswordTab(userProfileModel.InvalidConfirmPassword);
            userProfilePage.ClickSaveButtonInChangePasswordTab();
            pageBlockers.WaitTillPageUIBlockerDisappeared();
            string warningMessageCurrentPasswordField = userProfilePage.GetTextFromWarningMessageCurrentPasswordField();
            string warningMessageNewPasswordField = userProfilePage.GetTextFromWarningMessageNewPasswordField();
            string warningMessageConfirmPasswordField = userProfilePage.GetTextFromWarningMessageConfirmPasswordField();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(warningMessageCurrentPasswordField.Equals(userProfileModel.IncorrectCurrentPasswordWarningMessage), "Warning message is NOT correct. Actual result: "
                + warningMessageCurrentPasswordField + "  Expected result: " + userProfileModel.IncorrectCurrentPasswordWarningMessage);
                Assert.IsTrue(warningMessageNewPasswordField.Equals(userProfileModel.InvaildNewPasswordWarningMessage), "Warning message is NOT correct. Actual result: "
                + warningMessageNewPasswordField + "  Expected result: " + userProfileModel.InvaildNewPasswordWarningMessage);
                Assert.IsTrue(warningMessageConfirmPasswordField.Equals(userProfileModel.InvaildConfirmPasswordWarningMessage), "Warning message is NOT correct. Actual result: "
                + warningMessageConfirmPasswordField + "  Expected result: " + userProfileModel.InvaildConfirmPasswordWarningMessage);
            });
        }

        [Test, Order(5), Category("UserProfile page"), Category("Change Password Tab")]
        public void CheckNOTMatchValidationOfChangePasswordForm()
        {
            userProfilePage.OpenChangePasswordTab();
            userProfilePage.FillInCurrentPasswordFieldInChangePasswordTab(userProfileModel.CorrectCurrentPassword);
            userProfilePage.FillInNewPasswordFieldInChangePasswordTab(userProfileModel.ValidNewPassword);
            userProfilePage.FillInConfirmPasswordFieldInChangePasswordTab(userProfileModel.IncorrectConfirmPassword);
            userProfilePage.ClickSaveButtonInChangePasswordTab();
            pageBlockers.WaitTillPageUIBlockerDisappeared();
            string warningMessageConfirmPasswordField = userProfilePage.GetTextFromWarningMessageConfirmPasswordField();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(warningMessageConfirmPasswordField.Equals(userProfileModel.NotMatchConfirmPasswordWarningMessage), "Warning message is NOT correct. Actual result: "
                + warningMessageConfirmPasswordField + "  Expected result: " + userProfileModel.NotMatchConfirmPasswordWarningMessage);
            });
        }

        [Test, Order(6), Category("UserProfile page"), Category("Change Password Tab")]
        public void CheckValidationOfDifferentPassword()
        {
            userProfilePage.OpenChangePasswordTab();
            userProfilePage.FillInCurrentPasswordFieldInChangePasswordTab(userProfileModel.CorrectCurrentPassword);
            userProfilePage.FillInNewPasswordFieldInChangePasswordTab(userProfileModel.CorrectCurrentPassword);
            userProfilePage.FillInConfirmPasswordFieldInChangePasswordTab(userProfileModel.CorrectCurrentPassword);
            userProfilePage.ClickSaveButtonInChangePasswordTab();
            pageBlockers.WaitTillPageUIBlockerDisappeared();
            string warningMessageNewPasswordField = userProfilePage.GetTextFromWarningMessageNewPasswordField();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(warningMessageNewPasswordField.Equals(userProfileModel.SameCurrentAndNewPasswordWarningMessage), "Warning message is NOT correct. Actual result: "
                + warningMessageNewPasswordField + "  Expected result: " + userProfileModel.SameCurrentAndNewPasswordWarningMessage);
            });
        }

        [Test, Order(7), Category("UserProfile page"), Category("Change Password Tab")]
        public void CheckValidationOfLengthPassword()
        {
            userProfilePage.OpenChangePasswordTab();
            userProfilePage.FillInCurrentPasswordFieldInChangePasswordTab(userProfileModel.CorrectCurrentPassword);
            userProfilePage.FillInNewPasswordFieldInChangePasswordTab(userProfileModel.ShortPassword);
            userProfilePage.FillInConfirmPasswordFieldInChangePasswordTab(userProfileModel.ShortPassword);
            userProfilePage.ClickSaveButtonInChangePasswordTab();
            pageBlockers.WaitTillPageUIBlockerDisappeared();
            string warningMessageNewPasswordField = userProfilePage.GetTextFromWarningMessageNewPasswordField();
            string warningMessageConfirmPasswordField = userProfilePage.GetTextFromWarningMessageConfirmPasswordField();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(warningMessageNewPasswordField.Equals(userProfileModel.ShortNewPasswordWarningMessage), "Warning message is NOT correct. Actual result: "
                + warningMessageNewPasswordField + "  Expected result: " + userProfileModel.ShortNewPasswordWarningMessage);
                Assert.IsTrue(warningMessageConfirmPasswordField.Equals(userProfileModel.ShortConfirmPasswordWarningMessage), "Warning message is NOT correct. Actual result: "
                + warningMessageConfirmPasswordField + "  Expected result: " + userProfileModel.ShortConfirmPasswordWarningMessage);
            });
        }

        [Test, Order(8), Category("UserProfile page"), Category("Change Password Tab")]
        public void CheckSuccessChangePassword()
        {
            userProfilePage.OpenChangePasswordTab();
            userProfilePage.FillInCurrentPasswordFieldInChangePasswordTab(userProfileModel.CorrectCurrentPassword);
            userProfilePage.FillInNewPasswordFieldInChangePasswordTab(userProfileModel.ValidNewPassword);
            userProfilePage.FillInConfirmPasswordFieldInChangePasswordTab(userProfileModel.ValidConfirmPassword);
            userProfilePage.ClickSaveButtonInChangePasswordTab();
            pageBlockers.WaitTillPageUIBlockerDisappeared();
            string successMessageOfChangedPassword = userProfilePage.GetTextFromSuccessMessageOfChangedPassword();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(successMessageOfChangedPassword.Equals(userProfileModel.SuccessMessageOfChangedPassword), "Warning message is NOT correct. Actual result: "
                + successMessageOfChangedPassword + "  Expected result: " + userProfileModel.SuccessMessageOfChangedPassword);
            });
        }
    }
}
