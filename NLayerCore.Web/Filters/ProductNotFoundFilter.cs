using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerCore.Web.DTOs;
using NLayerCore.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerCore.Web.Filters
{
    
    public class ProductNotFoundFilter : ActionFilterAttribute
    {
        private readonly IProductService _productService;
        public ProductNotFoundFilter(IProductService productService)
        {
            _productService = productService; 
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var product = await _productService.GetByIdAsync(id);

            if (product != null) await next();
            else 
            {
                ErrorDto error = new ErrorDto();
                error.Status = 404;
                error.Errors.Add($"Id = {id} is not founded in database");
                context.Result = new NotFoundObjectResult(error);
            } 
  
        }

    }
}
