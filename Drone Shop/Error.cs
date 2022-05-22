using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone_Shop
{
    public enum ErrorCode
    {
        IndexOutsideLimit,
        IncorrectPrice,
        FileDoesNotExist,
        UnknownError
    };

    public class Error : Exception
    {
        private ErrorCode code;
        public ErrorCode Code { get => this.code; }

        public Error(ErrorCode code)
        {
            this.code = code;
        }

        public override string ToString()
        {
            switch (code)
            {
                case ErrorCode.IndexOutsideLimit:
                    return "Error occured: index out of limit";
                case ErrorCode.IncorrectPrice:
                    return "Error occured: incorrect price was entered";
                case ErrorCode.FileDoesNotExist:
                    return "Error occured: file does not exist";
                case ErrorCode.UnknownError:
                    return "Error occured: unknown error";
                default:
                    return "";
            }
        }
    };
}
