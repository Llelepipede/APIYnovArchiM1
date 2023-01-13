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
    public class QuizzTextsController : ControllerBase
    {
        private readonly ArchiDbContext _context;

        public QuizzTextsController(ArchiDbContext context)
        {
            _context = context;
        }

        // GET: api/QuizzTexts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuizzText>>> GetQuizzText()
        {
          if (_context.QuizzText == null)
          {
              return NotFound();
          }
            return await _context.QuizzText.ToListAsync();
        }

        // GET: api/QuizzTexts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuizzText>> GetQuizzText(int id)
        {
          if (_context.QuizzText == null)
          {
              return NotFound();
          }
            var quizzText = await _context.QuizzText.FindAsync(id);

            if (quizzText == null)
            {
                return NotFound();
            }

            return quizzText;
        }

        // PUT: api/QuizzTexts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuizzText(int id, QuizzText quizzText)
        {
            if (id != quizzText.ID)
            {
                return BadRequest();
            }

            _context.Entry(quizzText).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizzTextExists(id))
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

        // POST: api/QuizzTexts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuizzText>> PostQuizzText(QuizzText quizzText)
        {
          if (_context.QuizzText == null)
          {
              return Problem("Entity set 'ArchiDbContext.QuizzText'  is null.");
          }
            _context.QuizzText.Add(quizzText);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuizzText", new { id = quizzText.ID }, quizzText);
        }

        // DELETE: api/QuizzTexts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuizzText(int id)
        {
            if (_context.QuizzText == null)
            {
                return NotFound();
            }
            var quizzText = await _context.QuizzText.FindAsync(id);
            if (quizzText == null)
            {
                return NotFound();
            }

            _context.QuizzText.Remove(quizzText);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuizzTextExists(int id)
        {
            return (_context.QuizzText?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
