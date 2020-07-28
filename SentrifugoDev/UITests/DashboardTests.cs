using NUnit.Framework;
using OpenQA.Selenium;
using SentrifugoDev.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentrifugoDev.UITests
{
    public class DashboardTests:BaseTest
    {
        [SetUp]
        public void LoginToSystem()
        {
            LogInToSystemWithEmployeeRole();
        }



        //[Test]
        //private void HeaderMenuElements()
        //{
        //    var headerMenuElements = driver.FindElements(By.XPath("//ul[@id='main_ul']//li"));
        //    headerMenuElements[1].Click();
        //}

        //[Test]
        //public void FindingElementsOfRequestLeaveForm()
        //{
        //    var leaveRequestForm = driver.FindElements(By.XPath("//div[@class='new-form-ui']//div[@class='division']"));
        //    var typesOfLeaveField = leaveRequestForm[0];
        //    var reasonField = leaveRequestForm[1];
        //    var fromDateField = leaveRequestForm[2];
        //    var toDateField = leaveRequestForm[3];
        //    var leaveFoeField = leaveRequestForm[4];
        //    var numberOfDaysField = leaveRequestForm[5];
        //    var reportingManagerField = leaveRequestForm[6];

        //    var listOfLeaveTypes = driver.FindElements(By.XPath("//select[@id='leavetypeid']//option"));
        //    var vacation = listOfLeaveTypes[0];
        //    var maternityLeave = listOfLeaveTypes[1];
        //    var sickLeave = listOfLeaveTypes[2];
        //    var dayOffPaid = listOfLeaveTypes[3];
        //    var dayOffUnpaid = listOfLeaveTypes[4];
        //    var availableEvents = listOfLeaveTypes[5];
        //    var listOfLeaveDay = driver.FindElements(By.XPath("//select[@id='leaveday']//option"));
        //    var fullDay = listOfLeaveDay[0];
        //    var halfDay = listOfLeaveDay[1];
        //    //var leaveTypes = leaveRequestForm[0].FindElements(By.XPath("//option"));
        //    //leaveTypes[4].Click();
        //}

        ////public void FillingInRequestLeaveForm()
        ////{
        ////    typesOfLeaveField.Click();
        ////}

        //[Test]
        //public void RequestVacation()
        //{
        //   // LoginIntoSustem();
        //    HeaderMenuElements();
        //    var applyLeaveButton = driver.FindElement(By.XPath("//input[@value='Apply Leave']"));
        //    //var vacationDay = driver.FindElement(By.XPath("//td[contains(@class,'fc-future')]//div[text()=21]"));
        //    //var dayArena = futureDays[3].FindElement(By.XPath("//div[text()=14]"));
        //    //dayArena.Click();
        //    applyLeaveButton.Click();
        //    FindingElementsOfRequestLeaveForm();

        //}
        ////public void SelectLeaveType()
        ////{
        ////    var leaveTypes = driver.FindElement(By.XPath("//select[@id='leavetypeid']//option"));
        ////    leaveTypes.
        ////}
    }

}

