using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dto.Product;
using WebAPI.Interface;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext _context;
        public ProductRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> DeleteAsync(int id)
        {
            var product=await _context.Products.FirstOrDefaultAsync(x=>x.Id==id);
            if (product==null)
            {
                return null;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
            .Include(p=>p.albums)
            .Include(p=>p.Comics)
            .Include(p=>p.musicVideos)
            .Include(p=>p._3D)
            .Include(p=>p.singles)
            .FirstOrDefaultAsync(i=>i.Id==id);
        }

        public Task<bool> HaveProduct(int id)
        {
            return _context.Products.AnyAsync(p=> p.Id == id);
        }

        public async Task<Product?> UpdateAsync(int id, CreateProductDto createProductDto)
        {
            var existingProduct=await _context.Products.FirstOrDefaultAsync(x=>x.Id==id);
            if (existingProduct==null)
            {
                return null;
            }
            existingProduct.Name=createProductDto.Name;
            existingProduct.Type=createProductDto.Type;
            await _context.SaveChangesAsync();
            return existingProduct;
        }
    }
}
