using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Linq;

namespace ATS.UI.Attributes
{
    public class HandleExceptionAttribute : ExceptionFilterAttribute
    {
        public HandleExceptionAttribute()
        {

        }

        /// <summary>
        /// Base exception handling attribute will get invoked whenever exception generated 
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            string correlationId = null;
            int statusCode = 0;
            if (context != null && context.HttpContext != null && context.HttpContext.Response != null)
            {
                if (context.HttpContext.Response.Headers != null && context.HttpContext.Response.Headers.Keys != null)
                {
                    string key = context.HttpContext.Response.Headers.Keys.FirstOrDefault(n => n.ToLower().Equals("x-correlation-id"));
                    if (key != null)
                        correlationId = context.HttpContext.Response.Headers[key];
                }
                statusCode = context.HttpContext.Response.StatusCode;
            }

            if (correlationId == null)
                correlationId = Guid.NewGuid().ToString();

            var result = new ViewResult { ViewName = "Error" };
            var modelMetadata = new EmptyModelMetadataProvider();
            if (context != null)
            {
                result.ViewData = new ViewDataDictionary(
                    modelMetadata,
                    context.ModelState);

                result.ViewData.Add("HandleException",
                    context.Exception);

                result.ViewData.Add("CorrelationId",
                    correlationId);

                if (statusCode == 409) // i.e. DbUpdateConcurrencyException
                {
                    result.ViewData.Add("ErrorMessage",
                        "The record you attempted to update was modified by another user. The update operation was canceled.");
                }

                context.Result = result;
                context.ExceptionHandled = true;
                base.OnException(context);
            }
        }
    }
}