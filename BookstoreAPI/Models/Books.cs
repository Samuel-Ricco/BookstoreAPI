namespace BookstoreAPI.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int ReleaseYear { get; set; }
        public bool IsAvailabe { get; set; }
    }
}

