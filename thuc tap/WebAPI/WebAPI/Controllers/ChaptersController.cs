using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dto.Chapter;
using WebAPI.Dto.Comic;
using WebAPI.Interface;
using WebAPI.Mapper;
using WebAPI.Model;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChaptersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IComicRepo _comicRepo;
        private readonly IChapterRepo _chapterRepo;
        public ChaptersController(ApplicationDbContext context, IComicRepo comicRepo, IChapterRepo chapterRepo)
        {
            _context = context;
            _comicRepo = comicRepo;
            _chapterRepo = chapterRepo;
        }

        // GET: api/Chapters
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Chapter>>> GetChapters()
        {
            return await _context.Chapters.ToListAsync();
        }

        // GET: api/Chapters/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Chapter>> GetByID(int id)
        {
            var chapter = await _chapterRepo.GetByIdAsync(id);

            if (chapter == null)
            {
                return NotFound();
            }

            return Ok(chapter.ToChapterDto());
        }

        // PUT: api/Chapters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> PutChapter([FromRoute] int id, [FromBody] CreateChapterDto chapterDto)
        {
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var updatedComic = await _chapterRepo.UpdateAsync(id, chapterDto.ToAdd(id));

                if (updatedComic == null)
                {
                    return NotFound();
                }

                return Ok(updatedComic.ToChapterDto());
            }
        }

            // POST: api/Chapters
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost("{ComicID}")]
            [Authorize]
            public async Task<ActionResult<Chapter>> PostChapter([FromRoute] int ComicID, [FromBody] CreateChapterDto chapterDto)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (!await _comicRepo.HaveComic(ComicID))
                {
                    return BadRequest("Invalid Comic ID");
                }

                var chapterModel = chapterDto.ToAdd(ComicID);
                await _chapterRepo.CreateAsync(chapterModel);

                return CreatedAtAction(nameof(GetByID), new { id = chapterModel.Id }, chapterModel);
            }

            // DELETE: api/Chapters/5
            [HttpDelete("{id}")]
            [Authorize]
            public async Task<IActionResult> DeleteChapter(int id)
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var commentModel = await _chapterRepo.DeleteAsync(id);
                if (commentModel == null)
                {
                    return NotFound("chapter not exists");
                }
                return Ok(commentModel);
            }


        }
    }

