namespace Marlin.sqlite.Models
{
    public class RetroBonusResult
    {
        public int Id { get; set; }
        public string RetroBonusID { get; set; }
        public string Barcode { get; set; }
        public string Product { get; set; }
        public decimal? RetroPercent { get; set; }
        public decimal? PurchaseAmount { get; set; }
        public int? Stock { get; set; }
    }

}
