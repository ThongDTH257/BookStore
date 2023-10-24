using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.Book
{
    public class CreateBookDTO
    {
        public string? Title { get; set; } = string.Empty;
        public string? Type { get; set; } = string.Empty;
        public int? PublisherId { get; set; }
        public double? Price { get; set; }
        public string? Advance { get; set; }
        public double? Royalty { get; set; }
        public string? Notes { get; set; } = string.Empty;
        public DateTime? PublishedDate { get; set; }
    }
}
