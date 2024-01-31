using LibraryManagmentAPI;
using LibraryNewApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryNewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class UserController : ControllerBase
    {
        private readonly EFDataContext _context;
        public UserController(EFDataContext context)
        {
            _context = context;
        }

        [HttpPost("set-users")]
        public int Add([FromBody] AddUserDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                CreateAt = dto.CreateAt
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.Id;
        }
        [HttpGet("get-user")]
        public List<GetUserDto> GetUserDtos([FromQuery] string username=null)
        {
            var users = _context.Users
                .Select(_ => new GetUserDto
                {
                    Id = _.Id,
                    Name = _.Name,
                    Email = _.Email,
                    CreatAt = _.CreateAt
                })
                .ToList();
            if (username != null)
            {
                users = users.Where(_ => _.Name == username).ToList();
                return users;
            }
            return users;
        }
        [HttpPut("update-users")]
        public void UpdateUsers([FromQuery] int id,[FromBody]UpdateUsersDto dto)
        {
            var user = _context.Users.Where(_ => _.Id == id).First();
            user.Name = dto.Name;
            user.Email = dto.Email;
            user.CreateAt = dto.CreateAt;
            _context.SaveChanges();
        }
        [HttpDelete("delete-users")]
        public void DeleteUsers([FromQuery]int id)
        {
            var user = _context.Users.Where(_ => _.Id == id).First();
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
