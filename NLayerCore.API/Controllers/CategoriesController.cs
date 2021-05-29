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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        //Task<ActionResult<IEnumerable<AppUser>>>
        {
            var categories = await _categoryService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        [ServiceFilter(typeof(GenericNotFoundFilter<Category>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [ServiceFilter(typeof(GenericNotFoundFilter<Category>))]
        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetWithProductsById(int id)
        {
            var category = await _categoryService.GetWithProductsByIdAsync(id);

            return Ok(_mapper.Map<CategoryWithProductsDto>(category));

        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto entity)
        {
           var category = await _categoryService.AddAsync(_mapper.Map<Category>(entity));

            return Created(string.Empty,_mapper.Map<CategoryDto>(category));
        }

        [HttpPut]
        public IActionResult Update(CategoryDto entity)
        {
            var category = _categoryService.Update(_mapper.Map<Category>(entity));

            return NoContent();
        }

        [ServiceFilter(typeof(GenericNotFoundFilter<Category>))]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetByIdAsync(id).Result;
            _categoryService.Remove(category);

            return NoContent();
        }

        
    }
}
