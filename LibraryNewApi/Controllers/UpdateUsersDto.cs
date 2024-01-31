using System.ComponentModel.DataAnnotations;

namespace LibraryNewApi.Controllers
{
    public partial class UserController
    {
        public class UpdateUsersDto
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public DateTime CreateAt { get; set; }
        }
    }
}
