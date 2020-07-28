using NUnit.Framework;
using OpenQA.Selenium;
using SentrifugoDev.CommonLip;
using SentrifugoDev.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static SentrifugoDev.CommonLip.CommonMethods;

namespace SentrifugoDev.PageObjects
{
    public class TablePlugin
    {
        private IWebDriver driver;
        protected CommonMethods commonMethods;
        protected DatePickerCalendarPlugin datePickerCalendarPlugine;
        protected PageBlockers pageBlockers;
        private const string currentYear = "0";
        private const string currentMonth = "0";

        public TablePlugin(IWebDriver driver)
        {
            this.driver = driver;
            commonMethods = new CommonMethods(driver);
            datePickerCalendarPlugine = new DatePickerCalendarPlugin(driver);
            pageBlockers = new PageBlockers(driver);
        }

        #region     Table Plugin Elements

        private const string xpathTableNeme = "//div[@class='table-header']]";
        private readonly By TableNameLocator = By.XPath(xpathTableNeme);

        private const string xpathTableRecords = "//tbody//tr[@onclick]";
        private readonly By TableRecordsLocator = By.XPath(xpathTableRecords);

        private const string xpathRefreshButtonAtTopOfTable = "//div[@class='table-buttons table-buttons-duplicate']//input[@title='Refresh']";
        private readonly By RefreshButtonAtTopOfTableLocator = By.XPath(xpathRefreshButtonAtTopOfTable);

        private const string xpathSearchButtonAtTopOfTable = "//div[@class='table-buttons table-buttons-duplicate']//input[@title='Search']";
        private readonly By SearchButtonAtTopOfTableLocator = By.XPath(xpathSearchButtonAtTopOfTable);

        private const string xpathRefreshButtonAtBottomOfTable = "//div[@class='table-buttons']//input[@title='Refresh']";
        private readonly By RefreshButtonAtBottomOfTableLocator = By.XPath(xpathRefreshButtonAtBottomOfTable);

        private const string xpathSearchButtonAtBottomOfTable = "//div[@class='table-buttons']//input[@title='Search']";
        private readonly By SearchButtonAtBottomOfTableLocator = By.XPath(xpathSearchButtonAtBottomOfTable);

        private const string xpathRowsPerPageDropdown = "//div[@class='records_number-drop-down']//select";
        private readonly By RowsPerPageDropdownLocator = By.XPath(xpathRowsPerPageDropdown);

        private const string xpathFirstPageButtonOfTableList = "//a[@data-action='first']";
        private readonly By FirstPageButtonOfTableListLocator = By.XPath(xpathFirstPageButtonOfTableList);

        private const string xpathPreviousPageButtonOfTableList = "//a[@data-action='previous']";
        private readonly By PreviousPageButtonOfTableListLocator = By.XPath(xpathPreviousPageButtonOfTableList);

        private const string xpathNextPageButtonOfTableList = "//a[@data-action='next']";
        private readonly By NextPageButtonOfTableListLocator = By.XPath(xpathNextPageButtonOfTableList);

        private const string xpathLastPageButtonOfTableList = "//a[@data-action='last']";
        private readonly By LastPageButtonOfTableListLocator = By.XPath(xpathLastPageButtonOfTableList);

        private const string xpathViewButtonOfRecordsInTableList = "//div[@class='grid-action-align']/a[@title='View']";
        private readonly By ViewButtonOfRecordsInTableListLocator = By.XPath(xpathViewButtonOfRecordsInTableList);

        private const string xpathCancelButtonOfRecordsInTableList = "//div[@class='grid-action-align']/a[contains(@title,'Cancel')]";
        private readonly By CancelButtonOfRecordsInTableListLocator = By.XPath(xpathCancelButtonOfRecordsInTableList);

        private const string xpathEditButtonOfRecordsInTableList = "//div[@class='grid-action-align']/a[@title='Edit']";
        private readonly By EditButtonOfRecordsInTableListLocator = By.XPath(xpathEditButtonOfRecordsInTableList);

        private const string xpathOptionButtonOfRecordsInTableList = "//div[@class='grid-action-align']/a[@title = 'Approve or Reject or Cancel Leave']";
        private readonly By OptionButtonOfRecordsInTableListLocator = By.XPath(xpathOptionButtonOfRecordsInTableList);

        private const string xpathListOfColumnsName = "//table[@class='grid']//thead//tr[1]//th//*[text()]";
        private readonly By ListOfColumnsNameLocator = By.XPath(xpathListOfColumnsName);

        #endregion

        #region Table Plugin Methods

        /// <summary>
        /// Method clicks on 'Refresh' button at the top of Table plugin
        /// </summary>
        public void ClickRefreshButtonAtTheTopOfTable()
        {
            commonMethods.GetElementByWithLogs(driver, RefreshButtonAtTopOfTableLocator, "Can NOT click 'Refresh' button at the top of Table plugin").Click();
            LogUtil.WriteDebug("Clicked on 'Refresh' button at the top of Table plugin");
        }

        /// <summary>
        /// Method clicks on 'Search' button at the top of Table plugin
        /// </summary>
        public void ClickSearchButtonAtTheTopOfTable()
        {
            commonMethods.GetElementByWithLogs(driver, SearchButtonAtTopOfTableLocator, "Can NOT click 'Search' button at the top of Table plugin").Click();
            LogUtil.WriteDebug("Clicked on 'Search' button at the top of Table plugin");
        }

        /// <summary>
        /// Method clicks on 'Refresh' button at the bottom of Table plugin
        /// </summary>
        public void ClickRefreshButtonAtTheBottomOfTable()
        {
            commonMethods.GetElementByWithLogs(driver, RefreshButtonAtBottomOfTableLocator, "Can NOT click 'Refresh' button at the bottom of Table plugin").Click();
            LogUtil.WriteDebug("Clicked on 'Refresh' button at the bottom of Table plugin");
        }

        /// <summary>
        /// Method clicks on 'Search' button at the bottom of Table plugin
        /// </summary>
        public void ClickSearchButtonAtTheBottomOfTable()
        {
            commonMethods.GetElementByWithLogs(driver, SearchButtonAtBottomOfTableLocator, "Can NOT click 'Search' button at the bottom of Table plugin").Click();
            LogUtil.WriteDebug("Clicked on 'Search' button at the bottom of Table plugin");
        }

        /// <summary>
        /// Method selects option in 'Records per page' dropdown by value or text
        /// </summary>
        /// <param name="by"></param>
        /// <param name="value"></param>
        public void SelectOptionRecordsPerPageDropDown(SelectBy by, string value)
        {
            IWebElement dropDown = commonMethods.GetElementByWithLogs(driver, RowsPerPageDropdownLocator, "Can NOT find 'Records per page' dropdown");
            commonMethods.SelectOptionInDropDownBy(by, dropDown, value);
            LogUtil.WriteDebug("Selected option " + value + " in 'Records per page' dropdown");
        }

        /// <summary>
        /// Method clicks on 'First page' button at the bottom of Table plugin
        /// </summary>
        public void ClickFirstPageButtonAtTheBottomOfTable()
        {
            commonMethods.GetElementByWithLogs(driver, FirstPageButtonOfTableListLocator, "Can NOT click on 'First page' button at the bottom of Table plugin").Click();
            LogUtil.WriteDebug("Clicked on on 'First page' button at the bottom of Table plugin");
        }

        /// <summary>
        /// Method clicks on 'Previous Page' button at the bottom of Table plugin
        /// </summary>
        public void ClickPreviousPageButtonAtTheTopOfTable()
        {
            commonMethods.GetElementByWithLogs(driver, PreviousPageButtonOfTableListLocator, "Can NOT click 'Previous Page' button at the bottom of Table plugin").Click();
            LogUtil.WriteDebug("Clicked on 'Previous Page' button at the bottom of Table plugin");
        }

        /// <summary>
        /// Method clicks on 'Next Page' button at the bottom of Table plugin
        /// </summary>
        public void ClickNextPageButtonAtTheBottomOfTable()
        {
            commonMethods.GetElementByWithLogs(driver, NextPageButtonOfTableListLocator, "Can NOT click 'Next Page' button at the bottom of Table plugin").Click();
            LogUtil.WriteDebug("Clicked on 'Next Page' button at the bottom of Table plugin");
        }

        /// <summary>
        /// Method clicks on 'Last Page' button at the bottom of Table plugin
        /// </summary>
        public void ClickLastPageButtonAtTheBottomOfTable()
        {
            commonMethods.GetElementByWithLogs(driver, LastPageButtonOfTableListLocator, "Can NOT click 'Last Page' button at the bottom of Table plugin").Click();
            LogUtil.WriteDebug("Clicked on 'Last Page' button at the bottom of Table plugin");
        }

        /// <summary>
        /// Method clicks on 'View' button of specific records in Table plugin
        /// </summary>
        public void ClickViewButtonOfSpecificRecordsInTable(int numberOfRecord)
        {
            IWebElement viewButton = commonMethods.GetElementByWithLogs(driver, By.XPath("//tbody//tr[" + numberOfRecord + "]" + xpathViewButtonOfRecordsInTableList), "Can NOT click 'View' button of " + numberOfRecord + "th record in Table plugin");
            commonMethods.ScrollToTheElement(viewButton);
            viewButton.Click();
            LogUtil.WriteDebug("Clicked on 'View' button of " + numberOfRecord + "th record in Table plugin");
        }

        /// <summary>
        /// Method clicks on 'Cancel' button of specific records in Table plugin
        /// </summary>
        public void ClickCancelButtonOfSpecificRecordsInTable(int numberOfRecord)
        {

            IWebElement cancelButton = commonMethods.GetElementByWithLogs(driver, By.XPath("//tbody//tr[" + numberOfRecord + "]" + xpathCancelButtonOfRecordsInTableList), "Can NOT click 'Cancel' button of " + numberOfRecord + "th record in Table plugin");
            commonMethods.ScrollToTheElement(cancelButton);
            cancelButton.Click();
            LogUtil.WriteDebug("Clicked on 'Cancel' button of " + numberOfRecord + "th record in Table plugin");
        }

        /// <summary>
        /// Method clicks on 'Edit' button of specific records in Table plugin
        /// </summary>
        public void ClickEditButtonOfSpecificRecordsInTable(int numberOfRecord)
        {
            IWebElement editButton = commonMethods.GetElementByWithLogs(driver, By.XPath("//tbody//tr[" + numberOfRecord + "]" + xpathEditButtonOfRecordsInTableList), "Can NOT click 'Edit' button of " + numberOfRecord + "th record in Table plugin");
            commonMethods.ScrollToTheElement(editButton);
            editButton.Click();
            LogUtil.WriteDebug("Clicked on 'Edit' button of " + numberOfRecord + "th record in Table plugin");
        }

        /// <summary>
        /// Method clicks on 'Option' button of specific records in Table plugin
        /// </summary>
        public void ClickOptionButtonOfSpecificRecordsInTable(int numberOfRecord)
        {
            IWebElement optionButton = commonMethods.GetElementByWithLogs(driver, By.XPath("//tbody//tr[" + numberOfRecord + "]" + xpathOptionButtonOfRecordsInTableList), "Can NOT click 'Option' button of " + numberOfRecord + "th record in Table plugin");
            commonMethods.ScrollToTheElement(optionButton);
            optionButton.Click();
            LogUtil.WriteDebug("Clicked on 'Option' button of " + numberOfRecord + "th record in Table plugin");
        }

        /// <summary>
        /// Method counts the number of records in the table and returns this value
        /// </summary>
        /// <returns></returns>
        public int CountOfTableRecordsOfOpenedPage()
        {
            int records = driver.FindElements(TableRecordsLocator).Count();
            if (records == 0)
            {
                LogUtil.WriteDebug("The table has no records");
                return records;
            }
            LogUtil.WriteDebug("Count of records in the tabel is = " + records);
            return records;
        }

        /// <summary>
        /// Method scrolls to the specicfic column of the table
        /// </summary>
        /// <param name="columnname"></param>
        public void ScrollToTheColumn(string columnName)
        {
            commonMethods.ScrollToTheElement(commonMethods.GetElementByWithLogs(driver, By.XPath("//tr//th//*[contains(text(),'" + columnName + "')]"), "Can NOT find " + columnName + " column"));
            LogUtil.WriteDebug("Scrolled to the " + columnName + " column");
        }

        /// <summary>
        /// Methods scrolls to the specific records in the table
        /// </summary>
        /// <param name="recordNumber"></param>
        public void ScrollToTheRow(int recordNumber)
        {
            commonMethods.ScrollToTheElement(commonMethods.GetElementByWithLogs(driver, By.XPath(TableRecordsLocator + "[" + recordNumber + "]"), "Can NOT Find " + recordNumber + " row"));
            LogUtil.WriteDebug("Scrolled to the " + recordNumber + "th record");
        }

        /// <summary>
        /// Methods sorts records in the table by click on the column name
        /// </summary>
        /// <param name="recordNumber"></param>
        public void SortRecordsInTheTableByColumn(string columnName)
        {
            commonMethods.GetElementByWithLogs(driver, By.XPath("//a[text()='" + columnName + "']"), "Can NOT Find " + columnName + " column").Click();
            LogUtil.WriteDebug("Sorted records by data in column " + columnName);
        }

        /// <summary>
        /// Method gets the list of all data of searched column
        /// </summary>
        /// <param name="columnNameValue"></param>
        /// <returns></returns>
        public List<string> GetListOfDataOfColumnInTable(string columnNameValue)
        {
            List<string> listOfColumnData = new List<string>();
            ShowAllRecordsInTheTable();
            var listOfColumnElements = driver.FindElements(By.XPath("//tbody//tr[@onclick]//td[" + GetNumberOfSpecificColumn(columnNameValue) + "]"));
            for (int k = 0; k < listOfColumnElements.Count; k++)
            {
                listOfColumnData.Add(listOfColumnElements[k].Text);
            }
            LogUtil.WriteDebug("Got the list of all data of searched column: " + columnNameValue);
            return listOfColumnData;
            
        }

        /// <summary>
        /// Method gets the list of all data of specified recod
        /// </summary>
        /// <param name="columnNameValue"></param>
        /// <returns></returns>
        public List<string> GetListOfDataOfSpecificRecordInTable(int recordNumber)
        {
            List<string> listOfrecordData = new List<string>();
            ShowAllRecordsInTheTable();
            var listOfRecordElements = driver.FindElements(By.XPath("//tbody//tr[" + recordNumber + "]//td//span"));
            for (int k = 0; k < listOfRecordElements.Count; k++)
            {
                listOfrecordData.Add(listOfRecordElements[k].Text);
            }
            LogUtil.WriteDebug("Got the list of all data of specified recod: " + recordNumber);
            return listOfrecordData;

        }

        /// <summary>
        /// Method gets list of all columns name in the table
        /// </summary>
        /// <returns></returns>
        public List<string> GetListOfTableColumnsName()
        {
            List<string> allColumnsName = new List<string>();
            Thread.Sleep(200);
            var columnsName = driver.FindElements(ListOfColumnsNameLocator);
            for (int k = 0; k < columnsName.Count; k++)
            {
                commonMethods.ScrollToTheElement(columnsName[k]);
                allColumnsName.Add(columnsName[k].Text);
            }
            LogUtil.WriteDebug("Got the list of all columns name in the table");
            return allColumnsName;
        }

        /// <summary>
        /// Method determines the sequence number of searched column
        /// </summary>
        /// <param name="columnNameValue"></param>
        /// <returns></returns>
        public int GetNumberOfSpecificColumn(string columnNameValue)
        {
            var list = GetListOfTableColumnsName();
            int colunmNumber = new int();
            for (int k = 0; k < list.Count; k++)
            {
                string columnName = list[k];
                if (!columnName.Equals(columnNameValue))
                {
                    continue; 
                }
                colunmNumber = k + 1;
                break;
            }
            LogUtil.WriteDebug("Determined the sequence number of searched column: " + columnNameValue);
            return colunmNumber;
        }

        /// <summary>
        /// Method checks  if sort logic of records in the table by specific clomn works corectly
        /// </summary>
        /// <param name="columnNameValue"></param>
        public void CheckIfSortLogicInTableWorksCorrectly(string columnNameValue)
        {
            ShowAllRecordsInTheTable();
            var list = GetListOfDataOfColumnInTable(columnNameValue);
            list.Sort();
            SortRecordsInTheTableByColumn(columnNameValue);
            var sortedList = GetListOfDataOfColumnInTable(columnNameValue);
            Assert.IsTrue(list.Count.Equals(sortedList.Count), "Lists have different length");
            for (int k = 0; k < list.Count; k++)
            {
                Assert.IsTrue(list[k].Equals(sortedList[k]), "Sort logic of the table works not as C# sort logic");
            }
            LogUtil.WriteDebug("Checked if sort logic of records in the table by column " + columnNameValue + " works correctly ");
        }

        /// <summary>
        /// Method counts the number of all records in the table and returns this value
        /// </summary>
        /// <returns></returns>
        public int CountOfAllRecordsInTheTable()
        {
            ShowAllRecordsInTheTable();
            int allrecords = CountOfTableRecordsOfOpenedPage();
            return allrecords;
        }

        /// <summary>
        /// Method shows all records in the table 
        /// </summary>
        public void ShowAllRecordsInTheTable()
        {
            int count1 = CountOfTableRecordsOfOpenedPage();
            if (count1 == 20)
            {
                Thread.Sleep(500);    
                pageBlockers.WaitUntilLoaderDisappears();
                SelectOptionRecordsPerPageDropDown(SelectBy.Value, "50");
                commonMethods.GetElementByWithLogs(driver, By.XPath("//option[@value = '50' and @selected]"), "The value '50' is not selected");
            }
            else
            {
                return;
            }

            int count2 = CountOfTableRecordsOfOpenedPage();
            if (count2 ==  50)
            {
                SelectOptionRecordsPerPageDropDown(SelectBy.Value, "100");
                commonMethods.GetElementByWithLogs(driver, By.XPath("//option[@value = '100' and @selected]"), "The value '100' is not selected");

            }
            else
            {
                return;
            }

            int count3 = CountOfTableRecordsOfOpenedPage();
            if (count3 == 100)
            {
                SelectOptionRecordsPerPageDropDown(SelectBy.Value, "150");
                commonMethods.GetElementByWithLogs(driver, By.XPath("//option[@value = '150' and @selected]"), "The value '150' is not selected");

            }
            else
            {
                return; 
            }

            int count4 = CountOfTableRecordsOfOpenedPage();
            if (count4 == 150)
            {
                SelectOptionRecordsPerPageDropDown(SelectBy.Value, "200");
                commonMethods.GetElementByWithLogs(driver, By.XPath("//option[@value = '200' and @selected]"), "The value '50' is not selected");
            }
            else
            {
                return;
            }

            int count5 = CountOfTableRecordsOfOpenedPage();
            if (count5 == 200)
            {
                LogUtil.WriteDebug("Count of records in the tabel is more than 200, to caount all records you need to open next page");
                return;
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Method fills in text field of specific column in search block and searches all records with entered value in this column
        /// </summary>
        public void SearcheRecordsByTextFieldOfSpecificColumnData(string columnNameValue, string textValue)
        {
            ClickSearchButtonAtTheTopOfTable();
            IWebElement textField = commonMethods.GetElementByWithLogs(driver, By.XPath("//thead//tr[contains(@id,'search')]//th[" + GetNumberOfSpecificColumn(columnNameValue) + "]//input"), "Can NOT find '" + columnNameValue + "' field");
            commonMethods.ScrollToTheElement(textField);
            textField.SendKeys(textValue);
            LogUtil.WriteDebug("Filled in '" + columnNameValue + "' field in search block of table in My Leave tab with data: " + textValue);
            textField.SendKeys(Keys.Enter);
            LogUtil.WriteDebug("Searched all records by data: " + textValue + "in the '" + columnNameValue + "' column");
        }

        /// <summary>
        /// Method clicks on date select field of specific column, selects date and searches all records with entered value in this column
        /// </summary>
        public void SearcheRecordsByDateSelectFieldOfSpecificColumnData(string columnNameValue, SelectBy by, string day, string month = currentMonth, string year = currentYear)
        {
            ClickSearchButtonAtTheTopOfTable();
            IWebElement dateSelecterField = commonMethods.GetElementByWithLogs(driver, By.XPath("//thead//tr[contains(@id,'search')]//th[" + GetNumberOfSpecificColumn(columnNameValue) + "]"), "Can NOT find '" + columnNameValue + "' field");
            commonMethods.ScrollToTheElement(dateSelecterField);
            dateSelecterField.Click();
            if (!year.Equals(currentYear))
            {
                datePickerCalendarPlugine.SelectYearInDatePickerCalendar1(by, year);
            }
            if (!month.Equals(currentMonth))
            {
                datePickerCalendarPlugine.SelectMonthInDatePickerCalendar1(by, month);
            }
            datePickerCalendarPlugine.SelectDateByDatePickerCalendar(Int32.Parse(day));
            LogUtil.WriteDebug("Searched all records by selected date " + year + "/" + month + "/" + day + "in '" + columnNameValue + "' field in '" + columnNameValue + "' column");
        }

        #endregion
    }

}
