using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dto.Album;
using WebAPI.Dto.Comic;
using WebAPI.Interface;
using WebAPI.Mapper;
using WebAPI.Model;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IAlbumRepo _albumRepo;
        private readonly IProductRepo _productRepo;
        private readonly IArtistRepo _artistRepo;
        public AlbumsController(ApplicationDbContext context, IAlbumRepo albumRepo, IProductRepo productRepo,IArtistRepo artistRepo)
        {
            _context = context;
            _productRepo = productRepo;
            _albumRepo = albumRepo;
            _artistRepo=artistRepo;
        }

        // GET: api/Albums
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
        {
            return await _context.Albums.Include(c=>c.Singles).ToListAsync();
        }

        // GET: api/Albums/5
        [HttpGet("{id}")]
        [Authorize ]
        public async Task<ActionResult<Album>> GetByID(int id)
        {
            var album= await _albumRepo.GetByIdAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);
        }

        // PUT: api/Albums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("{id}")]
        [Authorize ]
        public async Task<IActionResult> PutAlbum([FromRoute] int id, [FromBody] CreateAlbumDto createAlbumDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var album=await _albumRepo.UpdateAsync(id,createAlbumDto.ToUpdate(id));
            if(album==null) return NotFound();
            return Ok(album.ToAlbumDto());
        }

        // POST: api/Albums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPost]
        [Route("")]
        [Authorize ]
        public async Task<ActionResult<Album>> PostAlbum([FromQuery] int? ArtistID , [FromQuery] int? ProductID, [FromBody] CreateAlbumDto albumDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if either ProductID or ArtistID is provided
            if (!ProductID.HasValue && !ArtistID.HasValue)
            {
                return BadRequest("Either ProductID or ArtistID must be provided.");
            }


            Album albumModel = null;

            // Check and create album based on ProductID
            if (ProductID.HasValue )
            {
                if (!await _productRepo.HaveProduct((int)ProductID))
                {
                    return BadRequest("Invalid Product ID");
                }

                albumModel = albumDto.ToAddFromProduct((int)ProductID);
            }

            // Check and create album based on ArtistID
            else
            {
                if (!await _artistRepo.HaveArtist((int)ArtistID))
                {
                    return BadRequest("Invalid Artist ID");
                }

                albumModel = albumDto.ToAddFromArtist((int)ArtistID);
            }

            // Insert album
            await _albumRepo.CreateAsync(albumModel);

            // Return created album
            return CreatedAtAction(nameof(GetByID), new { id = albumModel.Id }, albumModel);
        }

        // DELETE: api/Albums/5
        [HttpDelete]
        [Route("{id}")]
        [Authorize ]
        public async Task<IActionResult> DeleteAlbum([FromRoute]int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var albumModel=_albumRepo.DeleteAsync(id);
            if (albumModel == null) return NotFound();
            return Ok(albumModel);
        }

        
    }
}
