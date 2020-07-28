using NUnit.Framework;
using OpenQA.Selenium;
using SentrifugoDev.CommonLip;
using SentrifugoDev.Enums;
using SentrifugoDev.PageObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SentrifugoDev.CommonLip.CommonMethods;

namespace SentrifugoDev.UITests
{
    public class SelfServiceTests : BaseTest
    {

        [TearDown]
        public void LogOutFromSystem()
        {
            header.SelectUserMenuOption(UserMenuDropDownOptions.Logout);
            logInPage.WaitUntilLoginPageAppears();
        }

        #region Leave Request Tab Tests

        [Test, Order(1), Category("SelfService page"), Category("Leave Request Tab")]
        public void CheckIfItIsImpossibleToRequestLeaveOnPreviousMonth()
        {
            LogInToSystemWithEmployeeRole();
            header.GoToSelfServicePage();
            selfServicePage.OpenLeavesDropdownList();
            selfServicePage.ClickLeaveRequestButton();
            selfServicePage.leaveRequestTab.ClickPreviousMonthButton();
            selfServicePage.leaveRequestTab.SelectRangeOfLeaveDays(2, 5);
            string warningPopupMessageInLeaveRequestTab = selfServicePage.leaveRequestTab.GetTextFromWarningPopupMessageInLeaveRequestTab();
            selfServicePage.leaveRequestTab.ClickWarningPopupButton();
            selfServicePage.leaveRequestTab.WaitTillUIBlockWindowDisappears();
            Assert.IsTrue(warningPopupMessageInLeaveRequestTab.Equals(leaveRequesrTabModel.PreviousMonthPopupWarningMessage), "Warning message is NOT correct. Actual result: "
                + warningPopupMessageInLeaveRequestTab + "  Expected result: " + leaveRequesrTabModel.PreviousMonthPopupWarningMessage);
        }

        [Test, Order(2), Category("SelfService page"), Category("Leave Request Tab")]
        public void CheckIfLeaveTypeFieldIsReqiuredInLeaveRequestForm()
        {
            LogInToSystemWithEmployeeRole();
            header.GoToSelfServicePage();
            selfServicePage.OpenLeavesDropdownList();
            selfServicePage.ClickLeaveRequestButton();
            selfServicePage.leaveRequestTab.ClickApplyLeaveButton();
            selfServicePage.leaveRequestTab.ClickCloseLeaveRequestFormButton();
            selfServicePage.leaveRequestTab.ClickApplyLeaveButton();
            selfServicePage.leaveRequestTab.FillInReasonFieldInLeaveRequestForm("test1");
            selfServicePage.leaveRequestTab.ClickApplyButtonOfLeaveRequestForm();
            string errorMessageOfLeaveTypeFieldInLeaveRequestForm = selfServicePage.leaveRequestTab.GetTextFromErrorMessageLeaveTypeFieldInLeaveRequestForm();
            selfServicePage.leaveRequestTab.ClickCloseLeaveRequestFormButton();
            selfServicePage.leaveRequestTab.WaitTillUIBlockWindowDisappears();
            Assert.IsTrue(errorMessageOfLeaveTypeFieldInLeaveRequestForm.Equals(leaveRequesrTabModel.EmptyLeaveTypeFieldWarningMessage), "Warning message is NOT correct. Actual result: "
                + errorMessageOfLeaveTypeFieldInLeaveRequestForm + "  Expected result: " + leaveRequesrTabModel.EmptyLeaveTypeFieldWarningMessage);
        }

        [Test, Order(3), Category("SelfService page"), Category("Leave Request Tab")]
        public void CheckIfReasonTextAreaIsReqiuredInLeaveRequestForm()
        {
            LogInToSystemWithEmployeeRole();
            header.GoToSelfServicePage();
            selfServicePage.OpenLeavesDropdownList();
            selfServicePage.ClickLeaveRequestButton();
            selfServicePage.leaveRequestTab.ClickApplyLeaveButton();
            selfServicePage.leaveRequestTab.SelecLeaveTypeDropdownOption(LeaveTypesDropDownOptions.SickLeave);
            selfServicePage.leaveRequestTab.ClickApplyButtonOfLeaveRequestForm();
            string errorMessageOfReasonTextAreaInLeaveRequestForm = selfServicePage.leaveRequestTab.GetTextFromErrorMessageReasonTextAreaInLeaveRequestForm();
            selfServicePage.leaveRequestTab.ClickCloseLeaveRequestFormButton();
            selfServicePage.leaveRequestTab.WaitTillUIBlockWindowDisappears();
            Assert.IsTrue(errorMessageOfReasonTextAreaInLeaveRequestForm.Equals(leaveRequesrTabModel.EmptyReasonTextAreaWarningMessage), "Warning message is NOT correct. Actual result: "
                + errorMessageOfReasonTextAreaInLeaveRequestForm + "  Expected result: " + leaveRequesrTabModel.EmptyReasonTextAreaWarningMessage);
        }

        [Test, Order(4), Category("SelfService page"), Category("Leave Request Tab")]
        public void CheckIfFromFieldIsReqiuredInLeaveRequestForm()
        {
            LogInToSystemWithEmployeeRole();
            header.GoToSelfServicePage();
            selfServicePage.OpenLeavesDropdownList();
            selfServicePage.ClickLeaveRequestButton();
            selfServicePage.leaveRequestTab.ClickApplyLeaveButton();
            selfServicePage.leaveRequestTab.SelecLeaveTypeDropdownOption(LeaveTypesDropDownOptions.SickLeave);
            selfServicePage.leaveRequestTab.ClearFromFieldInLeaveRequestForm();
            string errorMessageOfFromDateFieldInLeaveRequestForm = selfServicePage.leaveRequestTab.GetTextFromErrorMessageFromDateFieldInLeaveRequestForm();
            selfServicePage.leaveRequestTab.ClickCloseLeaveRequestFormButton();
            selfServicePage.leaveRequestTab.WaitTillUIBlockWindowDisappears();
            Assert.IsTrue(errorMessageOfFromDateFieldInLeaveRequestForm.Equals(leaveRequesrTabModel.EmptyDateFieldWarningMessage), "Warning message is NOT correct. Actual result: "
                + errorMessageOfFromDateFieldInLeaveRequestForm + "  Expected result: " + leaveRequesrTabModel.EmptyDateFieldWarningMessage);
        }

        [Test, Order(5), Category("SelfService page"), Category("Leave Request Tab")]
        public void CheckIfToFieldIsReqiuredInLeaveRequestForm()
        {
            LogInToSystemWithEmployeeRole();
            header.GoToSelfServicePage();
            selfServicePage.OpenLeavesDropdownList();
            selfServicePage.ClickLeaveRequestButton();
            selfServicePage.leaveRequestTab.ClickApplyLeaveButton();
            selfServicePage.leaveRequestTab.SelecLeaveTypeDropdownOption(LeaveTypesDropDownOptions.SickLeave);
            selfServicePage.leaveRequestTab.ClearToFieldInLeaveRequestForm();
            string errorMessageOfToDateFieldInLeaveRequestForm = selfServicePage.leaveRequestTab.GetTextFromErrorMessageToDateFieldInLeaveRequestForm();
            selfServicePage.leaveRequestTab.ClickCloseLeaveRequestFormButton();
            selfServicePage.leaveRequestTab.WaitTillUIBlockWindowDisappears();
            Assert.IsTrue(errorMessageOfToDateFieldInLeaveRequestForm.Equals(leaveRequesrTabModel.EmptyDateFieldWarningMessage), "Warning message is NOT correct. Actual result: "
                + errorMessageOfToDateFieldInLeaveRequestForm + "  Expected result: " + leaveRequesrTabModel.EmptyDateFieldWarningMessage);
        }

        [Test, Order(6), Category("SelfService page"), Category("Leave Request Tab")]
        [TestCase(7,9)]
        public void CheckValidationOfDateRangeOfFromDateFieldAndToDateFieldInLeaveRequestForm(int fromday, int today)
        {
            LogInToSystemWithEmployeeRole();
            header.GoToSelfServicePage();
            selfServicePage.OpenLeavesDropdownList();
            selfServicePage.ClickLeaveRequestButton();
            selfServicePage.leaveRequestTab.SelectRangeOfLeaveDays(fromday, today);
            selfServicePage.leaveRequestTab.SelecLeaveTypeDropdownOption(LeaveTypesDropDownOptions.SickLeave);
            selfServicePage.leaveRequestTab.FillInToDateFieldByDatePickerCalendar(fromday - 1);
            string errorMessageOfToDateFieldInLeaveRequestForm = selfServicePage.leaveRequestTab.GetTextFromErrorMessageToDateFieldInLeaveRequestForm();
            selfServicePage.leaveRequestTab.FillInToDateFieldByDatePickerCalendar(today);
            selfServicePage.leaveRequestTab.FillInFromDateFieldByDatePickerCalendar(today+1);
            string errorMessageOfFromDateFieldInLeaveRequestForm = selfServicePage.leaveRequestTab.GetTextFromErrorMessageFromDateFieldInLeaveRequestForm();
            selfServicePage.leaveRequestTab.ClickCloseLeaveRequestFormButton();
            selfServicePage.leaveRequestTab.WaitTillUIBlockWindowDisappears();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(errorMessageOfToDateFieldInLeaveRequestForm.Equals(leaveRequesrTabModel.IncorrectToDateWarningMessage), "Warning message is NOT correct. Actual result: "
                + errorMessageOfToDateFieldInLeaveRequestForm + "  Expected result: " + leaveRequesrTabModel.IncorrectToDateWarningMessage);
                Assert.IsTrue(errorMessageOfFromDateFieldInLeaveRequestForm.Equals(leaveRequesrTabModel.IncorrectFromDateWarningMessage), "Warning message is NOT correct. Actual result: "
                + errorMessageOfFromDateFieldInLeaveRequestForm + "  Expected result: " + leaveRequesrTabModel.IncorrectFromDateWarningMessage);
            });
        }

        [Test, Order(7), Category("SelfService page"), Category("Leave Request Tab")]
        [TestCase(7, 9)]
        public void CheckSuccessfullApplyOfFullDayLeavesRequest(int fromday, int today)
        {
            LogInToSystemWithEmployeeRole();
            header.GoToSelfServicePage();
            selfServicePage.ClickMyLeaveButton();
            selfServicePage.myLeaveTab.ClickPendingLeavesFilterButton();
            int pendingLeavesBefore = tablePlugin.CountOfAllRecordsInTheTable();
            selfServicePage.ClickLeaveRequestButton();
            selfServicePage.leaveRequestTab.SelectRangeOfLeaveDays(fromday, today);
            selfServicePage.leaveRequestTab.SelecLeaveTypeDropdownOption(LeaveTypesDropDownOptions.Vacation);
            selfServicePage.leaveRequestTab.FillInReasonFieldInLeaveRequestForm("Reason test success leave");
            selfServicePage.leaveRequestTab.ClickApplyButtonOfLeaveRequestForm();
            string succesMessage = selfServicePage.myLeaveTab.GetTextFromSuccessfullActionMessage();
            int pendingLeavesAfter = tablePlugin.CountOfAllRecordsInTheTable();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(succesMessage.Equals("Leave request added successfully."), "Success message is NOT correct. Actual result: "
                + succesMessage + "  Expected result: Leave request added successfully.");
                Assert.IsTrue(pendingLeavesAfter.Equals(pendingLeavesBefore + 1), "Created leave was not added to the Pending Leaves list. Expected count of records after appling leave " + (pendingLeavesBefore + 1) + ".Actualresult: " + pendingLeavesAfter);
                Assert.IsTrue(selfServicePage.myLeaveTab.CheckIfNumberOfLeavesCountedCorrectlyInPendingLeavesFilterButtonBadge());
            });
        }

        [Test, Order(8), Category("SelfService page"), Category("Leave Request Tab")]
        public void CheckSuccessfullApplyOfHalfDayLeavesRequest(int fromday = 3, int today = 3)
        {
            LogInToSystemWithEmployeeRole();
            header.GoToSelfServicePage();
            selfServicePage.ClickMyLeaveButton();
            selfServicePage.myLeaveTab.ClickPendingLeavesFilterButton();
            int pendingLeavesBefore = tablePlugin.CountOfAllRecordsInTheTable();
            selfServicePage.ClickLeaveRequestButton();
            selfServicePage.leaveRequestTab.SelectRangeOfLeaveDays(fromday, today);
            selfServicePage.leaveRequestTab.SelecLeaveTypeDropdownOption(LeaveTypesDropDownOptions.SickLeave);
            selfServicePage.leaveRequestTab.FillInReasonFieldInLeaveRequestForm("TwoLeaves");
            selfServicePage.leaveRequestTab.SelecLeaveForDropdownOption(LeaveForDropDownOptions.HalfDay);
            selfServicePage.leaveRequestTab.ClickApplyButtonOfLeaveRequestForm();
            string succesMessage = selfServicePage.myLeaveTab.GetTextFromSuccessfullActionMessage();
            int pendingLeavesAfter = tablePlugin.CountOfAllRecordsInTheTable();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(succesMessage.Equals("Leave was applied successfully."), "Success message is NOT correct. Actual result: "
                + succesMessage + "  Expected result: Leave was applied successfully.");
                Assert.IsTrue(pendingLeavesAfter.Equals(pendingLeavesBefore + 1), "Created leave was not added to the Pending Leaves list. Expected count of records after appling leave " + (pendingLeavesBefore + 1) + ".Actualresult: " + pendingLeavesAfter);
                Assert.IsTrue(selfServicePage.myLeaveTab.CheckIfNumberOfLeavesCountedCorrectlyInPendingLeavesFilterButtonBadge());
            });
        }

        [Test, Order(9), Category("SelfService page"), Category("Leave Request Tab")]
        public void CheckIfItIsImpossibleToRequestTwoLeavesInOneDay()
        {
            LogInToSystemWithEmployeeRole();
            header.GoToSelfServicePage();
            CheckSuccessfullApplyOfFullDayLeavesRequest(10,12);
            selfServicePage.ClickLeaveRequestButton();
            selfServicePage.leaveRequestTab.SelectRangeOfLeaveDays(10, 12);
            selfServicePage.leaveRequestTab.SelecLeaveTypeDropdownOption(LeaveTypesDropDownOptions.SickLeave);
            selfServicePage.leaveRequestTab.FillInReasonFieldInLeaveRequestForm("TwoLeaves");
            selfServicePage.leaveRequestTab.ClickApplyButtonOfLeaveRequestForm();
            string errorMessageOfFromDateFieldInLeaveRequestForm = selfServicePage.leaveRequestTab.GetTextFromErrorMessageFromDateFieldInLeaveRequestForm();
            selfServicePage.leaveRequestTab.ClickCloseLeaveRequestFormButton();
            selfServicePage.leaveRequestTab.WaitTillUIBlockWindowDisappears();
            Assert.Multiple(() =>
            {
                Assert.IsTrue(errorMessageOfFromDateFieldInLeaveRequestForm.Equals(leaveRequesrTabModel.AppliedLeaveAboutDateWarningMessage), "Warning message is NOT correct. Actual result: "
                + errorMessageOfFromDateFieldInLeaveRequestForm + "  Expected result: " + leaveRequesrTabModel.AppliedLeaveAboutDateWarningMessage);
            });
        }

        [Test, Order(10), Category("SelfService page"), Category("Leave Request Tab")]
        public void CheckIfItIsImpossibleToRequestLeaveOnWeekendOrHolidays()
        {
            LogInToSystemWithEmployeeRole();
            header.GoToSelfServicePage();
            selfServicePage.OpenLeavesDropdownList();
            selfServicePage.ClickLeaveRequestButton();
            selfServicePage.leaveRequestTab.SelectWeekendsAsLeaveDays(7);
            string warningPopupMessageInLeaveRequestTab = selfServicePage.leaveRequestTab.GetTextFromWarningPopupMessageInLeaveRequestTab();
            selfServicePage.leaveRequestTab.ClickWarningPopupButton();
            selfServicePage.leaveRequestTab.WaitTillUIBlockWindowDisappears();
            Assert.IsTrue(warningPopupMessageInLeaveRequestTab.Equals(leaveRequesrTabModel.WeekendHolodaysPopupWarningMessage), "Warning message is NOT correct. Actual result: "
                + warningPopupMessageInLeaveRequestTab + "  Expected result: " + leaveRequesrTabModel.WeekendHolodaysPopupWarningMessage);
        }

        [Test, Order(11), Category("SelfService page"), Category("Leave Request Tab")]
        public void CheckIfItIsImpossibleToRequestLeavesOnFutureYear()
        {
            LogInToSystemWithEmployeeRole();
            header.GoToSelfServicePage();
            selfServicePage.OpenLeavesDropdownList();
            selfServicePage.ClickLeaveRequestButton();
            selfServicePage.leaveRequestTab.SelectRangeOfLeaveDays(4, 7);
            selfServicePage.leaveRequestTab.SelecLeaveTypeDropdownOption(LeaveTypesDropDownOptions.SickLeave);
            selfServicePage.leaveRequestTab.FillInReasonFieldInLeaveRequestForm("TwoLeaves");
            selfServicePage.leaveRequestTab.ClickOnFromFieldInLeaveRequestForm();
            datePickerCalendarPlugine.SelectYearInDatePickerCalendar(YearList.NextYear);
            selfServicePage.leaveRequestTab.ClickOnFromFieldInLeaveRequestForm();
            datePickerCalendarPlugine.SelectDateByDatePickerCalendar(10);
            selfServicePage.leaveRequestTab.ClickOnToFieldInLeaveRequestForm();
            datePickerCalendarPlugine.SelectYearInDatePickerCalendar(YearList.NextYear);
            selfServicePage.leaveRequestTab.ClickOnToFieldInLeaveRequestForm();
            datePickerCalendarPlugine.SelectDateByDatePickerCalendar(10);
            string errorMessageOfFromDateFieldInLeaveRequestForm = selfServicePage.leaveRequestTab.GetTextFromErrorMessageFromDateFieldInLeaveRequestForm();
            string errorMessageOfToDateFieldInLeaveRequestForm = selfServicePage.leaveRequestTab.GetTextFromErrorMessageToDateFieldInLeaveRequestForm();
            selfServicePage.leaveRequestTab.ClickCloseLeaveRequestFormButton();
            selfServicePage.leaveRequestTab.WaitTillUIBlockWindowDisappears();
            Assert.Multiple(() =>
            {
                Assert.IsTrue(errorMessageOfFromDateFieldInLeaveRequestForm.Equals(leaveRequesrTabModel.FutureYearWarningMessage), "Warning message is NOT correct. Actual result: "
                + errorMessageOfFromDateFieldInLeaveRequestForm + "  Expected result: " + leaveRequesrTabModel.FutureYearWarningMessage);
                Assert.IsTrue(errorMessageOfToDateFieldInLeaveRequestForm.Equals(leaveRequesrTabModel.FutureYearWarningMessage), "Warning message is NOT correct. Actual result: "
                + errorMessageOfToDateFieldInLeaveRequestForm + "  Expected result: " + leaveRequesrTabModel.FutureYearWarningMessage);
            });
        }

        [Test, Order(12), Category("SelfService page"), Category("Leave Request Tab")]
        public void GetTheListOfAvailableLeaves()
        {
            LogInToSystemWithEmployeeRole();
            header.GoToSelfServicePage();
            selfServicePage.OpenLeavesDropdownList();
            selfServicePage.ClickLeaveRequestButton();
            selfServicePage.leaveRequestTab.SelectRangeOfLeaveDays(4, 7);
            selfServicePage.leaveRequestTab.GetDataFromAvailableLeavesList();
            selfServicePage.leaveRequestTab.ClickCloseLeaveRequestFormButton();
            selfServicePage.leaveRequestTab.WaitTillUIBlockWindowDisappears();
        }

        #endregion

        #region My Leave Tab Tests

        [Test, Order(13), Category("SelfService page"), Category("My Leave Tab")]
        public void CheckIfLeavesCountedCorrectlyInEachFilterTableInMyLeaveTap()
        {
            LogInToSystemWithEmployeeRole();
            header.GoToSelfServicePage();
            selfServicePage.ClickMyLeaveButton();
            selfServicePage.myLeaveTab.ClickAllFilterButton();
            bool badgeNumberOfAllLeaves = selfServicePage.myLeaveTab.CheckIfNumberOfLeavesCountedCorrectlyInAllLeavesFilterButtonBadge();
            int allLeavesCount = tablePlugin.CountOfAllRecordsInTheTable();
            selfServicePage.myLeaveTab.ClickPendingLeavesFilterButton();
            bool badgeNumberOfPendingLeaves = selfServicePage.myLeaveTab.CheckIfNumberOfLeavesCountedCorrectlyInPendingLeavesFilterButtonBadge();
            int pendingLeavesCount = tablePlugin.CountOfAllRecordsInTheTable();
            selfServicePage.myLeaveTab.ClickCanceledLeavesFilterButton();
            bool badgeNumberOfCanceledLeaves = selfServicePage.myLeaveTab.CheckIfNumberOfLeavesCountedCorrectlyInCanceledLeavesFilterButtonBadge();
            int canceledLeavesCount = tablePlugin.CountOfAllRecordsInTheTable();
            selfServicePage.myLeaveTab.ClickRejectedLeavesFilterButton();
            bool badgeNumberOfRejectedLeaves = selfServicePage.myLeaveTab.CheckIfNumberOfLeavesCountedCorrectlyInRejectedLeavesFilterButtonBadge();
            int rejectedLeavesCount = tablePlugin.CountOfAllRecordsInTheTable();
            selfServicePage.myLeaveTab.ClickApprovedLeavesFilterButton();
            bool badgeNumberOfApprovedLeaves = selfServicePage.myLeaveTab.CheckIfNumberOfLeavesCountedCorrectlyInApprovedLeavesFilterButtonBadge();
            int approvedLeavesCount = tablePlugin.CountOfAllRecordsInTheTable();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(badgeNumberOfAllLeaves, "The number of leaves in the table is not the same as the number leaves in the All filter button badge" );
                Assert.IsTrue(allLeavesCount.Equals(pendingLeavesCount + canceledLeavesCount + rejectedLeavesCount + approvedLeavesCount), "Not all leaves display in the 'All leaves' table");
                Assert.IsTrue(badgeNumberOfPendingLeaves, "The number of leaves in the table is not the same as the number leaves in the Pending filter button badge");
                Assert.IsTrue(pendingLeavesCount.Equals(allLeavesCount - (canceledLeavesCount + rejectedLeavesCount + approvedLeavesCount)), "Not all leaves with status pending display in the 'Pending leaves' table");
                Assert.IsTrue(badgeNumberOfCanceledLeaves, "The number of leaves in the table is not the same as the number leaves in the Canceled filter button badge");
                Assert.IsTrue(canceledLeavesCount.Equals(allLeavesCount - (pendingLeavesCount + rejectedLeavesCount + approvedLeavesCount)), "Not all leaves with satatus canceled display in the 'Canceled leaves' table");
                Assert.IsTrue(badgeNumberOfRejectedLeaves, "The number of leaves in the table is not the same as the number leaves in the Rejected filter button badge");
                Assert.IsTrue(rejectedLeavesCount.Equals(allLeavesCount - (pendingLeavesCount + canceledLeavesCount + approvedLeavesCount)), "Not all leaves with satatus refected display in the 'Rejected leaves' table");
                Assert.IsTrue(badgeNumberOfApprovedLeaves, "The number of leaves in the table is not the same as the number leaves in the Approved filter button badge");
                Assert.IsTrue(approvedLeavesCount.Equals(allLeavesCount - (pendingLeavesCount + canceledLeavesCount + rejectedLeavesCount)), "Not all leaves with satatus approved display in the 'Approved leaves' table");
            });
        }

        [Test, Order(14), Category("SelfService page"), Category("My Leave Tab")]
        public void CheckIfCanceledLeaveAddToCanceledLeavesList()
        {
            LogInToSystemWithEmployeeRole();
            header.GoToSelfServicePage();
            CheckSuccessfullApplyOfFullDayLeavesRequest(15, 17);
            selfServicePage.myLeaveTab.ClickCanceledLeavesFilterButton();
            int canceledLeavesBefore = tablePlugin.CountOfAllRecordsInTheTable();
            selfServicePage.myLeaveTab.ClickPendingLeavesFilterButton();
            tablePlugin.ClickCancelButtonOfSpecificRecordsInTable(1);
            selfServicePage.myLeaveTab.ClickOkButtonOfPopupWindow();
            string succesMessage = selfServicePage.myLeaveTab.GetTextFromSuccessfullActionMessage();
            selfServicePage.myLeaveTab.ClickCanceledLeavesFilterButton();
            int canceledLeavesAfter = tablePlugin.CountOfAllRecordsInTheTable();
            Assert.Multiple(() =>
            {
                Assert.IsTrue(canceledLeavesAfter.Equals(canceledLeavesBefore + 1), "Canceled leave did not diaplay in the canceled leaves table");
                Assert.IsTrue(succesMessage.Equals("Leave was applied successfully."), "Success message is NOT correct. Actual result: "
                + succesMessage + "  Expected result: Leave was applied successfully.");
            });
        }

        [Test, Order(15), Category("SelfService page"), Category("My Leave Tab")]
        public void CheckIfRejectedLeaveAddToRejectedLeavesList()
        {
            LogInToSystemWithEmployeeRole();
            header.GoToSelfServicePage();
            CheckSuccessfullApplyOfFullDayLeavesRequest(15, 17);
            selfServicePage.myLeaveTab.ClickRejectedLeavesFilterButton();
            int rejectedLeavesBefore = tablePlugin.CountOfAllRecordsInTheTable();
            LogOutFromSystem();
            RejectAppliedLeaveFromYouEmployeeOfSpecificRecord(5);
            LogOutFromSystem();
            LogInToSystemWithEmployeeRole();
            header.GoToSelfServicePage();
            selfServicePage.ClickMyLeaveButton();
            selfServicePage.myLeaveTab.ClickRejectedLeavesFilterButton();
            int rejectedLeavesAfter = tablePlugin.CountOfAllRecordsInTheTable();

            Assert.IsTrue(rejectedLeavesAfter.Equals(rejectedLeavesBefore + 1), "Rejected leave did not diaplay in the rejected leaves table");

        }

        [Test, Order(16), Category("SelfService page"), Category("My Leave Tab")]
        public void CheckIfApprovedLeaveAddToApprovedLeavesList()
        {
            LogInToSystemWithEmployeeRole();
            header.GoToSelfServicePage();
            CheckSuccessfullApplyOfFullDayLeavesRequest(18, 19);
            selfServicePage.myLeaveTab.ClickApprovedLeavesFilterButton();
            int approvedLeavesBefore = tablePlugin.CountOfAllRecordsInTheTable();
            LogOutFromSystem();
            ApproveAppliedLeaveFromYouEmployeeOfSpecificRecord(5);
            LogOutFromSystem();
            LogInToSystemWithEmployeeRole();
            header.GoToSelfServicePage();
            selfServicePage.ClickMyLeaveButton();
            selfServicePage.myLeaveTab.ClickApprovedLeavesFilterButton();
            int approvedLeavesAfter = tablePlugin.CountOfAllRecordsInTheTable();

            Assert.IsTrue(approvedLeavesAfter.Equals(approvedLeavesBefore + 1), "Approved leave did not diaplay in the approved leaves table");

        }

        [Test, Order(17), Category("SelfService page"), Category("My Leave Tab")]
        public void CheckIfViewLeaveButtonWorksCorrectlyInMyLeaveTable()
        {
            LogInToSystemWithEmployeeRole();
            header.GoToSelfServicePage();
            selfServicePage.ClickMyLeaveButton();
            tablePlugin.ClickViewButtonOfSpecificRecordsInTable(1);
            selfServicePage.appliedLeavePage.IsAppliedLeavePageOpened();
            Assert.IsTrue(selfServicePage.appliedLeavePage.IsAppliedLeavePageOpened(), "The Applied Leave page is not opened");

        }

        [Test, Order(18), Category("SelfService page"), Category("My Leave Tab")]
        [TestCase("Leave Type")]
        [TestCase("Reason")]
        [TestCase("From Date")]
        [TestCase("To Date")]
        [TestCase("Days")]
        [TestCase("Applied On")]
        public void CheckIfSortLogicByColumnInMyLeaveTableWorksCorrectly(string columnName)
        {
            LogInToSystemWithEmployeeRole();
            header.GoToSelfServicePage();
            selfServicePage.ClickMyLeaveButton();
            selfServicePage.myLeaveTab.ClickAllFilterButton();
            var list = tablePlugin.GetListOfDataOfColumnInTable(columnName);
            list.Sort();
            tablePlugin.SortRecordsInTheTableByColumn(columnName);
            var sortedList = tablePlugin.GetListOfDataOfColumnInTable(columnName);
            Assert.IsTrue(list.Count.Equals(sortedList.Count), "Lists have different length");
            for (int k = 0; k < list.Count; k++)
            {
                Assert.IsTrue(list[k].Equals(sortedList[k]), "Sort logic of the table works not as C# sort logic");
            }
            LogUtil.WriteDebug("Checked if sort logic of records in the table by column " + columnName + " works correctly ");

        }

        [Test, Order(18), Category("SelfService page"), Category("My Leave Tab")]
        [TestCase("Leave Type", "vac")]
        [TestCase("Reason", "Reason")]
        [TestCase("Days", "3.0")]
        public void VerifyIfSearchLogicByTextColumnInMyLeaveTableWorksCorrectly(string columnName, string searchedText)
        {
            LogInToSystemWithEmployeeRole();
            header.GoToSelfServicePage();
            selfServicePage.ClickMyLeaveButton();
            selfServicePage.myLeaveTab.ClickAllFilterButton();
            tablePlugin.SearcheRecordsByTextFieldOfSpecificColumnData(columnName, searchedText);
            var listAfterSearch = tablePlugin.GetListOfDataOfColumnInTable(columnName);
            if (!listAfterSearch.Count.Equals(0))
            {
                for (int k = 0; k < listAfterSearch.Count; k++)
                {
                    Assert.IsTrue(listAfterSearch[k].Contains(searchedText), "Search logic in the table does not work correctly ");
                }
            }
            else
            {
                LogUtil.WriteDebug("Your search returned no results.");
            }
        }

        [Test, Order(19), Category("SelfService page"), Category("My Leave Tab")]
        [TestCase("From Date", "04", "03", "2020")]
        [TestCase("To Date", "07", "03", "2020")]
        [TestCase("Applied On", "23", "03", "2020")]
        public void VerifyIfSearchLogicByDateSelectorColumnInMyLeaveTableWorksCorrectly(string columnName, string day, string month, string year)
        {
            LogInToSystemWithEmployeeRole();
            header.GoToSelfServicePage();
            selfServicePage.ClickMyLeaveButton();
            selfServicePage.myLeaveTab.ClickAllFilterButton();
            tablePlugin.SearcheRecordsByDateSelectFieldOfSpecificColumnData(columnName, SelectBy.Value, day, month, year);
            var listAfterSearch = tablePlugin.GetListOfDataOfColumnInTable(columnName);
            if (!listAfterSearch.Count.Equals(0))
            {
                for (int k = 0; k < listAfterSearch.Count; k++)
                {
                Assert.IsTrue(listAfterSearch[k].Equals(year+"/"+month+"/"+day), "Search logic in the table does not work correctly ");
                }
            }
            else
            {
                LogUtil.WriteDebug("Your search returned no results.");
            }
        }

        #endregion

        #region Employee Leave Tab Tests

        [Test, Order(20), Category("SelfService page"), Category("Employee Leave Tab")]
        [TestCase(1)]
        public void RejectAppliedLeaveFromYouEmployeeOfSpecificRecord(int numberOfRecord)
        { 
            LogInToSystemWithRecruitmentsRole();
            header.GoToSelfServicePage();
            selfServicePage.ClickEmployeeLeavebutton();
            //tablePlugin.SearcheRecordsByTextFieldOfSpecificColumnData("Employee", "Valentyn Mikhyeyev");
            tablePlugin.ClickOptionButtonOfSpecificRecordsInTable(numberOfRecord);
            selfServicePage.frameContent.SwitchToFrameOfLeaveRequestWindow();
            selfServicePage.frameContent.SelectOptionInStatusDropDown(SelectBy.Text, "Reject");
            selfServicePage.frameContent.FillInCommentTextAreaOfLeaveRequestWindow("Rejected");
            selfServicePage.frameContent.ClickSaveButtonOfLeaveRequestWindow();
            pageBlockers.WaitTillPageUIBlockerDisappeared();

        }

        [Test, Order(21), Category("SelfService page"), Category("Employee Leave Tab")]
        [TestCase(1)]
        public void ApproveAppliedLeaveFromYouEmployeeOfSpecificRecord(int numberOfRecord)
        {
            LogInToSystemWithRecruitmentsRole();
            header.GoToSelfServicePage();
            selfServicePage.ClickEmployeeLeavebutton();
            //tablePlugin.SearcheRecordsByTextFieldOfSpecificColumnData("Employee", "Valentyn Mikhyeyev");
            tablePlugin.ClickOptionButtonOfSpecificRecordsInTable(numberOfRecord);
            selfServicePage.frameContent.SwitchToFrameOfLeaveRequestWindow();
            selfServicePage.frameContent.SelectOptionInStatusDropDown(SelectBy.Text, "Approve");
            selfServicePage.frameContent.FillInCommentTextAreaOfLeaveRequestWindow("Approved");
            selfServicePage.frameContent.ClickSaveButtonOfLeaveRequestWindow();
            pageBlockers.WaitTillPageUIBlockerDisappeared();

        }

        [Test, Order(22), Category("SelfService page"), Category("Employee Leave Tab")]
        [TestCase(6)]
        public void CancelAppliedLeaveFromYouEmployeeOfSpecificRecord(int numberOfRecord)
        {
            LogInToSystemWithRecruitmentsRole();
            header.GoToSelfServicePage();
            selfServicePage.ClickEmployeeLeavebutton();
            //tablePlugin.SearcheRecordsByTextFieldOfSpecificColumnData("Employee", "Valentyn Mikhyeyev");
            tablePlugin.ClickOptionButtonOfSpecificRecordsInTable(numberOfRecord);
            selfServicePage.frameContent.SwitchToFrameOfLeaveRequestWindow();
            selfServicePage.frameContent.SelectOptionInStatusDropDown(SelectBy.Text, "Cancel");
            selfServicePage.frameContent.FillInCommentTextAreaOfLeaveRequestWindow("Canceled");
            selfServicePage.frameContent.ClickSaveButtonOfLeaveRequestWindow();
            pageBlockers.WaitTillPageUIBlockerDisappeared();

        }

        [Test, Order(23), Category("SelfService page"), Category("Employee Leave Tab")]
        [TestCase("Employee")]
        [TestCase("Leave Type")]
        [TestCase("From")]
        [TestCase("To")]
        [TestCase("Days")]
        [TestCase("Leave Status")]
        public void CheckIfSortLogicByColumnInEmployeeLeaveTableWorksCorrectly(string columnName)
        {
            LogInToSystemWithRecruitmentsRole();
            header.GoToSelfServicePage();
            selfServicePage.ClickEmployeeLeavebutton();
            var list = tablePlugin.GetListOfDataOfColumnInTable(columnName);
            list.Sort();
            tablePlugin.SortRecordsInTheTableByColumn(columnName);
            var sortedList = tablePlugin.GetListOfDataOfColumnInTable(columnName);
            Assert.IsTrue(list.Count.Equals(sortedList.Count), "Lists have different length");
            for (int k = 0; k < list.Count; k++)
            {
                Assert.IsTrue(list[k].Equals(sortedList[k]), "Sort logic of the table works not as C# sort logic");
            }
            LogUtil.WriteDebug("Checked if sort logic of records in the table by column " + columnName + " works correctly ");

        }

        [Test, Order(24), Category("SelfService page"), Category("Employee Leave Tab")]
        [TestCase("Employee", "Tetiana Danyliv")]
        [TestCase("Leave Type", "VAC")]
        [TestCase("Days", "0.5")]
        [TestCase("Leave Status", "Pending for approval")]
        public void VerifyIfSearchLogicByTextColumnInEmployeeLeaveTableWorksCorrectly(string columnName, string searchedText)
        {
            LogInToSystemWithRecruitmentsRole();
            header.GoToSelfServicePage();
            selfServicePage.ClickEmployeeLeavebutton();
            tablePlugin.SearcheRecordsByTextFieldOfSpecificColumnData(columnName, searchedText);
            var listAfterSearch = tablePlugin.GetListOfDataOfColumnInTable(columnName);
            if (!listAfterSearch.Count.Equals(0))
            {
                for (int k = 0; k < listAfterSearch.Count; k++)
                {
                    Assert.IsTrue(listAfterSearch[k].Contains(searchedText), "Search logic in the table does not work correctly ");
                }
            }
            else
            {
                LogUtil.WriteDebug("Your search returned no results.");
            }
        }

        [Test, Order(25), Category("SelfService page"), Category("Employee Leave Tab")]
        [TestCase("From", "04", "03", "2020")]
        [TestCase("To", "07", "03", "2020")]
        public void VerifyIfSearchLogicByDateSelectorColumnInEmployeeLeaveTableWorksCorrectly(string columnName, string day, string month, string year)
        {
            LogInToSystemWithRecruitmentsRole();
            header.GoToSelfServicePage();
            selfServicePage.ClickEmployeeLeavebutton();
            tablePlugin.SearcheRecordsByDateSelectFieldOfSpecificColumnData(columnName, SelectBy.Value, day, month, year);
            var listAfterSearch = tablePlugin.GetListOfDataOfColumnInTable(columnName);
            if (!listAfterSearch.Count.Equals(0))
            {
                for (int k = 0; k < listAfterSearch.Count; k++)
                {
                    Assert.IsTrue(listAfterSearch[k].Equals(year + "/" + month + "/" + day), "Search logic in the table does not work correctly ");
                }
            }
            else
            {
                LogUtil.WriteDebug("Your search returned no results.");
            }
        }

        [Test, Order(26), Category("SelfService page"), Category("Employee Leave Tab")]
        public void CheckIfViewLeaveButtonWorksCorrectlyInEmployeeLeaveTable()
        {
            LogInToSystemWithRecruitmentsRole();
            header.GoToSelfServicePage();
            selfServicePage.ClickEmployeeLeavebutton();
            var recordDatalist = tablePlugin.GetListOfDataOfSpecificRecordInTable(1);
            tablePlugin.ClickViewButtonOfSpecificRecordsInTable(1);
            Assert.IsTrue(selfServicePage.appliedLeavePage.IsAppliedLeavePageOpened(), "The Applied Leave page is not opened");
            var fieldsDataList = selfServicePage.appliedLeavePage.GetFieldsDataListOfAppliedLeave();
            Assert.IsTrue(recordDatalist[0].Equals(fieldsDataList[0]), "Opened the wrong Applied leave page");
        }

        #endregion

        #region My Details Tab Test

        [Test]
        public void test()
        {
            LogInToSystemWithEmployeeRole();
            header.GoToSelfServicePage();
            selfServicePage.ClickMyDetailsButton();
            var list = selfServicePage.myDetailsTab.officialDetailsBlock.GetListOfOfficialDetailsData();
        }

        #endregion
    }
}
