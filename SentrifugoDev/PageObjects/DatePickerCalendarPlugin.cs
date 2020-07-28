using OpenQA.Selenium;
using SentrifugoDev.CommonLip;
using SentrifugoDev.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SentrifugoDev.CommonLip.CommonMethods;

namespace SentrifugoDev.PageObjects
{
    public class DatePickerCalendarPlugin
    {
        private IWebDriver driver;
        protected CommonMethods commonMethods;

        public DatePickerCalendarPlugin(IWebDriver driver)
        {
            this.driver = driver;
            commonMethods = new CommonMethods(driver);
        }

        #region Date Picker Calendar Elements

        private const string xpathDatePickerCalendar = "//input[@id='from_date']";
        private readonly By DatePickerCalendarLocator = By.XPath(xpathDatePickerCalendar);

        private const string xpathPreviousMonthButtonInDatePickerCalendar = "//a[@data-handler='prev']";
        private readonly By PreviousMonthButtonInDatePickerCalendarLocator = By.XPath(xpathPreviousMonthButtonInDatePickerCalendar);

        private const string xpathNextMonthButtonInDatePickerCalendar = "//a[@data-handler='next']";
        private readonly By NextMonthButtonInDatePickerCalendarLocator = By.XPath(xpathNextMonthButtonInDatePickerCalendar);

        private const string xpathMonthDropdownInDatePickerCalendar = "//select[@data-handler='selectMonth']";
        private readonly By MonthDropdownInDatePickerCalendarLocator = By.XPath(xpathMonthDropdownInDatePickerCalendar);

        #region Month Options

        private const string xpathJanuaryOption = "//select[@data-handler='selectMonth']//option[@value=0]";
        private readonly By JanuaryOptionLocator = By.XPath(xpathJanuaryOption);

        private const string xpathFebruaryOption = "//select[@data-handler='selectMonth']//option[@value=1]";
        private readonly By FebruaryOptionLocator = By.XPath(xpathFebruaryOption);

        private const string xpathMarchOption = "//select[@data-handler='selectMonth']//option[@value=2]";
        private readonly By MarchOptionLocator = By.XPath(xpathMarchOption);

        private const string xpathAprilOption = "//select[@data-handler='selectMonth']//option[@value=3]";
        private readonly By AprilOptionLocator = By.XPath(xpathAprilOption);

        private const string xpathMayOption = "//select[@data-handler='selectMonth']//option[@value=4]";
        private readonly By MayOptionLocator = By.XPath(xpathMayOption);

        private const string xpathJuneOption = "//select[@data-handler='selectMonth']//option[@value=5]";
        private readonly By JuneOptionLocator = By.XPath(xpathJuneOption);

        private const string xpathJulyOption = "//select[@data-handler='selectMonth']//option[@value=6]";
        private readonly By JulyOptionLocator = By.XPath(xpathJulyOption);

        private const string xpathAugustOption = "//select[@data-handler='selectMonth']//option[@value=7]";
        private readonly By AugustOptionLocator = By.XPath(xpathAugustOption);

        private const string xpathSeptemberOption = "//select[@data-handler='selectMonth']//option[@value=8]";
        private readonly By SeptemberOptionLocator = By.XPath(xpathSeptemberOption);

        private const string xpathOctoberOption = "//select[@data-handler='selectMonth']//option[@value=9]";
        private readonly By OctoberOptionLocator = By.XPath(xpathOctoberOption);

        private const string xpathNovemberOption = "//select[@data-handler='selectMonth']//option[@value=10]";
        private readonly By NovemberOptionLocator = By.XPath(xpathNovemberOption);

        private const string xpathDecemberOption = "//select[@data-handler='selectMonth']//option[@value=11]";
        private readonly By DecemberOptionLocator = By.XPath(xpathDecemberOption);

        #endregion

        private const string xpathYearDropdownInDatePickerCalendar = "//select[@data-handler='selectYear']";
        private readonly By YearDropdownInDatePickerCalendarLocator = By.XPath(xpathYearDropdownInDatePickerCalendar);

        #region Year Options

        private const string xpathCurrentYearOption = "//select[@data-handler='selectYear']//option[1]";
        private readonly By CurrentYearOptionLocator = By.XPath(xpathCurrentYearOption);

        private const string xpathNextYearOption = "//select[@data-handler='selectYear']//option[2]";
        private readonly By NextYearOptionLocator = By.XPath(xpathNextYearOption);

        #endregion

        private const string xpathCurrentMonthButtonInDatePickerCalendar = "//button[@data-handler='today']";
        private readonly By CurrentMonthButtonInDatePickerCalendarLocator = By.XPath(xpathCurrentMonthButtonInDatePickerCalendar);

        private const string xpathCancelButtonInDatePickerCalendar = "//button[@data-handler='clear']";
        private readonly By CancelButtonInDatePickerCalendarLocator = By.XPath(xpathCancelButtonInDatePickerCalendar);

        private const string xpathListOfDaysOfSelectedMonthInDatePickerCalendar = "//td[@data-handler='selectDay' or contains(@class,' ui-state-disabled undefined') ]";
        private readonly By ListOfDaysOfSelectedMonthInDatePickerCalendarLocator = By.XPath(xpathListOfDaysOfSelectedMonthInDatePickerCalendar);

        #endregion

        #region Date Picker Calendar Methods

        /// <summary>
        /// Method selects date in field by Date Picker Calendar plugin
        /// </summary>
        public void SelectDateByDatePickerCalendar(int day)
        {
            var ListOfDaysOfSelectedMonth = driver.FindElements(ListOfDaysOfSelectedMonthInDatePickerCalendarLocator);
            ListOfDaysOfSelectedMonth[day - 1].Click();
        }

        /// <summary>
        /// Method clicks on 'Previous Month' button of Date Picker Calendar 
        /// </summary>
        public void ClickPreviousMonthButtonInDatePickerCalendar()
        {
            commonMethods.GetElementByWithLogs(driver, PreviousMonthButtonInDatePickerCalendarLocator, "Can NOT click 'Previous Month' button of Date Picker Calendar ").Click();
            LogUtil.WriteDebug("Clicked on 'Previous Month' button of Date Picker Calendar ");
        }

        /// <summary>
        /// Method clicks on 'Next Month' button of Date Picker Calendar 
        /// </summary>
        public void ClickNextMonthButtonInDatePickerCalendar()
        {
            commonMethods.GetElementByWithLogs(driver, NextMonthButtonInDatePickerCalendarLocator, "Can NOT click 'Next Month' button of Date Picker Calendar ").Click();
            LogUtil.WriteDebug("Clicked on 'Next Month' button of Date Picker Calendar ");
        }

        /// <summary>
        /// Method clicks on 'Today' button of Date Picker Calendar 
        /// </summary>
        public void ClickCurrentMonthButtonInDatePickerCalendar()
        {
            commonMethods.GetElementByWithLogs(driver, CurrentMonthButtonInDatePickerCalendarLocator, "Can NOT click 'Today' button of Date Picker Calendar ").Click();
            LogUtil.WriteDebug("Clicked on 'Today' button of Date Picker Calendar ");
        }

        /// <summary>
        /// Method clicks on 'Clear' button of Date Picker Calendar 
        /// </summary>
        public void ClickClearButtonInDatePickerCalendar()
        {
            commonMethods.GetElementByWithLogs(driver, CancelButtonInDatePickerCalendarLocator, "Can NOT click 'Clear' button of Date Picker Calendar ").Click();
            LogUtil.WriteDebug("Clicked on 'Clear' button of Date Picker Calendar ");
        }

        /// <summary>
        /// Methods clicks on option: 'January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November' or 'December' in 'Month' dropdown of Date Picker Calendar 
        /// </summary>
        public void SelectMonthInDatePickerCalendar(MonthList options)
        {
            commonMethods.GetElementByWithLogs(driver, MonthDropdownInDatePickerCalendarLocator, "Can NOT click on 'Month' DropDown of Date Picker Calendar").Click();
            LogUtil.WriteDebug("Clicked on 'Month' DropDown of Date Picker Calendar");
            switch (options)
            {
                case MonthList.January:
                    {
                        commonMethods.GetElementByWithLogs(driver, JanuaryOptionLocator, "Can NOT click on 'January' option in 'Month' dropdown").Click();
                        LogUtil.WriteDebug("Clicked on January option in 'Month' dropdown of Date Picker Calendar");
                        break;
                    }

                case MonthList.February:
                    {
                        commonMethods.GetElementByWithLogs(driver, FebruaryOptionLocator, "Can NOT click on 'February' option in 'Month' dropdown").Click();
                        LogUtil.WriteDebug("Clicked on February option in 'Month' dropdown of Date Picker Calendar");
                        break;
                    }

                case MonthList.March:
                    {
                        commonMethods.GetElementByWithLogs(driver, MarchOptionLocator, "Can NOT click on 'March' option in 'Month' dropdown").Click();
                        LogUtil.WriteDebug("Clicked on March option in 'Month' dropdown of Date Picker Calendar");
                        break;
                    }

                case MonthList.April:
                    {
                        commonMethods.GetElementByWithLogs(driver, AprilOptionLocator, "Can NOT click on 'April' option in 'Month' dropdown").Click();
                        LogUtil.WriteDebug("Clicked on April option in 'Month' dropdown of Date Picker Calendar");
                        break;
                    }

                case MonthList.May:
                    {
                        commonMethods.GetElementByWithLogs(driver, MayOptionLocator, "Can NOT click on 'May' option in 'Month' dropdown").Click();
                        LogUtil.WriteDebug("Clicked on May option in 'Month' dropdown of Date Picker Calendar");
                        break;
                    }

                case MonthList.June:
                    {
                        commonMethods.GetElementByWithLogs(driver, JuneOptionLocator, "Can NOT click on 'June' option in 'Month' dropdown").Click();
                        LogUtil.WriteDebug("Clicked on June option in 'Month' dropdown of Date Picker Calendar");
                        break;
                    }

                case MonthList.July:
                    {
                        commonMethods.GetElementByWithLogs(driver, JulyOptionLocator, "Can NOT click on 'July' option in 'Month' dropdown").Click();
                        LogUtil.WriteDebug("Clicked on July option in 'Month' dropdown of Date Picker Calendar");
                        break;
                    }
                case MonthList.August:
                    {
                        commonMethods.GetElementByWithLogs(driver, AugustOptionLocator, "Can NOT click on 'August' option in 'Month' dropdown").Click();
                        LogUtil.WriteDebug("Clicked on August option in 'Month' dropdown of Date Picker Calendar");
                        break;
                    }

                case MonthList.September:
                    {
                        commonMethods.GetElementByWithLogs(driver, SeptemberOptionLocator, "Can NOT click on 'September' option in 'Month' dropdown").Click();
                        LogUtil.WriteDebug("Clicked on September option in 'Month' dropdown of Date Picker Calendar");
                        break;
                    }

                case MonthList.October:
                    {
                        commonMethods.GetElementByWithLogs(driver, OctoberOptionLocator, "Can NOT click on 'October' option in 'Month' dropdown").Click();
                        LogUtil.WriteDebug("Clicked on October option in 'Month' dropdown of Date Picker Calendar");
                        break;
                    }

                case MonthList.November:
                    {
                        commonMethods.GetElementByWithLogs(driver, NovemberOptionLocator, "Can NOT click on 'November' option in 'Month' dropdown").Click();
                        LogUtil.WriteDebug("Clicked on November option in 'Month' dropdown of Date Picker Calendar");
                        break;
                    }

                case MonthList.December:
                    {
                        commonMethods.GetElementByWithLogs(driver, DecemberOptionLocator, "Can NOT click on 'Available Events' option in 'Month' dropdown").Click();
                        LogUtil.WriteDebug("Clicked on January option in 'Month' dropdown of Date Picker Calendar");
                        break;
                    }
            }
        }

        /// <summary>
        /// Methods clicks on option: 'Current Year' or 'Next Year' in 'Year' dropdown of Date Picker Calendar
        /// </summary>
        public void SelectYearInDatePickerCalendar(YearList options)
        {
            commonMethods.GetElementByWithLogs(driver, YearDropdownInDatePickerCalendarLocator, "Can NOT click on 'Year' DropDown of Date Picker Calendar").Click();
            LogUtil.WriteDebug("Clicked on 'Year' DropDown of Date Picker Calendar");
            switch (options)
            {
                case YearList.CurrentYear:
                    {
                        commonMethods.GetElementByWithLogs(driver, CurrentYearOptionLocator, "Can NOT click on 'Current Year' option in 'Year' dropdown").Click();
                        LogUtil.WriteDebug("Clicked on Current Year option in 'Year' dropdown of Date Picker Calendar");
                        break;
                    }

                case YearList.NextYear:
                    {
                        commonMethods.GetElementByWithLogs(driver, NextYearOptionLocator, "Can NOT click on 'Next Year' option in 'Year' dropdown").Click();
                        LogUtil.WriteDebug("Clicked on Next Year option in 'Year' dropdown of Date Picker Calendar");
                        break;
                    }
            }
        }

        /// <summary>
        /// Methods clicks select year in 'Year' dropdown of Date Picker Calendar
        /// </summary>
        public void SelectYearInDatePickerCalendar1(SelectBy by, string year)
        {
            IWebElement dropDown = commonMethods.GetElementByWithLogs(driver, YearDropdownInDatePickerCalendarLocator, "Can NOT find 'Year' DropDown of Date Picker Calendar");
            commonMethods.SelectOptionInDropDownBy(by, dropDown, year);
            LogUtil.WriteDebug("Selected year " + year + " in 'Year' dropdown of Date Picker Calendar");
        }

        /// <summary>
        /// Methods clicks select year in 'Year' dropdown of Date Picker Calendar
        /// </summary>
        public void SelectMonthInDatePickerCalendar1(SelectBy by, string month)
        {
            IWebElement dropDown = commonMethods.GetElementByWithLogs(driver, MonthDropdownInDatePickerCalendarLocator, "Can NOT find 'Month' DropDown of Date Picker Calendar");
            commonMethods.SelectOptionInDropDownBy(by, dropDown, (Int32.Parse(month) - 1).ToString());
            LogUtil.WriteDebug("Selected month " + month + " in 'Month' dropdown of Date Picker Calendar");
        }
        #endregion

    }
}
