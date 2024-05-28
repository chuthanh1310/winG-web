using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dto.Artist;
using WebAPI.Interface;
using WebAPI.Mapper;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IArtistRepo _artistRepo;

        public ArtistsController(ApplicationDbContext context,IArtistRepo artistRepo)
        {
            _context = context;
            _artistRepo=artistRepo;
        }

        // GET: api/Artists
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {
            return await _context.Artists.Include(c=>c.Albums).Include(c=>c.Singles).ToListAsync();
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var product=await _artistRepo.GetByIdAsync(id);
            if (product==null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // PUT: api/Artists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutArtist([FromRoute]int id, [FromBody]CreateArtistDto artistDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var product=await _artistRepo.UpdateAsync(id,artistDto);
            if(product==null){
                return NotFound();
            }
            return Ok(product.ToArtistDto());
        }

        // POST: api/Artists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Artist>> PostArtist([FromBody] CreateArtistDto artistDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var product=artistDto.ToAdd();
            await _artistRepo.CreateAsync(product);
            return CreatedAtAction(nameof(GetArtist), new { id = product.Id }, product);
        }

        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteArtist([FromRoute]int id)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var product=await _artistRepo.DeleteAsync(id);
            if (product==null)
            {
                return NotFound();
            }
            return NoContent();
        }

        
    }
}
