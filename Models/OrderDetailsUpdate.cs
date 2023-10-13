namespace Marlin.sqlite.Models
{
    public class OrderDetailsUpdate
    {
        public string OrderID { get; set; }
        public string Barcode { get; set; }
        public int ReservedQuantity { get; set; }
    }
}
