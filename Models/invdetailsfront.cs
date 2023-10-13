namespace Marlin.sqlite.Models
{
    public class invdetails
    {
        public int Id { get; set; }
       
        public string Product { get; set; }
        public string Barcode { get; set; }
        public string? Unit { get; set; }
        public decimal? InvoiceQuantity { get; set; }
        public decimal? OrderQuantity { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public decimal? OrderAmount { get; set; }
        public bool RedStatus { get; set; }
    }
}
