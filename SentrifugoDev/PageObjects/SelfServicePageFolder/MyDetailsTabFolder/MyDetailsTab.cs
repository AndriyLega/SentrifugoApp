using OpenQA.Selenium;
using SentrifugoDev.CommonLip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentrifugoDev.PageObjects.SelfServicePageFolder.MyDetailsTabFolder
{
    public class MyDetailsTab
    {
        private IWebDriver driver;
        protected CommonMethods commonMethods;
        protected DatePickerCalendarPlugin datePickerCalendarPlugin;
        protected TablePlugin tablePlugin;
        public OfficialDetailsBlock officialDetailsBlock;

        public MyDetailsTab(IWebDriver driver)
        {
            this.driver = driver;
            commonMethods = new CommonMethods(driver);
            officialDetailsBlock = new OfficialDetailsBlock(driver);
        }

        #region My Details Tab Elements

        private const string xpathGeneralPersonDetails = "//div[@id = 'personalDetailsDiv']";
        private readonly By GeneralPersonDetailsLocator = By.XPath(xpathGeneralPersonDetails);

        private const string xpathEditContactNumberButton = "//div[@id = 'personalDetailsDiv']//span[@class = 'number-edit']//input";
        private readonly By EditContactNumberButtonLocator = By.XPath(xpathEditContactNumberButton);

        private const string xpathOfficialDetailsBlock = "//div[@class = 'agency-ui']//li[@id = 'empdetails']/a";
        private readonly By OfficialDetailsBlockLocator = By.XPath(xpathOfficialDetailsBlock);

        private const string xpathEmployeeDocumentBlock = "//div[@class = 'agency-ui']//li[@id = 'employeedocs']/a";
        private readonly By EmployeeDocumentBlockLocator = By.XPath(xpathEmployeeDocumentBlock);

        private const string xpathEmployeeCVsBlock = "//div[@class = 'agency-ui']//li[@id = 'employeecv']";
        private readonly By EmployeeCVsBlockLocator = By.XPath(xpathEmployeeCVsBlock);

        private const string xpathEmployeeLeavesBlock = "//div[@class = 'agency-ui']//li[@id = 'emp_leaves']/a";
        private readonly By EmployeeLeavesBlockLocator = By.XPath(xpathEmployeeLeavesBlock);

        private const string xpathEmployeeSalaryBlock = "//div[@class = 'agency-ui']//li[@id = 'emp_salary']/a";
        private readonly By EmployeeSalaryBlockLocator = By.XPath(xpathEmployeeSalaryBlock);

        private const string xpathEmployeePersonalDetailsBlock = "//div[@class = 'agency-ui']//li[@id = 'emppersonaldetails']/a";
        private readonly By EmployeePersonalDetailsBlockLocator = By.XPath(xpathEmployeePersonalDetailsBlock);

        private const string xpathEmployeeContactDetailsBlock = "//div[@class = 'agency-ui']//li[@id = 'empcommunicationdetails']/a";
        private readonly By EmployeeContactDetailsBlockLocator = By.XPath(xpathEmployeeContactDetailsBlock);

        private const string xpathEmployeeSkillsBlock = "//div[@class = 'agency-ui']//li[@id = 'emp_skills']/a";
        private readonly By EmployeeSkillsBlockLocator = By.XPath(xpathEmployeeSkillsBlock);

        private const string xpathEmployeeJobHistoryBlock = "//div[@class = 'agency-ui']//li[@id = 'emp_jobhistory']/a";
        private readonly By EmployeeJobHistoryBlockLocator = By.XPath(xpathEmployeeJobHistoryBlock);

        private const string xpathEmployeeExperienceBlock = "//div[@class = 'agency-ui']//li[@id = 'experience_details']/a";
        private readonly By EmployeeExperienceBlockLocator = By.XPath(xpathEmployeeExperienceBlock);

        private const string xpathEmployeeEducationBlock = "//div[@class = 'agency-ui']//li[@id = 'education_details']/a";
        private readonly By EmployeeEducationBlockLocator = By.XPath(xpathEmployeeEducationBlock);

        private const string xpathEmployeeTrainingAndCertificationBlock = "//div[@class = 'agency-ui']//li[@id = 'trainingandcertification_details']/a";
        private readonly By EmployeeTrainingAndCertificationBlockLocator = By.XPath(xpathEmployeeTrainingAndCertificationBlock);

        private const string xpathEmployeeMedicalClaimsBlock = "//div[@class = 'agency-ui']//li[@id = 'medical_claims']/a";
        private readonly By EmployeeMedicalClaimsBlockLocator = By.XPath(xpathEmployeeMedicalClaimsBlock);

        private const string xpathEmployeeDisabilityBlock = "//div[@class = 'agency-ui']//li[@id = 'disabilitydetails']/a";
        private readonly By EmployeeDisabilityBlockLocator = By.XPath(xpathEmployeeDisabilityBlock);

        private const string xpathEmployeeDependencyBlock = "//div[@class = 'agency-ui']//li[@id = 'dependency_details']/a";
        private readonly By EmployeeDependencyBlockLocator = By.XPath(xpathEmployeeDependencyBlock);

        private const string xpathEmployeeVisaAndImmigrationBlock = "//div[@class = 'agency-ui']//li[@id = 'visadetails']/a";
        private readonly By EmployeeVisaAndImmigrationBlockLocator = By.XPath(xpathEmployeeVisaAndImmigrationBlock);

        private const string xpathEmployeeCorporateCardBlock = "//div[@class = 'agency-ui']//li[@id = 'creditcarddetails']/a";
        private readonly By EmployeeCorporateCardBlockLocator = By.XPath(xpathEmployeeCorporateCardBlock);

        private const string xpathEmployeeWorkEligibilityBlock = "//div[@class = 'agency-ui']//li[@id = 'workeligibilitydetails']/a";
        private readonly By EmployeeWorkEligibilityBlockLocator = By.XPath(xpathEmployeeWorkEligibilityBlock);

        private const string xpathEmployeeAdditionalDetailsBlock = "//div[@class = 'agency-ui']//li[@id = 'emp_additional']/a";
        private readonly By EmployeeAdditionalDetailsBlockLocator = By.XPath(xpathEmployeeAdditionalDetailsBlock);

        #region Update Contact Number Popup Window Elements

        private const string xpathUpdateContactNumberPopupForm = "//div[@aria-labelledby= 'ui-id-1']";
        private readonly By UpdateContactNumberPopupFormLocator = By.XPath(xpathUpdateContactNumberPopupForm);

        private const string xpathUpdateContactNumberPopupTitle = "//span[@id = 'ui-id-1']";
        private readonly By UpdateContactNumberPopupTitleLocator = By.XPath(xpathUpdateContactNumberPopupTitle);

        private const string xpathNumberFieldInUpdateContactNumberPopupForm = "//input[@id= 'number_value']";
        private readonly By NumberFieldInUpdateContactNumberFormLocator = By.XPath(xpathNumberFieldInUpdateContactNumberPopupForm);

        private const string xpathOKButtonOfUpdateContactNumberPopupForm = "//button[@id= 'btn-accept']";
        private readonly By OKButtonOfUpdateContactNumberPopupFormLocator = By.XPath(xpathOKButtonOfUpdateContactNumberPopupForm);

        private const string xpathCancelButtonOfUpdateContactNumberPopupForm = "//button[@id= 'dialogcncl']";
        private readonly By CancelButtonOfUpdateContactNumberPopupFormLocator = By.XPath(xpathCancelButtonOfUpdateContactNumberPopupForm);

        #endregion

        #endregion
    }
}
