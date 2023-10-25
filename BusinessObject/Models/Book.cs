using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; } = string.Empty;
        public string? Type {  get; set; } = string.Empty;
        public int? PublisherId { get; set; }
        public double? Price { get; set; }
        public string? Advance {  get; set; }
        public double? Royalty { get; set; }
        public string? Notes { get; set; } = string.Empty;
        public DateTime? PublishedDate { get; set; }

        public virtual ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
        public virtual Publisher? Publisher { get; set; } 
        [JsonIgnore]
        public virtual List<Author> Authors { get; set; } = new();
    }
}
