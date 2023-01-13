using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIYnovArchiM1.Data;
using APIYnovArchiM1.Models;

namespace APIYnovArchiM1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagActivesController : ControllerBase
    {
        private readonly ArchiDbContext _context;

        public TagActivesController(ArchiDbContext context)
        {
            _context = context;
        }

        // GET: api/TagAtc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagActive>>> GetTagActives()
        {
          if (_context.TagActives == null)
          {
              return NotFound();
          }
            return await _context.TagActives.ToListAsync();
        }

        // GET: api/TagAtc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TagActive>> GetTagActive(int id)
        {
          if (_context.TagActives == null)
          {
              return NotFound();
          }
            var tagActive = await _context.TagActives.FindAsync(id);

            if (tagActive == null)
            {
                return NotFound();
            }

            return tagActive;
        }

        // PUT: api/TagAtc/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTagActive(int id, TagActive tagActive)
        {
            if (id != tagActive.ID)
            {
                return BadRequest();
            }

            _context.Entry(tagActive).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagActiveExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TagAtc
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TagActive>> PostTagActive(TagActive tagActive)
        {
          if (_context.TagActives == null)
          {
              return Problem("Entity set 'ArchiDbContext.TagActives'  is null.");
          }
            _context.TagActives.Add(tagActive);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTagActive", new { id = tagActive.ID }, tagActive);
        }

        // DELETE: api/TagAtc/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTagActive(int id)
        {
            if (_context.TagActives == null)
            {
                return NotFound();
            }
            var tagActive = await _context.TagActives.FindAsync(id);
            if (tagActive == null)
            {
                return NotFound();
            }

            _context.TagActives.Remove(tagActive);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TagActiveExists(int id)
        {
            return (_context.TagActives?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
