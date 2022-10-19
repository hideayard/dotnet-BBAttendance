using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BBAttendance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUserService _userService;

        public AttendanceController(DataContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        [HttpGet("whoami"),Authorize]
        public async Task<ActionResult<string>> Whoami()
        {
            var userName = _userService.GetMyName();
            return Ok(userName);
        }


        [HttpGet, Authorize]
        public async Task<ActionResult<List<Attendance>>> Get()
        {
            return Ok(await _context.Attendances.ToListAsync());
        }

        [HttpGet("{id}"), Authorize]
        public async Task<ActionResult<Attendance>> Get(int id)
        {
            var data = await _context.Attendances.FindAsync(id);
            if (data == null)
                return BadRequest("Attendance not found.");
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<List<Attendance>>> Attend(Attendance data)
        {
            _context.Attendances.Add(data);
            await _context.SaveChangesAsync();

            return Ok(await _context.Attendances.ToListAsync());
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<ActionResult<List<Attendance>>> Delete(int id)
        {
            var dbAttendance = await _context.Attendances.FindAsync(id);
            if (dbAttendance == null)
                return BadRequest("Attendance not found.");

            _context.Attendances.Remove(dbAttendance);
            await _context.SaveChangesAsync();

            return Ok(await _context.Attendances.ToListAsync());
        }

    }
}
