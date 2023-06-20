﻿namespace Marlin.sqlite.Models
{
    public class detailsFront
    {
        public int Id { get; set; }
        public string? ProductID { get; set; }
        public string? Product { get; set;}
        public string? Barcode { get; set;}
        public string? Unit { get; set;}
        public decimal? Quantity { get; set;}
        public decimal? Price { get; set;}
        public decimal? Amount { get; set;}
        public decimal? ReservedQuantity { get; set;}
        public Boolean RedStatus { get; set;}
    }
}
