

namespace FoodScrapper.Domain.Data.Model
{
    public class ProductModel
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        public int Status { get; set; }
        public DateTime Imported { get; set; }
        public string Url { get; set; }
        public string ProductName { get; set; }
        public string Quantity { get; set; }
        public string Categories { get; set; }
        public string Packaging { get; set; }
        public string Brands { get; set; }
        public string ImageUrl { get; set; }
    }
}
