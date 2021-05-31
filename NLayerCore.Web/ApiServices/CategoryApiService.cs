using Newtonsoft.Json;
using NLayerCore.Web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCore.Web.ApiServices
{
    public class CategoryApiService
    {
        private readonly HttpClient _categoryHttpClient;

        public CategoryApiService(HttpClient categoryHttpClient)
        {
            _categoryHttpClient = categoryHttpClient;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            IEnumerable<CategoryDto> categoryDto;
            var response = await _categoryHttpClient.GetAsync("categories");
            if (response.IsSuccessStatusCode)
            {
                categoryDto = JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                categoryDto = null;
            }
            return categoryDto;       
        }

        public async Task<CategoryDto> AddAsync(CategoryDto categoryDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(categoryDto),Encoding.UTF8,"application/json");

            var response = await _categoryHttpClient.PostAsync("categories", stringContent);
            if (response.IsSuccessStatusCode)
            {
                categoryDto = JsonConvert.DeserializeObject<CategoryDto>(await response.Content.ReadAsStringAsync());

                return categoryDto;
            }
            else
            {
                //log
                return null;
            }
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var response = await _categoryHttpClient.GetAsync($"categories/{id}");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<CategoryDto>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Update(CategoryDto categoryDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(categoryDto), Encoding.UTF8, "application/json");

            var response = await _categoryHttpClient.PutAsync("categories", stringContent);

            return response.IsSuccessStatusCode;     
        }

        public async Task<bool> Remove(int id)
        {
            var response = await _categoryHttpClient.DeleteAsync($"categories/{id}");
            return (response.IsSuccessStatusCode);

        }
    }
}
