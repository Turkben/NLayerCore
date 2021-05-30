using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerCore.Web.DTOs
{
    public class ErrorDto
    {
        public ErrorDto()
        {
            //Errors = new List<string>();
        }
        public List<string> Errors { get; set; } = new List<string>();
        public int Status { get; set; }
    }
}
