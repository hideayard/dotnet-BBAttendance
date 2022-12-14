using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BBAttendance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return BadRequest("Hero not found.");
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateUser(User request)
        {
            var data = await _context.Users.FindAsync(request.Id);
            if (data == null)
                return BadRequest("User not found.");

            data.Name = request.Name;
            // data.FirstName = request.FirstName;
            // data.LastName = request.LastName;
            // data.Place = request.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> Delete(int id)
        {
            var data = await _context.Users.FindAsync(id);
            if (data == null)
                return BadRequest("User not found.");

            _context.Users.Remove(data);
            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());
        }

    }
}
