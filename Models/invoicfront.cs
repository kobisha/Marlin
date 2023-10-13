namespace Marlin.sqlite.Models
{
    public class invoicfront
    {
        public int Id { get; set; }
        public string AccountID { get; set; }
        public string OrderID { get; set; }
        public string InvoiceID { get; set; }
        public DateTime Date { get; set; }
        public string?  WaybillNumber { get; set; }
        public string? OrderNumber { get; set; }
        public string? InvoiceNumber { get; set; }
        public string? VendorID { get; set; }
        public string? Vendor { get; set; }
        public string? Shop { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal OrderAmount { get; set; }
    }

}
