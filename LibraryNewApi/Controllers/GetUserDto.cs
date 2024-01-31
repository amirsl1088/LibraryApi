namespace LibraryNewApi.Controllers
{
    public partial class UserController
    {
        public class GetUserDto
        {
            public int Id { get; set; }
            public string Name  { get; set; }
            public string Email { get; set; }
            public DateTime CreatAt { get; set; }
        }
    }
}
