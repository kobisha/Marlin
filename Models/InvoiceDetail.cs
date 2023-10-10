using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marlin.sqlite.Models
{
    public class InvoiceDetail
    {
        public int id { get; set; }
        public string? InvoiceHeaderID { get; set; }
        public string? Barcode { get; set; }
        public string? Unit { get; set; }
        [Column(TypeName = "numeric")]
        public decimal? Quantity { get; set; }
        [Column(TypeName = "numeric")]
        public decimal? Price { get; set; }
        [Column(TypeName = "numeric")]
        public decimal? Amount { get; set; }
        
    }
}
