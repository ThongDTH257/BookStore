using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class BookAuthor
    {
        public int AuthorId { get; set; }
        public int BookId {  get; set; }
        public string? AuthorOrder { get; set; } = string.Empty;
        public double? RoyaltyPercentage { get; set; }

        public Book Book { get; set; } = null!;
        public Author Author { get; set; } = null!;
    }
}
