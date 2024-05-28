using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dto.Comic;
using WebAPI.Interface;
using WebAPI.Mapper;
using WebAPI.Model;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicsController : ControllerBase
    {
        private readonly IComicRepo _comicRepo;
        private readonly ApplicationDbContext _context;
        private readonly IProductRepo _productRepo;

        public ComicsController(ApplicationDbContext context, IProductRepo productRepo, IComicRepo comicRepo)
        {
            _context = context;
            _productRepo = productRepo;
            _comicRepo = comicRepo;
        }

        // GET: api/Comics
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Comic>>> GetComics()
        {
            return await _context.Comics.Include(p=>p.Chapters).ToListAsync();
        }

        // GET: api/Comics/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Comic>> GetById(int id)
        {
            var comic = await _comicRepo.GetByIdAsync(id);

            if (comic == null)
            {
                return NotFound();
            }

            return Ok(comic);
        }

        // PUT: api/Comics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> PutComic([FromRoute] int id, [FromBody] CreateComicDto comicDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedComic = await _comicRepo.UpdateAsync(id, comicDto.ToAdd(id));

            if (updatedComic == null)
            {
                return NotFound();
            }

            return Ok(updatedComic.ToComicDto());
        }


        // POST: api/Comics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{ProductID}")]
        [Authorize]
        public async Task<ActionResult<Comic>> PostComic([FromRoute] int ProductID, [FromBody] CreateComicDto comicDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _productRepo.HaveProduct(ProductID))
            {
                return BadRequest("Invalid Comic ID");
            }

            var comicModel = comicDto.ToAdd(ProductID);
            await _comicRepo.CreateAsync(comicModel);

            return CreatedAtAction(nameof(GetById), new { id = comicModel.Id }, comicModel);
        }


        // DELETE: api/Comics/5
        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteComic([FromRoute]int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var commentModel = await _comicRepo.DeleteAsync(id);
            if (commentModel == null)
            {
                return NotFound("comic not exists");
            }
            return Ok(commentModel);
        }

        private bool ComicExists(int id)
        {
            return _context.Comics.Any(e => e.Id == id);
        }

        public interface IActionResult<T>
        {
        }
    }
}
