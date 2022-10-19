using System.Security.Claims;

namespace BBAttendance.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _context;

        public UserService(IHttpContextAccessor httpContextAccessor,DataContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public string GetMyName()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue("name");
            }
            return result;
        }
    }
}
