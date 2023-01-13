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
    public class QuizzController : ControllerBase
    {
        private readonly ArchiDbContext _context;

        public QuizzController(ArchiDbContext context)
        {
            _context = context;
        }

        // GET: api/Quizz
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quizz>>> GetQuizzs()
        {
          if (_context.Quizzs == null)
          {
              return NotFound();
          }
            return await _context.Quizzs.ToListAsync();
        }

        // GET: api/Quizz/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quizz>> GetQuizz(int id)
        {
          if (_context.Quizzs == null)
          {
              return NotFound();
          }
            var quizz = await _context.Quizzs.FindAsync(id);

            if (quizz == null)
            {
                return NotFound();
            }

            return quizz;
        }

        // PUT: api/Quizz/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuizz(int id, Quizz quizz)
        {
            if (id != quizz.ID)
            {
                return BadRequest();
            }

            _context.Entry(quizz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizzExists(id))
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

        // POST: api/Quizz
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Quizz>> PostQuizz(Quizz quizz)
        {
          if (_context.Quizzs == null)
          {
              return Problem("Entity set 'ArchiDbContext.Quizzs'  is null.");
          }
            _context.Quizzs.Add(quizz);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuizz", new { id = quizz.ID }, quizz);
        }

        // DELETE: api/Quizz/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuizz(int id)
        {
            if (_context.Quizzs == null)
            {
                return NotFound();
            }
            var quizz = await _context.Quizzs.FindAsync(id);
            if (quizz == null)
            {
                return NotFound();
            }

            _context.Quizzs.Remove(quizz);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuizzExists(int id)
        {
            return (_context.Quizzs?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
