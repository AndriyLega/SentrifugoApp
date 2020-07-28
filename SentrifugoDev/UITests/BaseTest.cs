using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SentrifugoDev.CommonLip;
using SentrifugoDev.Models;
using SentrifugoDev.PageObjects;
using SentrifugoDev.PageObjects.SelfServicePageFolder;
using System;
using System.IO;
using static SentrifugoDev.CommonLip.CommonMethods;

namespace SentrifugoDev.PageObjects
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected LoginPage logInPage;
        protected CommonMethods commonMethods;
        protected DashboardPage dashboardPage;
        protected Header header;
        protected LoginPageModel loginModel;
        protected UserProfilePage userProfilePage;
        protected UserProfileModel userProfileModel;
        protected LeaveRequestTabModel leaveRequesrTabModel;
        protected SelfServicePage selfServicePage;
        protected TablePlugin tablePlugin;
        protected DatePickerCalendarPlugin datePickerCalendarPlugine;
        protected PageBlockers pageBlockers;
        private string pathLog = string.Format("{0}{1}{2}{3}{4}", "PharmacyApp", DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, ".log");

        [SetUp]
        protected void Initialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = loginModel.SentrifugoDev;
        
            logInPage = new LoginPage(driver);
            commonMethods = new CommonMethods(driver);
            dashboardPage = new DashboardPage(driver);
            userProfilePage = new UserProfilePage(driver);
            selfServicePage = new SelfServicePage(driver);
            datePickerCalendarPlugine = new DatePickerCalendarPlugin(driver);
            tablePlugin = new TablePlugin(driver);
            header = new Header(driver);
            pageBlockers = new PageBlockers(driver);
            LogUtil.WriteDebug("**********Starting execution of a new test**********");
            LogUtil.WriteDebug("Opened Chrome browser");
            LogUtil.WriteDebug("Navigating to " + loginModel.SentrifugoDev);

        }

        [OneTimeSetUp]
        public void ReadDataFromJson()
        {
            LogUtil.CreateLogFile("CommonLogAppender", pathLog);
            loginModel = JsonDeserealization.GetJsonResult<LoginPageModel>(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"JsonConfigs/LoginJsonFile.json"));
            LogUtil.WriteDebug("Read all data from Json file LoginJsonFile.json");
            userProfileModel = JsonDeserealization.GetJsonResult<UserProfileModel>(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"JsonConfigs/UserProfileJsonFile.json"));
            LogUtil.WriteDebug("Read all data from Json file UserProfileJsonFile.json");
            leaveRequesrTabModel = JsonDeserealization.GetJsonResult<LeaveRequestTabModel>(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"JsonConfigs/LeaveRequestTabJsonFile.json"));
            LogUtil.WriteDebug("Read all data from Json file LeaveRequestTabJsonFile.json");
        }

        [TearDown]
        protected void CloseBrowser()
        {
            var result = TestContext.CurrentContext.Result;
            if (result.Outcome.Status.Equals(TestStatus.Failed))
            {
                commonMethods.TakeScreenshot();
                LogUtil.WriteDebug(result.Message);
            }
            driver.Quit();
            LogUtil.WriteDebug("Close Chrome browser");
        }

        /// <summary>
        /// Method logs In to system with Recruitments role
        /// </summary>
        public void LogInToSystemWithRecruitmentsRole()
        {
            logInPage.FillInEmailField(loginModel.RecruitmentsUserName);
            logInPage.FillInPasswordField(loginModel.UserRolesPassword);
            logInPage.ClickOnLogInButton();
            header.WaitUntilHomePageAppears();
            LogUtil.WriteDebug("Login to system with Recruitments role");
        }

        /// <summary>
        /// Method logs In to system with Super Admin role
        /// </summary>
        public void LogInToSystemWithSuperAdminRole()
        {
            logInPage.FillInEmailField(loginModel.SuperAdminUserName);
            logInPage.FillInPasswordField(loginModel.UserRolesPassword);
            logInPage.ClickOnLogInButton();
            header.WaitUntilHomePageAppears();
            LogUtil.WriteDebug("Login to system with Super Admin role");
        }

        /// <summary>
        /// Method logs In to system with HR role
        /// </summary>
        public void LogInToSystemWithHRRole()
        {
            logInPage.FillInEmailField(loginModel.HRUserName);
            logInPage.FillInPasswordField(loginModel.UserRolesPassword);
            logInPage.ClickOnLogInButton();
            header.WaitUntilHomePageAppears();
            LogUtil.WriteDebug("Login to system with HR role");
        }

        /// <summary>
        /// Method logs In to system with Empolyee role
        /// </summary>
        public void LogInToSystemWithEmployeeRole()
        {
            logInPage.FillInEmailField(loginModel.EmpolyeeUserName);
            logInPage.FillInPasswordField(loginModel.UserRolesPassword);
            logInPage.ClickOnLogInButton();
            LogUtil.WriteDebug("Login to system with Empolyee role");
            header.WaitUntilHomePageAppears();
        }
    }
}
