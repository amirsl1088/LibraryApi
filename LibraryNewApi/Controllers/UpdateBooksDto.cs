namespace LibraryNewApi.Controllers
{
    public partial class BooksController
    {
        public class UpdateBooksDto
        {
            public string Name { get; set; }
            public string Genre { get; set; }
            public string Writer { get; set; }
        }

    }
}

