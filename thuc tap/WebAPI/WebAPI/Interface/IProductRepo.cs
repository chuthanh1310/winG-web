using WebAPI.Dto.Product;
using WebAPI.Model;

namespace WebAPI.Interface
{
    public interface IProductRepo
    {
        
        Task <Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product product);
        Task<Product?>UpdateAsync(int id,CreateProductDto createProductDto);
        Task<Product?>DeleteAsync(int id);
        Task<bool> HaveProduct(int id);
    }
}
