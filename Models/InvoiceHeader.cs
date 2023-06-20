namespace Marlin.sqlite.Models
{
    public class InvoiceHeader
    {
        public int ID { get; set; }
        public string? OrderID { get; set; }
        public string? InvoiceID { get; set; }
        public DateTimeOffset Date { get; set; }
        public decimal? Number { get; set; }
        public decimal? Amount { get; set; }
        public string? StatusID { get; set; }
        public string? WaybillNumber { get; set; }
        public DateTimeOffset PaymentDate { get; set; }

    }
}
