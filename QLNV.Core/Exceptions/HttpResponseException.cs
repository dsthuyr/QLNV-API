using System;
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
    public class HttpResponseException : Exception
    {
        public HttpResponseException(int statusCode, object? value = null) =>
            (StatusCode, Value) = (statusCode, value);

        public int StatusCode { get; }

        public object? Value { get; }
    }
}
