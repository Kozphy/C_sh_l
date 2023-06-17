using System.ComponentModel.DataAnnotations;

namespace mvc_api.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }
        public int Read { get; set; }
        public Guid UserId { get; set; }
        public virtual Users User { get; set; }
    }
}
