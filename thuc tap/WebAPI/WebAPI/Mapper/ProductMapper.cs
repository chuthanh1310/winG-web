using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dto.Product;
using WebAPI.Model;

namespace WebAPI.Mapper
{
    public static class ProductMapper
    {
        public static ProductDto ToProductDto(this Product product){
            return new ProductDto{
                Id=product.Id,
                Name=product.Name,
                Type=product.Type
            };
        }
        public static Product ToAdd(this CreateProductDto productDto){
            return new Product{
                Name=productDto.Name,
                Type=productDto.Type
            };
        }
    }
}