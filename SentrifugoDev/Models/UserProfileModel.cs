using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentrifugoDev.Models
{
    public class UserProfileModel
    {
            public string CorrectCurrentPassword { get; set; }
            public string IncorrectCurrentPassword { get; set; }
            public string ValidNewPassword { get; set; }
            public string InvalidNewPassword { get; set; }
            public string ValidConfirmPassword { get; set; }
            public string InvalidConfirmPassword { get; set; }
            public string IncorrectConfirmPassword { get; set; }
            public string ShortPassword { get; set; }
            public string EmptyCurrentPasswordWarningMessage { get; set; }
            public string EmptyNewPasswordWarningMessage { get; set; }
            public string EmptyConfirmPasswordWarningMessage { get; set; }
            public string IncorrectCurrentPasswordWarningMessage { get; set; }
            public string InvaildNewPasswordWarningMessage { get; set; }
            public string InvaildConfirmPasswordWarningMessage { get; set; }
            public string NotMatchConfirmPasswordWarningMessage { get; set; }
            public string ShortNewPasswordWarningMessage { get; set; }
            public string ShortConfirmPasswordWarningMessage { get; set; }
            public string SameCurrentAndNewPasswordWarningMessage { get; set; }
            public string SuccessMessageOfChangedPassword { get; set; }

    }
}
