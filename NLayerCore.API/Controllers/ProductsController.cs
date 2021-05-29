using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerCore.API.DTOs;
using NLayerCore.API.Filters;
using NLayerCore.Core.Models;
using NLayerCore.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var produtcs = await _productService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(produtcs));
        }

        //[ServiceFilter(typeof(ProductNotFoundFilter))]
        [ServiceFilter(typeof(GenericNotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            return Ok(_mapper.Map<ProductDto>(product));
        }

        [ServiceFilter(typeof(GenericNotFoundFilter<Product>))]
        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetWithCategoryById(int id)
        {
            var product = await _productService.GetWithCategoryByIdAsync(id);

            return Ok(_mapper.Map<ProductWithCategoryDto>(product));

        }

        //[ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto entity)
        {

            var product = await _productService.AddAsync(_mapper.Map<Product>(entity));

            return Created(string.Empty, _mapper.Map<ProductDto>(product));
        }

        [HttpPut]
        public IActionResult Update(ProductDto entity)
        {
            var product = _productService.Update(_mapper.Map<Product>(entity));

            return NoContent();
        }

        [ServiceFilter(typeof(GenericNotFoundFilter<Product>))]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetByIdAsync(id).Result;
            _productService.Remove(product);

            return NoContent();
        }


    }
}
