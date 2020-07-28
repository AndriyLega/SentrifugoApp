using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentrifugoDev.Models
{
    public class LeaveRequestTabModel
    {
            public string PreviousMonthPopupWarningMessage { get; set; }
            public string EmptyLeaveTypeFieldWarningMessage { get; set; }
            public string EmptyReasonTextAreaWarningMessage { get; set; }
            public string EmptyDateFieldWarningMessage { get; set; }
            public string IncorrectFromDateWarningMessage { get; set; }
            public string IncorrectToDateWarningMessage { get; set; }
            public string AppliedLeaveAboutDateWarningMessage { get; set; }
            public string WeekendHolodaysPopupWarningMessage { get; set; }
            public string FutureYearWarningMessage { get; set; }
    }
}
