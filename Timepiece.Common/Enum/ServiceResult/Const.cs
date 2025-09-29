namespace Timepiece.Common.Enum.ServiceResult
{
    public class Const
    {
        #region Error Codes
        public const int ERROR_VALIDATION_CODE = 400; // HTTP Bad Request
        public const int ERROR_EXEPTION_CODE = 500; // HTTP Internal Server Error
        public const int ERROR_NOT_FOUND_CODE = 404; // HTTP Not Found
        public const int ERROR_REQUIRED_CODE = 401; // HTTP Unauthorized
        #endregion

        #region Error Messages
        public const string ERROR_VALIDATION_MSG = "Validation Data";
        public const string ERROR_EXEPTION_MSG = "Internal Server Error";
        public const string ERROR_NOT_FOUND_MSG = "Data Not Found";
        public const string ERROR_REQUIRED_MSG = "Data is required";
        #endregion

        #region Fail Account Codes 
        public const int FAIL_READ_CODE = 400;   // CHTTP Bad Request
        public const int FAIL_CREATE_CODE = 400; // HTTP Bad Request
        public const int FAIL_UPDATE_CODE = 400; // HTTP Bad Request
        public const int FAIL_DELETE_CODE = 400; // HTTP Bad Request
        #endregion

        #region Fail Account Messages
        public const string FAIL_READ_MSG = "Get No Account";
        public const string FAIL_CREATE_MSG = "Create Account ata Fail";
        public const string FAIL_UPDATE_MSG = "Update Account Fail";
        public const string FAIL_DELETE_MSG = "Delete Account Fail";
        #endregion

        #region Success Account Codes
        public const int SUCCESS_READ_CODE = 200;   // HTTP OK
        public const int SUCCESS_CREATE_CODE = 200;
        public const int SUCCESS_UPDATE_CODE = 200;
        public const int SUCCESS_DELETE_CODE = 200;
        #endregion

        #region Success Account Messages
        public const string SUCCESS_READ_MSG = "Get Account Success";
        public const string SUCCESS_CREATE_MSG = "Create Account Success";
        public const string SUCCESS_UPDATE_MSG = "Update Account Success";
        public const string SUCCESS_DELETE_MSG = "Delete Account Success";
        #endregion

    }
}
