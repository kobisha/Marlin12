namespace Marlin.sqlite.Models
{
    public class PriceList
    {
        public int ID { get; set; }
        public string? AccountID { get; set; }
        public DateTimeOffset Date { get; set; }
        public string? ProductID { get; set; }
        public string?  PriceType { get; set; }
        public string? Unit { get; set; }
        public decimal? Price { get; set; }

    }
}
