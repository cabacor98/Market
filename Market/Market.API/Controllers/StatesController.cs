using Market.API.Data;
using Market.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Market.API.Controllers
{
    [ApiController]
    [Route("/api/states")]
    public class StatesController : ControllerBase
    {
        private readonly DataContext _context;

        public StatesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.States.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var state = await _context.States.FirstOrDefaultAsync(c => c.Id == id);

            if (state == null)
            {
                return NotFound();
            }

            return Ok(state);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Country state)
        {
            _context.Add(state);
            await _context.SaveChangesAsync();
            return Ok(state);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Country state)
        {
            _context.Update(state);
            await _context.SaveChangesAsync();
            return Ok(state);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedrow = await _context.States.Where(c => c.Id == id).ExecuteDeleteAsync();

            if (afectedrow == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
