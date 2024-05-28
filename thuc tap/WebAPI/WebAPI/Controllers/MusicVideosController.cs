using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dto.MusicVideo;
using WebAPI.Interface;
using WebAPI.Mapper;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicVideosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMusicRepo _MVRepo;
        private readonly IProductRepo _productRepo;

        public MusicVideosController(ApplicationDbContext context,IMusicRepo MVRepo,IProductRepo productRepo)
        {
            _context = context;
            _MVRepo=MVRepo;
            _productRepo=productRepo;
        }

        // GET: api/MusicVideos
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<MusicVideo>>> GetMusicVideos()
        {
            return await _context.MusicVideos.ToListAsync();
        }

        // GET: api/MusicVideos/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<MusicVideo>> GetByID(int id)
        {
            var musicVideo = await _MVRepo.GetIdByAsync(id);

            if (musicVideo == null)
            {
                return NotFound();
            }

            return Ok(musicVideo.ToMVDto());
        }

        // PUT: api/MusicVideos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutMusicVideo([FromRoute]int id, [FromBody]CreateMusicVideoDto musicVideoDto)
        {
            if (!ModelState.IsValid){return BadRequest(ModelState);}
            var updatedMV=await _MVRepo.UpdateAsync(id,musicVideoDto.ToAdd(id));
            if (updatedMV==null)
            {
                return NotFound();
            }
            return Ok(updatedMV.ToMVDto());
        }

        // POST: api/MusicVideos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("{ProductID}")]
        [Authorize]
        public async Task<ActionResult<MusicVideo>> PostMusicVideo([FromRoute] int ProductID,[FromBody] CreateMusicVideoDto musicVideoDto)
        {
            if (!ModelState.IsValid){return BadRequest(ModelState);}
            if (!await _productRepo.HaveProduct(ProductID))
            {
                return BadRequest("invalid ProductID");
            }
            var mvModel=musicVideoDto.ToAdd(ProductID);
            await _MVRepo.CreateAsync(mvModel);
            return CreatedAtAction(nameof(GetByID),new{id=mvModel.Id},mvModel);
        }

        // DELETE: api/MusicVideos/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteMusicVideo(int id)
        {
            if (!ModelState.IsValid){return BadRequest(ModelState);}
            var mvModel=await _MVRepo.DeleteAsync(id);
            if(mvModel==null) return NotFound("Musiv Video doesn't exist");
            return Ok(mvModel);
        }

        
    }
}
