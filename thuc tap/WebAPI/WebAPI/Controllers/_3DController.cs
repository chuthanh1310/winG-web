using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dto.threeD;
using WebAPI.Interface;
using WebAPI.Mapper;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class _3DController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly I3DRepo _repo3D;
        private readonly IProductRepo _productRepo;

        public _3DController(ApplicationDbContext context,I3DRepo repo3D,IProductRepo productRepo)
        {
            _context = context;
            _repo3D=repo3D;
            _productRepo=productRepo;
        }

        // GET: api/_3D
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<_3D>>> Get_3Ds()
        {
            return await _context._3Ds.ToListAsync();
        }

        // GET: api/_3D/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<_3D>> Get_3D([FromRoute]int id)
        {
            var _3D = await _repo3D.GetByIDAsync(id);

            if (_3D == null)
            {
                return NotFound();
            }

            return Ok(_3D.To3DDto());
        }

        // PUT: api/_3D/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put_3D([FromRoute]int id, [FromBody]Create3dDto create3DDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var x=await _repo3D.UpdateAsync(id,create3DDto.ToAdd(id));
            return NoContent();
        }

        // POST: api/_3D
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{ProductID}")]
        [Authorize]
        public async Task<ActionResult<_3D>> Post_3D([FromRoute]int ProductID,Create3dDto create3DDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            if (!await _productRepo.HaveProduct(ProductID))
            {
                return BadRequest("Product doesn't exist");
            }
            var Model3D=create3DDto.ToAdd(ProductID);
            await _repo3D.CreateAsync(Model3D);
            return CreatedAtAction(nameof(Get_3D), new { id = Model3D._3DID }, Model3D.To3DDto());
        }

        // DELETE: api/_3D/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete_3D(int id)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var model3D=await _repo3D.DeleteAsync(id);
            if(model3D==null) return NotFound();    
            return Ok(model3D);
        }

        
    }
}
