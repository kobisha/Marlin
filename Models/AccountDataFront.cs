﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Marlin.sqlite.Models
{
    public class AccountData
    {
        public string AccountID { get; set; }
        [Key]
        public string? LegalCode { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool Supplier { get; set; }
        public bool Buyer { get; set; }
        public decimal? ProductsCount { get; set; }
    }
}