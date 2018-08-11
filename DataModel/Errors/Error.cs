using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Errors
{
    [Serializable]
    public class Error
    {
        public ErrorCodes? Code { get; set; }
        public String Message { get; set; }
        public string stacTrac { get; set; }
        public Error()
        {

        }
        public Error(ErrorCodes code)
        {
            Code = code;
        }
        public Error(ErrorCodes code,string message)
        {
            Code = code;
            Message = message;
        }

    }
}
    public enum ErrorCodes
    {
    InvalidInput=0,
    UserIdNotFount=1,
    USERNameInvalidLength=2,
    PasswordNotCorrect=3,
    InvalidLocation=4

    }

