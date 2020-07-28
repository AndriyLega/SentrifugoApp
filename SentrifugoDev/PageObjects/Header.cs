using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SentrifugoDev.CommonLip;
using SentrifugoDev.Enums;
using SentrifugoDev.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SentrifugoDev.PageObjects
{
    public class Header
    {
        private IWebDriver driver;
        protected DashboardPage dashboardPage;
        protected CommonMethods commonMethods;
        protected LoginPage logInPage;

        #region Quick Actions Elements
        private const string xpathCompanyLogo = "//a[@class='logo']";
        private readonly By CompanyLogoLocator = By.XPath(xpathCompanyLogo);

        private const string xpathCreateNewDropDown = "//div[@tabindex='1']";
        private readonly By CreateNewDropDownLocator = By.XPath(xpathCreateNewDropDown);

        private const string xpathLeaveRequestOption = "//ul[@class='dropdown']//li[1]//a";
        private readonly By LeaveRequestOptionLocator = By.XPath(xpathLeaveRequestOption);

        private const string xpathServiceRequestOption = "//ul[@class='dropdown']//li[2]//a";
        private readonly By ServiceRequestOptionLocator = By.XPath(xpathServiceRequestOption);

        private const string xpathRecruitmentsOption = "//ul[@class='dropdown']//li[2]//a";
        private readonly By RecruitmentsOptionLocator = By.XPath(xpathRecruitmentsOption);
        #endregion

        #region User Menu Elements
        private const string xpathUserMenu = "//a[@class='userprofilepic']";
        private readonly By UserMenuLocator = By.XPath(xpathUserMenu);

        private const string xpathViewProfileOption = "//div[@class='logoutdiv']/a[text()='View Profile']";
        private readonly By ViewProfileOptionLocator = By.XPath(xpathViewProfileOption);

        private const string xpathSettingsOption = "//div[@class='logoutdiv']/a[text()='Settings']";
        private readonly By SettingsOptionLocator = By.XPath(xpathSettingsOption);

        private const string xpathChangePasswordOption = "//div[@class='logoutdiv']/a[text()='Change Password']";
        private readonly By ChangePasswordOptionLocator = By.XPath(xpathChangePasswordOption);

        private const string xpathTakeTourOption = "//div[@class='logoutdiv']/span[text()='Take Tour']";
        private readonly By TakeTourOptionLocator = By.XPath(xpathTakeTourOption);

        private const string xpathLogoutOption = "//div[@class='logoutdiv']/a[text()='Logout']";
        private readonly By LogoutOptionLocator = By.XPath(xpathLogoutOption);
        #endregion

        #region Home Menu Elements

        private const string xpathHomeMenu = "//div[@class='home_menu']";
        private readonly By HomeMenuLocator = By.XPath(xpathHomeMenu);

        private const string xpathDashboardButton = "//li[@id='main_parent_173']";
        private readonly By DashboardButtonLocator = By.XPath(xpathDashboardButton);

        private const string xpathSelfServiceButton = "//li[@id='main_parent_4']";
        private readonly By SelfServiceButtonLocator = By.XPath(xpathSelfServiceButton);

        private const string xpathServiceRequestButton = "//li[@id='main_parent_143']";
        private readonly By ServiceRequestButtonLocator = By.XPath(xpathServiceRequestButton);

        private const string xpathHRButton = "//li[@id='main_parent_3']";
        private readonly By HRButtonLocator = By.XPath(xpathHRButton);

        private const string xpathAppraisalsButton = "//li[@id='main_parent_149']";
        private readonly By AppraisalsButtonLocator = By.XPath(xpathAppraisalsButton);

        private const string xpathRecruitmentsButton = "//li[@id='main_parent_19']";
        private readonly By RecruitmentsButtonLocator = By.XPath(xpathRecruitmentsButton);

        private const string xpathPartnershipButton = "//li[@id='main_parent_214']";
        private readonly By PartnershipButtonLocator = By.XPath(xpathPartnershipButton);

        private const string xpathBackgroundCheckButton = "//li[@id='main_parent_5']";
        private readonly By BackgroundCheckButtonLocator = By.XPath(xpathBackgroundCheckButton);

        private const string xpathOrganizationButton = "//li[@id='main_parent_1']";
        private readonly By OrganizationButtonLocator = By.XPath(xpathOrganizationButton);

        private const string xpathAnaliticsButton = "//li[@id='main_parent_8']";
        private readonly By AnaliticsButtonLocator = By.XPath(xpathAnaliticsButton);

        private const string xpathSiteConfigButton = "//li[@id='main_parent_70']";
        private readonly By SiteConfigButtonLocator = By.XPath(xpathSiteConfigButton);

        private const string xpathExpensesButton = "//li[@id='main_parent_185']";
        private readonly By ExpensesButtonLocator = By.XPath(xpathExpensesButton);

        private const string xpathAssetsButton = "//li[@id='main_parent_186']";
        private readonly By AssetsButtonLocator = By.XPath(xpathAssetsButton);

        private const string xpathDisciplinaryButton = "//li[@id='main_parent_201']";
        private readonly By DisciplinaryButtonLocator = By.XPath(xpathDisciplinaryButton);

        private const string xpathTimeButton = "//li[@id='main_parent_130']";
        private readonly By TimeButtonLocator = By.XPath(xpathTimeButton);

        private const string xpathLogsButton = "//li[@id='main_parent_logs']";
        private readonly By LogsButtonLocator = By.XPath(xpathLogsButton);
       
        #endregion

        public Header(IWebDriver driver)
        {
            this.driver = driver;
            dashboardPage = new DashboardPage(driver);
            commonMethods = new CommonMethods(driver);
        }

        #region Quick Actions Methods
        /// <summary>
        /// Methods clicks on option: 'Leave Request' or 'Service Request' or 'Recruitments' in 'Create New' dropdown
        /// </summary>
        public void SelectCreateNewOption(CreateNewDropDownOptions options)
        {
            commonMethods.GetElementByWithLogs(driver, CreateNewDropDownLocator, "Can NOT click on 'Create New' DropDown").Click();
            LogUtil.WriteDebug("Clicked on 'Create New' DropDown");
            switch (options)
            {
                case CreateNewDropDownOptions.LeaveRequest:
                    {
                        commonMethods.GetElementByWithLogs(driver, LeaveRequestOptionLocator, "Can NOT click on 'Leave Request' option").Click();
                        LogUtil.WriteDebug("Clicked on Leave Request option");
                        break;
                    }

                case CreateNewDropDownOptions.ServiceRequest:
                    {
                        commonMethods.GetElementByWithLogs(driver, ServiceRequestOptionLocator, "Can NOT click on 'Service Request' option").Click();
                        LogUtil.WriteDebug("Clicked on Service Request option");
                        break;
                    }
                case CreateNewDropDownOptions.Recruitments:
                    {
                        commonMethods.GetElementByWithLogs(driver, RecruitmentsOptionLocator, "Can NOT click on 'Recruitments' option").Click();
                        LogUtil.WriteDebug("Clicked on Recruitments option");
                        break;
                    }
            }
        }
        #endregion

        #region User Menu Methods

        /// <summary>
        /// Methods clicks on option: 'View Profile', 'Settings', 'Change Password', 'Take Tour' or 'Logout' in 'User Menu' dropdown
        /// </summary>
        public void SelectUserMenuOption(UserMenuDropDownOptions options)
        {
            commonMethods.GetElementByWithLogs(driver, UserMenuLocator, "Can NOT click on 'User Menu' DropDown").Click();
            LogUtil.WriteDebug("Clicked on 'User Menu' DropDown");
            switch (options)
            {
                case UserMenuDropDownOptions.ViewProfile:
                    {
                        commonMethods.GetElementByWithLogs(driver, ViewProfileOptionLocator, "Can NOT click on 'View Profile' option").Click();
                        LogUtil.WriteDebug("Clicked on View Profile option in 'User Menu'");
                        break;
                    }

                case UserMenuDropDownOptions.Settings:
                    {
                        commonMethods.GetElementByWithLogs(driver, SettingsOptionLocator, "Can NOT click on 'Settings' option").Click();
                        LogUtil.WriteDebug("Clicked on Settings option in 'User Menu'");
                        break;
                    }
                case UserMenuDropDownOptions.ChangePassword:
                    {
                        commonMethods.GetElementByWithLogs(driver, ChangePasswordOptionLocator, "Can NOT click on 'Change Password' option").Click();
                        LogUtil.WriteDebug("Clicked on Change Password option in 'User Menu'");
                        break;
                    }

                case UserMenuDropDownOptions.TakeTour:
                    {
                        commonMethods.GetElementByWithLogs(driver, TakeTourOptionLocator, "Can NOT click on 'Take Tour' option").Click();
                        LogUtil.WriteDebug("Clicked on Take Tour option in 'User Menu'");
                        break;
                    }
                case UserMenuDropDownOptions.Logout:
                    {
                        commonMethods.GetElementByWithLogs(driver, LogoutOptionLocator, "Can NOT click on 'Logout' option").Click();
                        LogUtil.WriteDebug("Clicked on Logout option in 'User Menu'");
                        break;
                    }
            }
        }

        /// <summary>
        /// Method checks if the User Menu is present
        /// </summary>
        public bool IsUserProfileMenuPresent()
        {
            LogUtil.WriteDebug("Check if User Menu present");
            return commonMethods.IsElementPresent(UserMenuLocator);
        }
       
        #endregion

        #region Home Menu Methods
        /// <summary>
        /// Method WAITS UNTIL Home page appears
        /// </summary>
        public void WaitUntilHomePageAppears()
        {
            commonMethods.GetElementByWithLogs(driver, HomeMenuLocator, "Home page did not open");
            LogUtil.WriteDebug("Waiting for Home page ");
        }

        /// <summary>
        /// Method navigates user to the Dashboard page by button in Home menu
        /// </summary>
        public void GoToDashboardPage()
        {
            commonMethods.GetElementByWithLogs(driver, DashboardButtonLocator, "Can NOT click on 'Dashboard' button").Click();
            LogUtil.WriteDebug("Go to Dashboard page");
        }

        /// <summary>
        /// Method navigates user to the Self Service page by button in Home menu
        /// </summary>
        public void GoToSelfServicePage()
        {
            commonMethods.GetElementByWithLogs(driver, SelfServiceButtonLocator, "Can NOT click on 'Self Service' button").Click();
            LogUtil.WriteDebug("Go to Self Service page");
        }

        /// <summary>
        /// Method navigates user to the Service Request page by button in Home menu
        /// </summary>
        public void GoToServiceRequestPage()
        {
            commonMethods.GetElementByWithLogs(driver, ServiceRequestButtonLocator, "Can NOT click on 'Service Request' button").Click();
            LogUtil.WriteDebug("Go to Service Request page");
        }

        /// <summary>
        /// Method navigates user to the HR page by button in Home menu
        /// </summary>
        public void GoToHRPage()
        {
            commonMethods.GetElementByWithLogs(driver, HRButtonLocator, "Can NOT click on 'HR' button").Click();
            LogUtil.WriteDebug("Go to HR page");
        }

        /// <summary>
        /// Method navigates user to the Appraisals page by button in Home menu
        /// </summary>
        public void GoToAppraisalsPage()
        {
            commonMethods.GetElementByWithLogs(driver, AppraisalsButtonLocator, "Can NOT click on 'Appraisals' button").Click();
            LogUtil.WriteDebug("Go to Appraisals page");
        }

        /// <summary>
        /// Method navigates user to the Recruitments page by button in Home menu
        /// </summary>
        public void GoToRecruitmentsPage()
        {
            commonMethods.GetElementByWithLogs(driver, RecruitmentsButtonLocator, "Can NOT click on 'Recruitments' button").Click();
            LogUtil.WriteDebug("Go to Recruitments page");
        }

        /// <summary>
        /// Method navigates user to the Partnership page by button in Home menu
        /// </summary>
        public void GoToPartnershipPage()
        {
            commonMethods.GetElementByWithLogs(driver, PartnershipButtonLocator, "Can NOT click on 'Partnership' button").Click();
            LogUtil.WriteDebug("Go to Partnership page");
        }

        /// <summary>
        /// Method navigates user to the Background Check page by button in Home menu
        /// </summary>
        public void GoToBackgroundCheckPage()
        {
            commonMethods.GetElementByWithLogs(driver, BackgroundCheckButtonLocator, "Can NOT click on 'Background Check' button").Click();
            LogUtil.WriteDebug("Go to Background Check page");
        }

        /// <summary>
        /// Method navigates user to the Organization page by button in Home menu
        /// </summary>
        public void GoToOrganizationPage()
        {
            commonMethods.GetElementByWithLogs(driver, OrganizationButtonLocator, "Can NOT click on 'Organization' button").Click();
            LogUtil.WriteDebug("Go to Organization page");
        }

        /// <summary>
        /// Method navigates user to the Analitics page by button in Home menu
        /// </summary>
        public void GoToAnaliticsPage()
        {
            commonMethods.GetElementByWithLogs(driver, AnaliticsButtonLocator, "Can NOT click on 'Analitics' button").Click();
            LogUtil.WriteDebug("Go to Analitics page");
        }

        /// <summary>
        /// Method navigates user to the Site Config page by button in Home menu
        /// </summary>
        public void GoToSiteConfigPage()
        {
            commonMethods.GetElementByWithLogs(driver, SiteConfigButtonLocator, "Can NOT click on 'Site Config' button").Click();
            LogUtil.WriteDebug("Go to Site Config page");
        }

        /// <summary>
        /// Method navigates user to the Expenses page by button in Home menu
        /// </summary>
        public void GoToExpensesPage()
        {
            commonMethods.GetElementByWithLogs(driver, ExpensesButtonLocator, "Can NOT click on 'Expenses' button").Click();
            LogUtil.WriteDebug("Go to Expenses page");
        }

        /// <summary>
        /// Method navigates user to the Assets page by button in Home menu
        /// </summary>
        public void GoToAssetsPage()
        {
            commonMethods.GetElementByWithLogs(driver, AssetsButtonLocator, "Can NOT click on 'Assets' button").Click();
            LogUtil.WriteDebug("Go to Assets page");
        }

        /// <summary>
        /// Method navigates user to the Disciplinary page by button in Home menu
        /// </summary>
        public void GoToDisciplinaryPage()
        {
            commonMethods.GetElementByWithLogs(driver, DisciplinaryButtonLocator, "Can NOT click on 'Disciplinary' button").Click();
            LogUtil.WriteDebug("Go to Disciplinary page");
        }

        /// <summary>
        /// Method navigates user to the Time page by button in Home menu
        /// </summary>
        public void GoToTimePage()
        {
            commonMethods.GetElementByWithLogs(driver, TimeButtonLocator, "Can NOT click on 'Time' button").Click();
            LogUtil.WriteDebug("Go to Time page");

        }

        /// <summary>
        /// Method navigates user to the Logs page by button in Home menu
        /// </summary>
        public void GoToLogsPage()
        {
            commonMethods.GetElementByWithLogs(driver, LogsButtonLocator, "Can NOT click on 'Logs' button").Click();
            LogUtil.WriteDebug("Go to Logs page");
        }
        #endregion

    }
}
