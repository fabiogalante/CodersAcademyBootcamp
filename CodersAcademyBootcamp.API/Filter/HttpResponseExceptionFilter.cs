using CodersAcademyBootcamp.Crosscutting.Exception;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.API.Filter
{
    public class HttpResponseExceptionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is BusinessException bex)
            {
                var responseException = new HttpResponseException()
                {
                    StatusCode = System.Net.HttpStatusCode.UnprocessableEntity
                };

                foreach (var error in bex.Errors)
                    responseException.Errors.Add(new HttpResponseMessage() { ErrorName = error.ErrorName, Message = error.ErrorMessage });

                context.Result = new ObjectResult(responseException)
                {
                    StatusCode = (int)System.Net.HttpStatusCode.UnprocessableEntity
                };
                context.ExceptionHandled = true;
            }
            else if (context.Exception is FluentValidation.ValidationException fex)
            {
                var responseException = new HttpResponseException()
                {
                    StatusCode = System.Net.HttpStatusCode.UnprocessableEntity
                };

                foreach (var error in fex.Errors)
                    responseException.Errors.Add(new HttpResponseMessage() { ErrorName = error.PropertyName, Message = error.ErrorMessage });

                context.Result = new ObjectResult(responseException)
                {
                    StatusCode = (int)System.Net.HttpStatusCode.UnprocessableEntity
                };
                context.ExceptionHandled = true;
            }

            else if (context.Result is BadRequestObjectResult && context.ModelState?.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                var responseException = new HttpResponseException()
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };

                foreach (var ms in context.ModelState)
                    foreach (var error in ms.Value.Errors)
                        responseException.Errors.Add(new HttpResponseMessage() { ErrorName = ms.Key, Message = error.ErrorMessage });

                context.Result = new ObjectResult(responseException)
                {
                    StatusCode = (int)System.Net.HttpStatusCode.BadRequest
                };

            }

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
