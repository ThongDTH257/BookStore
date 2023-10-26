using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Range(1, Double.MaxValue)]
        public double? Price { get; set; }
        public string? Advance { get; set; }
        [Range(1, Double.MaxValue)]
        public double? Royalty { get; set; }
        public string? Notes { get; set; } = string.Empty;
        public DateTime? PublishedDate { get; set; }
    }
}
