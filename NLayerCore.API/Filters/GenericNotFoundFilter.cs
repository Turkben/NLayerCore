using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerCore.API.DTOs;
using NLayerCore.Core.Services;

namespace NLayerCore.API.Filters
{
    public class GenericNotFoundFilter<TEntity> : IAsyncActionFilter where TEntity : class
    {
        private readonly IGenericService<TEntity> _service;

        public GenericNotFoundFilter(IGenericService<TEntity> service)
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

                errorDto.Status = 400;

                errorDto.Errors.Add($"id = {id} not found at database");

                context.Result = new NotFoundObjectResult(errorDto);

            }
        }
    }
}
