using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace QLNV.Core.Exceptions
{
    /// <summary>
    /// Xử lí Exception
    /// CreatedBy: dsthuyr(16/06/2022)
    /// </summary>
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpResponseException httpResponseException)
            {
                context.Result = new ObjectResult(httpResponseException.Value)
                {
                    StatusCode = httpResponseException.StatusCode
                };

                context.ExceptionHandled = true;
            }
            else if (context.Exception is ValidateException)
            {
                var res = new
                {
                    devMsg = context.Exception.Message,
                    uaerMsg = Resources.ResourceVN.VN_ValidateError_HaveError,
                    data = context.Exception.Data
                };
                context.Result = new ObjectResult(res)
                {
                    StatusCode = 400
                };

                context.ExceptionHandled = true;
            }
        }
    }
}
