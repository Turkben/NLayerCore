using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NLayerCore.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerCore.API.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ErrorDto error = new ErrorDto();
                error.Status = 400;
                IEnumerable<ModelError> modelErrors = context.ModelState.Values.SelectMany(x => x.Errors);

                foreach (var item in modelErrors)
                {
                    error.Errors.Add(item.ErrorMessage);
                }

                context.Result = new BadRequestObjectResult(error);
            }          
        }
    }
}
