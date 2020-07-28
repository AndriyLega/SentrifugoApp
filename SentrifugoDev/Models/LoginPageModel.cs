using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentrifugoDev.Models
{
    public class LoginPageModel
    {
            public string ValidPassword { get; set; }
            public string ValidUserName { get; set; }
            public string InvalidUserName { get; set; }
            public string InvalidPassword { get; set; }
            public string ValidEmail { get; set; }
            public string InvalidEmail { get; set; }
            public string NotExistEmail { get; set; }
            public string RecruitmentsUserName { get; set; }
            public string SuperAdminUserName { get; set; }
            public string HRUserName { get; set; }
            public string EmpolyeeUserName { get; set; }
            public string UserRolesPassword { get; set; }
            public string EmptyEmailWarningMessage { get; set; }
            public string EmptyPasswordWarningMessage { get; set; }
            public string IncorrectCredsWarningMessage { get; set; }
            public string EmptyEmailWarningMessageInForgotPasswordForm { get; set; }
            public string NotExistEmailWarningMessageInForgotPasswordForm { get; set; }
            public string InvalidEmailWarningMessageInForgotPasswordFform { get; set; }
            public string SuccessSendPasswordMessage { get; set; }
            public string SentrifugoDev { get; set; }
            public string GetingStartedPdfFile { get; set; }
    }
}
