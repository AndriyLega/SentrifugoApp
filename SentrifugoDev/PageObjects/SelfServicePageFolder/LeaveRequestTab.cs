using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SentrifugoDev.CommonLip;
using SentrifugoDev.Enums;
using SentrifugoDev.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SentrifugoDev.PageObjects.SelfServicePageFolder
{
    public class LeaveRequestTab
    {
        private IWebDriver driver;
        protected CommonMethods commonMethods;
        protected DatePickerCalendarPlugin datePickerCalendarPlugin;

        public LeaveRequestTab(IWebDriver driver)
        {
            this.driver = driver;
            commonMethods = new CommonMethods(driver);
            datePickerCalendarPlugin = new DatePickerCalendarPlugin(driver);
        }

        #region Leave Request Tab Elements

        private const string xpathInfoMessage = "//div[@class='info_div']";
        private readonly By InfoMessageLocator = By.XPath(xpathInfoMessage);

        private const string xpathApplyLeaveButton = "//input[@class='apply_button']";
        private readonly By ApplyLeaveButtonLocator = By.XPath(xpathApplyLeaveButton);

        private const string xpathWarningPopupMessage = "//div[@id='popup_message']";
        private readonly By WarningPopupMessageLocator = By.XPath(xpathWarningPopupMessage);

        private const string xpathWarningPopupButton = "//div[@id='popup_panel']//input[@type='button']";
        private readonly By WarningPopupButtonLocator = By.XPath(xpathWarningPopupButton);

        private const string xpathUIBlockWindow = "//div[@id='blockingdiv']";
        private readonly By UIBlockWindowLocator = By.XPath(xpathUIBlockWindow);

        #region Calendar Elements

        private const string xpathPreviousMonthButton = "//span[contains(@class,'fc-button-prev')]//span[@class='fc-text-arrow']";
        private readonly By PreviousMonthButtonLocator = By.XPath(xpathPreviousMonthButton);

        private const string xpathNextMonthButton = "//span[contains(@class,'fc-button-next')]//span[@class='fc-text-arrow']";
        private readonly By NextMonthButtonLocator = By.XPath(xpathNextMonthButton);

        private const string xpathCurrentMonthButton = "//span[contains(@class,'fc-button-today')]";
        private readonly By CurrentMonthButtonLocator = By.XPath(xpathCurrentMonthButton);

        private const string xpathListOfDaysOfSelectedMonth = "//td[contains(@class,'fc-widget-content fc-past') or contains(@class,'fc-widget-content fc-future') or contains(@class,'fc-widget-content fc-today')]";
        private readonly By ListOfDaysOfSelectedMonthLocator = By.XPath(xpathListOfDaysOfSelectedMonth);

        private const string xpathListOfWeekendsOfSelectedMonth = "//td[contains(@class,'fc-sat fc-widget-content ') or contains(@class,'fc-sun fc-widget-content ')]";
        private readonly By ListOfWeekendsOfSelectedMonthLocator = By.XPath(xpathListOfWeekendsOfSelectedMonth);

        private const string xpathRequestedLeavesOnCalendar = "//div[@class='fc-event-inner']";
        private readonly By RequestedLeavesOnCalendarLocator = By.XPath(xpathRequestedLeavesOnCalendar);

        #region Requested Leave Form Elements

        private const string xpathRequestedLeaveForm = "//div[@class='slimScrollDiv']";
        private readonly By RequestedLeaveFormLocator = By.XPath(xpathRequestedLeaveForm);

        private const string xpathStatusDropdawnField = "//div[@id='s2id_leaveactionid']";
        private readonly By StatusDropdawnFieldLocator = By.XPath(xpathStatusDropdawnField);

        private const string xpathSaveButtonOfRequestedLeaveForm = "//input[@name='submit' and @value='Save']";
        private readonly By SaveButtonOfRequestedLeaveForm = By.XPath(xpathSaveButtonOfRequestedLeaveForm);

        #endregion

        #endregion

        #region Create: Leave Request Form Elements

        private const string xpathLeaveRequestFormTitle = "//span[@id='ui-id-1']";
        private readonly By LeaveRequestFormTitleLocator = By.XPath(xpathLeaveRequestFormTitle);

        private const string xpathCloseLeaveRequestFormButton = "//button[contains(@class,'ui-dialog-titlebar-close')]";
        private readonly By CloseLeaveRequestFormButtonLocator = By.XPath(xpathCloseLeaveRequestFormButton);

        private const string xpathAvailableLeavesList = "//div[@class='main_view']//label";
        private readonly By AvailableLeavesListLocator = By.XPath(xpathAvailableLeavesList);

        private const string xpathLeaveTypeDropdown = "//div[@id='s2id_leavetypeid']";
        private readonly By LeaveTypeDropdownLocator = By.XPath(xpathLeaveTypeDropdown);

        private const string xpathLeaveTypeFieldWarningMessage = "//span[@id='errors-leavetypeid']";
        private readonly By LeaveTypeFieldWarningMessageLocator = By.XPath(xpathLeaveTypeFieldWarningMessage);

        #region Leave Type Options

        private const string xpathVacationOption = "//option[@label='Vacation']";
        private readonly By VacationOptionLocator = By.XPath(xpathVacationOption);

        private const string xpathMaternityLeaveOption = "//option[@label='Maternity Leave']";
        private readonly By MaternityLeaveOptionLocator = By.XPath(xpathMaternityLeaveOption);

        private const string xpathSickLeaveOption = "//option[@label='Sick Leave']";
        private readonly By SickLeaveOptionLocator = By.XPath(xpathSickLeaveOption);

        private const string xpathDayOffPaidOption = "//option[@label='Day-off paid']";
        private readonly By DayOffPaidOptionLocator = By.XPath(xpathDayOffPaidOption);

        private const string xpathDayOffUnpaidOption = "//option[@label='Day-off unpaid']";
        private readonly By DayOffUnpaidOptionLocator = By.XPath(xpathDayOffUnpaidOption);

        private const string xpathAvailableEventsOption = "//option[@label='Available Events']";
        private readonly By AvailableEventsOptionLocator = By.XPath(xpathAvailableEventsOption);

        #endregion

        private const string xpathReasonTextArea = "//textarea[@id='reason']";
        private readonly By ReasonTextAreaLocator = By.XPath(xpathReasonTextArea);

        private const string xpathReasonTextAreaWarningMessage = "//span[@id='errors-reason']";
        private readonly By ReasonTextAreaWarningMessageLocator = By.XPath(xpathReasonTextAreaWarningMessage);

        private const string xpathFromDateField = "//input[@id='from_date']";
        private readonly By FromDateFieldLocator = By.XPath(xpathFromDateField);

        private const string xpathFromDateFieldWarningMessage = "//span[@id='errors-from_date']";
        private readonly By FromDateFieldWarningMessageLocator = By.XPath(xpathFromDateFieldWarningMessage);

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

        private const string xpathListOfDaysOfSelectedMonthInDatePickerCalendar = "//td[@data-handler='selectDay']";
        private readonly By ListOfDaysOfSelectedMonthInDatePickerCalendarLocator = By.XPath(xpathListOfDaysOfSelectedMonthInDatePickerCalendar);

        #endregion

        private const string xpathToDateField = "//input[@id='to_date']";
        private readonly By ToDateFieldLocator = By.XPath(xpathToDateField);

        private const string xpathToDateFieldWarningMessage = "//span[@id='errors-to_date']";
        private readonly By ToDateFieldWarningMessageLocator = By.XPath(xpathToDateFieldWarningMessage);

        private const string xpathLeaveForDropdown = "//div[@id='s2id_leaveday']";
        private readonly By LeaveForDropdownLocator = By.XPath(xpathLeaveForDropdown);

        #region Leave For Options

        private const string xpathFullDayOption = "//option[@label='Full Day']";
        private readonly By FullDayOptionLocator = By.XPath(xpathFullDayOption);

        private const string xpathHalfDayOption = "//option[@label='Half Day']";
        private readonly By HalfDayOptionLocator = By.XPath(xpathHalfDayOption);

        #endregion

        private const string xpathDaysCountField = "//input[@id='appliedleavesdaycount']";
        private readonly By DaysCountFieldLocator = By.XPath(xpathDaysCountField);

        private const string xpathReportingManagerField = "//input[@id='rep_mang_id']";
        private readonly By DaysReportingManagerLocator = By.XPath(xpathReportingManagerField);

        private const string xpathApplyFormButton = "//input[@id='submitbutton']";
        private readonly By ApplyFormButtonLocator = By.XPath(xpathApplyFormButton);

        private const string xpathCancelFormButton = "//button[@id='Canceldialog']";
        private readonly By CancelFormButtonLocator = By.XPath(xpathCancelFormButton);

        #endregion

        #endregion



        #region Leave Request Tab Methods

        /// <summary>
        /// Method gets text text from Info Message in Leave Request tab and returns this value
        /// </summary>
        public string GetTextFromInfoMessageInLeaveRequestTab()
        {
            LogUtil.WriteDebug("Getting text from Info Message in Leave Request tab");
            return commonMethods.GetElementByWithLogs(driver, InfoMessageLocator, "Can NOT get text from Info Message in Leave Request tab").Text;
        }

        /// <summary>
        /// Method clicks on 'Apply Leave' button in Leave Request tab
        /// </summary>
        public void ClickApplyLeaveButton()
        {
            commonMethods.GetElementByWithLogs(driver, ApplyLeaveButtonLocator, "Can NOT click 'Apply Leave' button").Click();
            LogUtil.WriteDebug("Clicked on 'Apply Leave' button in Leave Request tab");
        }

        /// <summary>
        /// Method gets text from Warning popup message in Leave Request tab and returns this value
        /// </summary>
        public string GetTextFromWarningPopupMessageInLeaveRequestTab()
        {
            LogUtil.WriteDebug("Getting text from Warnind popup message in Leave Request tab");
            return commonMethods.GetElementByWithLogs(driver, WarningPopupMessageLocator, "Can NOT get text from Warnind popup message in Leave Request tab").Text;
        }

        /// <summary>
        /// Method clicks on 'OK' button of Warning popup in Leave Request tab
        /// </summary>
        public void ClickWarningPopupButton()
        {
            commonMethods.GetElementByWithLogs(driver, WarningPopupButtonLocator, "Can NOT click 'OK' button of Warning popup").Click();
            LogUtil.WriteDebug("Clicked on 'OK' button of Warning popup in Leave Request tab");
        }

        /// <summary>
        /// Method WAIT till opened window is closed and UI of page is unblocked
        /// </summary>
        public void WaitTillUIBlockWindowDisappears()
        {
            commonMethods.WaitForElementDisappears(UIBlockWindowLocator);
            LogUtil.WriteDebug("Waiting till the new password is sending ");
        }

        #region Calendar Methods

        /// <summary>
        /// Method clicks on 'Previous Month' button of Calendar in Leave Request tab
        /// </summary>
        public void ClickPreviousMonthButton()
        {
            commonMethods.GetElementByWithLogs(driver, PreviousMonthButtonLocator, "Can NOT click 'Previous Month' button").Click();
            LogUtil.WriteDebug("Clicked on 'Previous Month' button of Calendar in Leave Request tab");
        }

        /// <summary>
        /// Method clicks on 'Next Month' button of Calendar in Leave Request tab
        /// </summary>
        public void ClickNextMonthButton()
        {
            commonMethods.GetElementByWithLogs(driver, NextMonthButtonLocator, "Can NOT click 'Next Month' button").Click();
            LogUtil.WriteDebug("Clicked on 'Next Month' button of Calendar in Leave Request tab");
        }

        /// <summary>
        /// Method clicks on 'Today' button of Calendar in Leave Request tab
        /// </summary>
        public void ClickCurrentMonthButton()
        {
            commonMethods.GetElementByWithLogs(driver, CurrentMonthButtonLocator, "Can NOT click 'Today' button").Click();
            LogUtil.WriteDebug("Clicked on 'Today' button of Calendar in Leave Request tab");
        }

        /// <summary>
        /// Method selects range of day for Leave 
        /// </summary>
        /// <param name="startday"></param>
        /// <param name="endday"></param>
        public void SelectRangeOfLeaveDays(int startday, int endday)
        {
            var ListOfDaysOfSelectedMonth = driver.FindElements(ListOfDaysOfSelectedMonthLocator);
            var startDate = ListOfDaysOfSelectedMonth[startday - 1];
            var endDate = ListOfDaysOfSelectedMonth[endday - 1];
            Actions action = new Actions(driver);
            action.DragAndDrop(startDate, endDate);
            action.Build().Perform();
            LogUtil.WriteDebug("Select vacation from " + startday + "th till " + endday + "th");
        }

        /// <summary>
        /// Method selects weekends/holidays as vacation 
        /// </summary>
        /// <param name="day"></param>
        public void SelectWeekendsAsLeaveDays(int day)
        {
            var ListOfWeekendsOfSelectedMonth = driver.FindElements(ListOfWeekendsOfSelectedMonthLocator);
            var date = ListOfWeekendsOfSelectedMonth[day - 1];
            Actions action = new Actions(driver);
            action.Click(date);
            action.Build().Perform();
            LogUtil.WriteDebug("Select vacation on weekends/holidays " );
        }

        /// <summary>
        /// Method opens requsted leave item from Calendar plugine
        /// </summary>
        public void OpenRequestedLeaveFromCalendar()
        {
            commonMethods.GetElementByWithLogs(driver, RequestedLeavesOnCalendarLocator, "Can NOT click on requested leave item").Click();
            LogUtil.WriteDebug("Clicked on requested leave item on Calendar plugine");
        }

        #region Requested Leave Form

        /// <summary>
        /// Method clicks on 'Save' button in Requested Leave form window
        /// </summary>
        public void ClickSaveButtonOfRequestedLeaveForm()
        {
            commonMethods.GetElementByWithLogs(driver, SaveButtonOfRequestedLeaveForm, "Can NOT click 'Save' button in Requested Leave form window").Click();
            LogUtil.WriteDebug("Clicked on 'Save' button in Requested Leave form window");
        }

        /// <summary>
        /// Method checks if requested leaves displays on Calendar
        /// </summary>
        public bool IsLeavesRequestedSuccessfully()
        {
            LogUtil.WriteDebug("Checked if requested leaves displays on Calendar");
            return commonMethods.IsElementPresent(RequestedLeavesOnCalendarLocator);
        }

        #endregion

        #endregion

        #region Create: Leave Request Form Methods

        /// <summary>
        /// Method checks if Leave Request Form is opened in Leave Request tab
        /// </summary>
        public bool IsLeaveRequestFormPresent()
        {
            LogUtil.WriteDebug("Checks if Leave Request form is opened");
            return commonMethods.IsElementPresent(LeaveRequestFormTitleLocator);
        }

        /// <summary>
        /// Method gets text from title of 'Create: Leave request' form and returns this value
        /// </summary>
        public string GetTextFromTitleOfLeaveRequestForm()
        {
            LogUtil.WriteDebug("Getting text from title of 'Create: Leave request' form");
            return commonMethods.GetElementByWithLogs(driver, LeaveRequestFormTitleLocator, "Can NOT get text from title of 'Create: Leave request' form").Text;
        }

        /// <summary>
        /// Method clicks on 'Close' button of Leave Request form in Leave Request tab
        /// </summary>
        public void ClickCloseLeaveRequestFormButton()
        {
            commonMethods.GetElementByWithLogs(driver, CloseLeaveRequestFormButtonLocator, "Can NOT click 'Close' button of Leave Request form").Click();
            LogUtil.WriteDebug("Clicked on 'Close' button of Leave Request form in Leave Request tab");
        }

        /// <summary>
        /// Method gets data from Available Leaves list and writes this data in console
        /// </summary>
        public void GetDataFromAvailableLeavesList()
        {
            var ListOfItemInAvailableLeavesList = driver.FindElements(AvailableLeavesListLocator);
            Thread.Sleep(100);
            string name1 = ListOfItemInAvailableLeavesList[0].Text;
            string count1 = ListOfItemInAvailableLeavesList[1].Text;
            string name2 = ListOfItemInAvailableLeavesList[2].Text;
            string count2 = ListOfItemInAvailableLeavesList[3].Text;
            string name3 = ListOfItemInAvailableLeavesList[4].Text;
            string count3 = ListOfItemInAvailableLeavesList[5].Text;
            string name4 = ListOfItemInAvailableLeavesList[6].Text;
            string count4 = ListOfItemInAvailableLeavesList[7].Text;
            string name5 = ListOfItemInAvailableLeavesList[8].Text;
            string count5 = ListOfItemInAvailableLeavesList[9].Text;
            string name6 = ListOfItemInAvailableLeavesList[10].Text;
            string count6 = ListOfItemInAvailableLeavesList[11].Text;
            string name7 = ListOfItemInAvailableLeavesList[12].Text;
            string count7 = ListOfItemInAvailableLeavesList[13].Text;
            LogUtil.WriteDebug("Available Leaves: " + name1 + count1 + " , " + name2 + count2 + " , " + name3 + count3 + " , " + name4 + count4 + " , " + name5 + count5 + " , " + name6 + count6 + " , " + name7 + count7);
        }

        /// <summary>
        /// Methods clicks on option: 'Vacation', 'Maternity Leave', 'Sick Leave', 'Dayoffpaid', 'Dayoffunpaid' or 'AvailableEvents' in 'Leave Type' dropdown
        /// </summary>
        public void SelecLeaveTypeDropdownOption(LeaveTypesDropDownOptions options)
        {
            commonMethods.GetElementByWithLogs(driver, LeaveTypeDropdownLocator, "Can NOT click on 'Leave Type' DropDown").Click();
            LogUtil.WriteDebug("Clicked on 'Leave Type' DropDown");
            switch (options)
            {
                case LeaveTypesDropDownOptions.Vacation:
                    {
                        commonMethods.GetElementByWithLogs(driver, VacationOptionLocator, "Can NOT click on 'Vacation' option").Click();
                        LogUtil.WriteDebug("Clicked on Vacation option in 'Leave Type'");
                        break;
                    }

                case LeaveTypesDropDownOptions.MaternityLeave:
                    {
                        commonMethods.GetElementByWithLogs(driver, MaternityLeaveOptionLocator, "Can NOT click on 'Maternity Leave' option").Click();
                        LogUtil.WriteDebug("Clicked on Maternity Leave option in 'Leave Type'");
                        break;
                    }

                case LeaveTypesDropDownOptions.SickLeave:
                    {
                        commonMethods.GetElementByWithLogs(driver, SickLeaveOptionLocator, "Can NOT click on 'Sick Leave' option").Click();
                        LogUtil.WriteDebug("Clicked on Sick Leave option in 'Leave Type'");
                        break;
                    }

                case LeaveTypesDropDownOptions.Dayoffpaid:
                    {
                        commonMethods.GetElementByWithLogs(driver, DayOffPaidOptionLocator, "Can NOT click on 'Day-off paid' option").Click();
                        LogUtil.WriteDebug("Clicked on Day-off paid option in 'Leave Type'");
                        break;
                    }

                case LeaveTypesDropDownOptions.Dayoffunpaid:
                    {
                        commonMethods.GetElementByWithLogs(driver, DayOffUnpaidOptionLocator, "Can NOT click on 'Day-off unpaid' option").Click();
                        LogUtil.WriteDebug("Clicked on Day-off unpaid option in 'Leave Type'");
                        break;
                    }

                case LeaveTypesDropDownOptions.AvailableEvents:
                    {
                        commonMethods.GetElementByWithLogs(driver, AvailableEventsOptionLocator, "Can NOT click on 'Available Events' option").Click();
                        LogUtil.WriteDebug("Clicked on Available Events option in 'Leave Type'");
                        break;
                    }
            }
        }

        /// <summary>
        /// Method gets text from error message for 'Leave Type' field in the Create: Leave request Form and returns this value
        /// </summary>
        public string GetTextFromErrorMessageLeaveTypeFieldInLeaveRequestForm()
        {
            LogUtil.WriteDebug("Getting text from error message for 'Leave Type' field in the Create: Leave request Form");
            return commonMethods.GetElementByWithLogs(driver, LeaveTypeFieldWarningMessageLocator, "Can NOT get text from error message for 'Leave Type' field  in the Create: Leave request Form").Text;
        }

        /// <summary>
        /// Method fills in 'Reason' field in the Create: Leave request Form
        /// </summary>
        public void FillInReasonFieldInLeaveRequestForm(string reasonValue)
        {
            commonMethods.GetElementByWithLogs(driver, ReasonTextAreaLocator, "Can NOT fill in 'Reason' field").SendKeys(reasonValue);
            LogUtil.WriteDebug("Filled in Reason field in the Create: Leave request Form with data: " + reasonValue);
        }

        /// <summary>
        /// Method gets text from error message for 'Reason' text area  in the Create: Leave request Form and returns this value
        /// </summary>
        public string GetTextFromErrorMessageReasonTextAreaInLeaveRequestForm()
        {
            LogUtil.WriteDebug("Getting text from error message for 'Reason' text area  in the Create: Leave request Form");
            return commonMethods.GetElementByWithLogs(driver, ReasonTextAreaWarningMessageLocator, "Can NOT get text from error message for 'Reason' text area  in the Create: Leave request Form").Text;
        }

        /// <summary>
        /// Method clears and then fills in 'From' field with data in the Create: Leave request Form
        /// </summary>
        public void FillInFromDateFieldInLeaveRequestForm(int year, int month, int day)
        {
            ClearFromFieldInLeaveRequestForm();
            commonMethods.GetElementByWithLogs(driver, FromDateFieldLocator, "Can NOT fill in 'From' field").SendKeys(year + "/" + month + "/" + day);
            LogUtil.WriteDebug("Filled in From field in the Create: Leave request Form with data: " + year + "/" + month + "/" + day);
        }

        /// <summary>
        /// Method clears and then fills in 'To' field with data in the Create: Leave request Form
        /// </summary>
        public void FillInToDateFieldInLeaveRequestForm(int year, int month, int day)
        {
            ClearToFieldInLeaveRequestForm();
            commonMethods.GetElementByWithLogs(driver, ToDateFieldLocator, "Can NOT fill in 'To' field").SendKeys(year + "/" + month + "/" + day);
            LogUtil.WriteDebug("Filled in To field in the Create: Leave request Form with data: " + year + "/" + month + "/" + day);
        }

        /// <summary>
        /// Method selects data in From field in the Create: Leave request Form 
        /// </summary>
        public void FillInFromDateFieldByDatePickerCalendar(int day)
        {
            commonMethods.GetElementByWithLogs(driver, FromDateFieldLocator, "Can NOT fill in 'From' field").Click();
            datePickerCalendarPlugin.SelectDateByDatePickerCalendar(day);
            LogUtil.WriteDebug("Selected " + day + " in From field in the Create: Leave request Form ");
        }

        /// <summary>
        /// Method selects data in To field in the Create: Leave request Form 
        /// </summary>
        public void FillInToDateFieldByDatePickerCalendar(int day)
        {
            commonMethods.GetElementByWithLogs(driver, ToDateFieldLocator, "Can NOT fill in 'To' field").Click();
            datePickerCalendarPlugin.SelectDateByDatePickerCalendar(day);
            LogUtil.WriteDebug("Selected " + day + " in To field in the Create: Leave request Form ");
        }

        /// <summary>
        /// Method clicks on 'From' field of Leave Request form in Leave Request tab
        /// </summary>
        public void ClickOnFromFieldInLeaveRequestForm()
        {
            commonMethods.GetElementByWithLogs(driver, FromDateFieldLocator, "Can NOT click on 'From' field of Leave Request form in Leave Request tab").Click();
            LogUtil.WriteDebug("Clicked on 'From' field of Leave Request form in Leave Request tab");
        }

        /// <summary>
        /// Method clicks on 'To' field of Leave Request form in Leave Request tab
        /// </summary>
        public void ClickOnToFieldInLeaveRequestForm()
        {
            commonMethods.GetElementByWithLogs(driver, ToDateFieldLocator, "Can NOT click on 'To' field of Leave Request form in Leave Request tab").Click();
            LogUtil.WriteDebug("Clicked on 'To' field of Leave Request form in Leave Request tab");
        }

        /// <summary>
        /// Method clears 'From' field of Leave Request form in Leave Request tab
        /// </summary>
        public void ClearFromFieldInLeaveRequestForm()
        {
            commonMethods.GetElementByWithLogs(driver, FromDateFieldLocator, "Can NOT clear 'From' field of Leave Request form in Leave Request tab").Clear();
            LogUtil.WriteDebug("Cleared 'From' field of Leave Request form in Leave Request tab");
        }

        /// <summary>
        /// Method clears 'To' field of Leave Request form in Leave Request tab
        /// </summary>
        public void ClearToFieldInLeaveRequestForm()
        {
            commonMethods.GetElementByWithLogs(driver, ToDateFieldLocator, "Can NOT clear 'To' field of Leave Request form in Leave Request tab").Clear();
            LogUtil.WriteDebug("Cleared 'To' field of Leave Request form in Leave Request tab");
        }

        /// <summary>
        /// Method gets text from error message for 'From' field  in the Create: Leave request Form and returns this value
        /// </summary>
        public string GetTextFromErrorMessageFromDateFieldInLeaveRequestForm()
        {
            LogUtil.WriteDebug("Getting text from error message for 'From' field  in the Create: Leave request Form");
            return commonMethods.GetElementByWithLogs(driver, FromDateFieldWarningMessageLocator, "Can NOT get text from error message for 'From' field  in the Create: Leave request Form ").Text;
        }

        /// <summary>
        /// Method gets  text from error message for 'To' field  in the Create: Leave request Form and returns this value
        /// </summary>
        public string GetTextFromErrorMessageToDateFieldInLeaveRequestForm()
        {
            LogUtil.WriteDebug("Getting text from error message for 'To' field  in the Create: Leave request Form");
            return commonMethods.GetElementByWithLogs(driver, ToDateFieldWarningMessageLocator, "Can NOT get text from error message for 'To' field  in the Create: Leave request Form").Text;
        }

        /// <summary>
        /// Method clicks on 'From' field and selects date in by Date picker calendar in the Create: Leave request Form
        /// </summary>
        public void SelectDateByDatePickerCalendarInFromField(int fromday)
        {
            ClickOnFromFieldInLeaveRequestForm();
            datePickerCalendarPlugin.SelectDateByDatePickerCalendar(fromday);
            LogUtil.WriteDebug("Selected the date " + (fromday) + "in 'From' field in the Create: Leave request Form by Date picker calendar plugin");
        }

        /// <summary>
        /// Method clicks on 'To' field and selects date in by Date picker calendar in the Create: Leave request Form
        /// </summary>
        public void SelectDateByDatePickerCalendarInToField(int today)
        {
            ClickOnToFieldInLeaveRequestForm();
            datePickerCalendarPlugin.SelectDateByDatePickerCalendar(today);
            LogUtil.WriteDebug("Selected the date " + (today) + "in 'To' field in the Create: Leave request Form by Date picker calendar plugin");
        }

        /// <summary>
        /// Methods clicks on option: 'Full Day' or 'Half Day' in 'Leave For' dropdown in Create: Leave Request form
        /// </summary>
        public void SelecLeaveForDropdownOption(LeaveForDropDownOptions options)
        {
            commonMethods.GetElementByWithLogs(driver, LeaveForDropdownLocator, "Can NOT click on 'Leave For' dropdown in Create: Leave Request form").Click();
            LogUtil.WriteDebug("Clicked on 'Leave For' dropdown in Create: Leave Request form");
            switch (options)
            {
                case LeaveForDropDownOptions.FullDay:
                    {
                        commonMethods.GetElementByWithLogs(driver, FullDayOptionLocator, "Can NOT click on 'Full Day' option in 'Leave For' dropdown").Click();
                        LogUtil.WriteDebug("Clicked on Full Day option in 'Leave For' dropdown");
                        break;
                    }

                case LeaveForDropDownOptions.HalfDay:
                    {
                        commonMethods.GetElementByWithLogs(driver, HalfDayOptionLocator, "Can NOT click on 'Half Day' option in 'Leave For' dropdown").Click();
                        LogUtil.WriteDebug("Clicked on Half Day option in 'Leave For' dropdown");
                        break;
                    }
            }
        }

        /// <summary>
        /// Method gets data from 'Days' field  in the Create: Leave request Form and returns this value
        /// </summary>
        public string GetDataFromDaysFieldInLeaveRequestForm()
        {
            LogUtil.WriteDebug("Getting data from 'Days' field  in the Create: Leave request Form");
            return commonMethods.GetElementByWithLogs(driver, DaysCountFieldLocator, "Can NOT get data from 'Days' field  in the Create: Leave request Form").Text;
        }

        /// <summary>
        /// Method gets data from 'Reporting Manager' field  in the Create: Leave request Form and returns this value
        /// </summary>
        public string GetDataFromReportingManagerFieldInLeaveRequestForm()
        {
            LogUtil.WriteDebug("Getting data from 'Reporting Manager' field  in the Create: Leave request Form");
            return commonMethods.GetElementByWithLogs(driver, DaysReportingManagerLocator, "Can NOT get data from 'Reporting Manager' field  in the Create: Leave request Form").Text;
        }

        /// <summary>
        /// Method clicks on 'Apply' button of Leave Request form in Leave Request tab
        /// </summary>
        public void ClickApplyButtonOfLeaveRequestForm()
        {
            commonMethods.GetElementByWithLogs(driver, ApplyFormButtonLocator, "Can NOT click 'Apply' button of Leave Request form").Click();
            LogUtil.WriteDebug("Clicked on 'Apply' button of Leave Request form in Leave Request tab");
        }

        /// <summary>
        /// Method clicks on 'Cancel' button of Leave Request form in Leave Request tab
        /// </summary>
        public void ClickCancelButtonOfLeaveRequestForm()
        {
            commonMethods.GetElementByWithLogs(driver, CancelFormButtonLocator, "Can NOT click 'Cancel' button of Leave Request form").Click();
            LogUtil.WriteDebug("Clicked on 'Cancel' button of Leave Request form in Leave Request tab");
        }

        #endregion

        #endregion
    }
}
