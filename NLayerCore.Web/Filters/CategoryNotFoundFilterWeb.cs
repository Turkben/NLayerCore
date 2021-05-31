using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerCore.Web.DTOs;
using NLayerCore.Web.ApiServices;

namespace NLayerCore.Web.Filters
{
    public class CategoryNotFoundFilterWeb
    {
        private readonly CategoryApiService _service;

        public CategoryNotFoundFilterWeb(CategoryApiService service)
        {
            _service = service;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var id = (int)context.ActionArguments.Values.FirstOrDefault();

            var entry = await _service.GetByIdAsync(id);

            if (entry != null)

            {
                await next();
            }

            else
            {
                ErrorDto errorDto = new ErrorDto();
                
                errorDto.Errors.Add($"id = {id} not found at database");

                context.Result = new RedirectToActionResult("Error", "Home", errorDto);

            }
        }
    }
}
