using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dto.Product
{
    public class CreateProductDto
    {
        public string Name{get;set;}=string.Empty;
        public string Type{get;set;}=string.Empty;
    }
}