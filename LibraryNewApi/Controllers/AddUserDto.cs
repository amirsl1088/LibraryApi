namespace LibraryNewApi.Controllers
{
    public partial class UserController
    {
        public class AddUserDto
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public DateTime CreateAt { get; set; }
        }
    }
}
