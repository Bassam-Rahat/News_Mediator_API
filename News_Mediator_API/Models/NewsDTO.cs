namespace News_Mediator_API.Models
{
    public class NewsDTO
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Aurthor { get; set; } = null!;

        public string Content { get; set; } = null!;

        public DateTime CreationDate { get; set; }
    }
}
