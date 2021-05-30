using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerCore.Web.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="{0} is required")]
        public string Name { get; set; }
        [Range(1,5000,ErrorMessage ="{0} should be between 1 and 5000")]
        public int Stock { get; set; }
        [Range(1,1000,ErrorMessage = "{0} should be between 1 and 1000 ")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
