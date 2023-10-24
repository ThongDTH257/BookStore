using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class Publisher
    {

        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? City { get; set; } = string.Empty;
        public string? State { get; set; } = string.Empty;
        public string? Country { get; set; } = string.Empty;

        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
