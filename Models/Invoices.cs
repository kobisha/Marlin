﻿namespace Marlin.sqlite.Models
{
    public class Invoices
    {
        public int id { get; set; }
        public string? AccountID { get; set; }
        public string? OrderID { get; set; }
        public string? Package { get; set; }
        public DateTime Period { get; set; }
        public string? Number { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public string? Status { get; set; }
    }
}
