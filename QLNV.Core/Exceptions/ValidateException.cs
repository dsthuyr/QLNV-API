using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV.Core.Exceptions
{
    /// <summary>
    /// Xử lí Exception
    /// CreatedBy: dsthuyr(16/06/2022)
    /// </summary>
    public class ValidateException : Exception
    {
        string _message;
        IDictionary _errorMsgs;
        public ValidateException(string message, List<string> errMsgs = null)
        {
            _message = message;
            _errorMsgs = new Dictionary<string, List<string>>();
            _errorMsgs.Add("detailErr", errMsgs);
        }
        public override string Message => this._message;
        public override IDictionary Data => this._errorMsgs;
    }
}
