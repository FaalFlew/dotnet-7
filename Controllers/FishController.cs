using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using dotnet_rpg.Models;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("fish-controller")]
    public class FishController : ControllerBase
    {
        private readonly IDbConnection _connection;

        public FishController(IDbConnection connection)
        {
            _connection = connection;
        }

        // GET: api/Fish
        [HttpGet("get-fish")]
        public async Task<ActionResult<IEnumerable<Fish>>> GetFish()
        {
            var fishList = await _connection.QueryAsync<Fish>("SELECT * FROM Fish");
            return Ok(fishList); // Return OK with the list of fish
        }

        // GET: api/Fish/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fish>> GetFish(int id)
        {
            var fish = await _connection.QueryFirstOrDefaultAsync<Fish>("SELECT * FROM Fish WHERE Id = @Id", new { Id = id });

            if (fish == null)
            {
                return NotFound();
            }

            return Ok(fish); // Return OK with the fish object
        }

        // PUT: api/Fish/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFish(int id, Fish fish)
        {
            if (id != fish.Id)
            {
                return BadRequest();
            }

            var affectedRows = await _connection.ExecuteAsync("UPDATE Fish SET Name = @Name WHERE Id = @Id", new { Name = fish.Name, Id = fish.Id });

            if (affectedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Fish
        [HttpPost]
        public async Task<ActionResult<Fish>> PostFish(Fish fish)
        {
            var result = await _connection.ExecuteScalarAsync<int>("INSERT INTO Fish (Name) VALUES (@Name); SELECT LAST_INSERT_ID()", new { Name = fish.Name });

            fish.Id = result;

            return CreatedAtAction(nameof(GetFish), new { id = fish.Id }, fish);
        }

        // DELETE: api/Fish/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFish(int id)
        {
            var affectedRows = await _connection.ExecuteAsync("DELETE FROM Fish WHERE Id = @Id", new { Id = id });

            if (affectedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
