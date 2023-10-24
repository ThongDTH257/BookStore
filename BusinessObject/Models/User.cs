using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? Source { get; set; } = string.Empty;
        public string? FirstName { get; set; } = string.Empty;

        public string? MiddleName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public int? PublisherId {  get; set; }
        public DateTime? HireDate { get; set; }

        public virtual Role? Role { get; set; }
    }
}
