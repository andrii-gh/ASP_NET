namespace _02.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int YearPublished { get; set; }
        public string Genre { get; set; } = string.Empty;

        public int AuthorId { get; set; }
        public Author? Author { get; set; }

        public List<Genre> Genres { get; set; } = new();
    }
}