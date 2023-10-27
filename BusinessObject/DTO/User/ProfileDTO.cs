﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.User
{
    public class ProfileDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? Source { get; set; } = string.Empty;
        public string? FirstName { get; set; } = string.Empty;

        public string? MiddleName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
    }
}
