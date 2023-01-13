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
    public class QuizzChoicesController : ControllerBase
    {
        private readonly ArchiDbContext _context;

        public QuizzChoicesController(ArchiDbContext context)
        {
            _context = context;
        }

        // GET: api/QuizzChoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuizzChoice>>> GetQuizzChoices()
        {
          if (_context.QuizzChoices == null)
          {
              return NotFound();
          }
            return await _context.QuizzChoices.ToListAsync();
        }

        // GET: api/QuizzChoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuizzChoice>> GetQuizzChoice(int id)
        {
          if (_context.QuizzChoices == null)
          {
              return NotFound();
          }
            var quizzChoice = await _context.QuizzChoices.FindAsync(id);

            if (quizzChoice == null)
            {
                return NotFound();
            }

            return quizzChoice;
        }

        // PUT: api/QuizzChoices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuizzChoice(int id, QuizzChoice quizzChoice)
        {
            if (id != quizzChoice.ID)
            {
                return BadRequest();
            }

            _context.Entry(quizzChoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizzChoiceExists(id))
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

        // POST: api/QuizzChoices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuizzChoice>> PostQuizzChoice(QuizzChoice quizzChoice)
        {
          if (_context.QuizzChoices == null)
          {
              return Problem("Entity set 'ArchiDbContext.QuizzChoices'  is null.");
          }
            _context.QuizzChoices.Add(quizzChoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuizzChoice", new { id = quizzChoice.ID }, quizzChoice);
        }

        // DELETE: api/QuizzChoices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuizzChoice(int id)
        {
            if (_context.QuizzChoices == null)
            {
                return NotFound();
            }
            var quizzChoice = await _context.QuizzChoices.FindAsync(id);
            if (quizzChoice == null)
            {
                return NotFound();
            }

            _context.QuizzChoices.Remove(quizzChoice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuizzChoiceExists(int id)
        {
            return (_context.QuizzChoices?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
