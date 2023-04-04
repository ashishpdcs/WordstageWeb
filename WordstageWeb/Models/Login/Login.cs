﻿using System.ComponentModel.DataAnnotations;

namespace WordstageWeb.Models.Login
{
    public partial class Login
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
