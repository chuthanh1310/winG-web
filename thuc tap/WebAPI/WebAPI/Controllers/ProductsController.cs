using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dto.Product;
using WebAPI.Interface;
using WebAPI.Mapper;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductRepo _productRepo;

        public ProductsController(ApplicationDbContext context,IProductRepo productRepo)
        {
            _context = context;
            _productRepo=productRepo;
        }

        // GET: api/Products
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products
                .Include(c => c.Comics)
                .Include(c=>c.albums)
                .Include(c=>c.musicVideos)
                .Include(c=>c._3D)
                .Include(c=>c.singles)
                .ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Product>> GetByID(int id)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var product=await _productRepo.GetByIdAsync(id);
            if (product==null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> PutProduct([FromRoute]int id, [FromBody]CreateProductDto productDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var product=await _productRepo.UpdateAsync(id,productDto);
            if(product==null){
                return NotFound();
            }
            return Ok(product.ToProductDto());
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Product>> PostProduct([FromBody]CreateProductDto productDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var product=productDto.ToAdd();
            await _productRepo.CreateAsync(product);
            return CreatedAtAction(nameof(GetByID), new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct([FromRoute]int id)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var product=await _productRepo.DeleteAsync(id);
            if (product==null)
            {
                return NotFound();
            }
            return NoContent();
        }

        
    }
}
