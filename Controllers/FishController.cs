using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnet_rpg.Models;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("fish-controller")]
    public class FishController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FishController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Fish
        [HttpGet("get-fish")]
        public async Task<ActionResult<IEnumerable<Fish>>> GetFish()
        {
            if (_context.Fish == null)
            {
                return NotFound();
            }
            var fishList = await _context.Fish.ToListAsync();
            return Ok(fishList); // Return OK with the list of fish
        }

        // GET: api/Fish/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fish>> GetFish(int id)
        {
            if (_context.Fish == null)
            {
                return NotFound();
            }
            var fish = await _context.Fish.FindAsync(id);

            if (fish == null)
            {
                return NotFound();
            }

            return Ok(fish); // Return OK with the fish object
        }

        // PUT: api/Fish/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFish(int id, Fish fish)
        {
            if (id != fish.Id)
            {
                return BadRequest();
            }

            _context.Entry(fish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FishExists(id))
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

        // POST: api/Fish
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fish>> PostFish(Fish fish)
        {
            if (_context.Fish == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Fish' is null.");
            }
            _context.Fish.Add(fish);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFish), new { id = fish.Id }, fish);
        }

        // DELETE: api/Fish/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFish(int id)
        {
            if (_context.Fish == null)
            {
                return NotFound();
            }
            var fish = await _context.Fish.FindAsync(id);
            if (fish == null)
            {
                return NotFound();
            }

            _context.Fish.Remove(fish);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FishExists(int id)
        {
            return _context.Fish.Any(e => e.Id == id);
        }
    }
}
