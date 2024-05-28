using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dto.Singles;
using WebAPI.Interface;
using WebAPI.Mapper;
using WebAPI.Model;
using Single = WebAPI.Model.Single;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinglesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IAlbumRepo _albumRepo;
        private readonly IProductRepo _productRepo;
        private readonly IArtistRepo _artistRepo;
        private readonly ISingleRepo _singleRepo;
        public SinglesController(ApplicationDbContext context,IAlbumRepo albumRepo,IProductRepo productRepo,IArtistRepo artistRepo,ISingleRepo singleRepo)
        {
            _context = context;
            _albumRepo=albumRepo;
            _productRepo=productRepo;
            _artistRepo=artistRepo;
            _singleRepo=singleRepo;
        }

        
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Single>>> GetSingles()
        {
            return await _context.Singles.ToListAsync();
        }

        // GET: api/Singles/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Single>> GetByID(int id)
        {
            

            var single= await _singleRepo.GetByIDAsync(id);
            if (single == null)
            {
                return NotFound();
            }

            return Ok(single);
        }

        // PUT: api/Singles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> PutSingle([FromRoute] int id, [FromBody]CreateSingleDto singleDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var single=await _singleRepo.UpdateAsync(id,singleDto.ToUpdate(id));
            if (single==null)
            {
                return NotFound("comment not found");
            }
            return Ok(single.ToSingleDto());
        }

        // POST: api/Singles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<ActionResult<Single>> PostSingle([FromQuery] int? ArtistID , [FromQuery] int? ProductID,[FromQuery]int? AlbumID,[FromBody] CreateSingleDto singleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!ProductID.HasValue && !ArtistID.HasValue&&!AlbumID.HasValue)
            {
                return BadRequest();
            }
            Single singleModel=null;
            if(ProductID.HasValue){
                if (!await _productRepo.HaveProduct((int)ProductID))
                {
                    return BadRequest("Invalid Product ID");
                }
                singleModel=singleDto.ToAddFromProduct((int)ProductID);
            }
            else if(ArtistID.HasValue){
                if (!await _artistRepo.HaveArtist((int)ArtistID))
                {
                    return BadRequest("Invalid Artist ID");
                }
                singleModel=singleDto.ToAddFromArtist((int)ArtistID);
            }
            else if(AlbumID.HasValue){
                if (!await _albumRepo.HaveAlbum((int) AlbumID))
                {
                    return BadRequest("Invalid Album ID");
                }
                singleModel=singleDto.ToAddFromAlbum((int)AlbumID);
            }
            await _singleRepo.CreateAsync(singleModel);
            return CreatedAtAction(nameof(GetByID),new{id=singleModel.Id},singleModel);
        }

        // DELETE: api/Singles/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteSingle(int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var singleModel=_singleRepo.DeleteAsync(id);
            if (singleModel == null) return NotFound();
            return Ok(singleModel);
        }

        
    }
}
