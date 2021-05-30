using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerCore.Web.DTOs;
using NLayerCore.Core.Services;

namespace NLayerCore.Web.Filters
{
    public class GenericNotFoundFilterWeb<TEntity> : IAsyncActionFilter where TEntity : class
    {
        private readonly IGenericService<TEntity> _service;

        public GenericNotFoundFilterWeb(IGenericService<TEntity> service)
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
