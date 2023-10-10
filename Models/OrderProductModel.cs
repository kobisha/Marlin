namespace Marlin.sqlite.Models
{
    public class OrderProductModel
    {
        public int Id { get; set; }
        public string OrderHeaderID { get; set; }
        public string Barcode { get; set; } // Change the property name to Barcode
        public string Unit { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Amount { get; set; }
        public decimal? ReservedQuantity { get; set; }
        public string ProductID { get; set; }
    }
}
