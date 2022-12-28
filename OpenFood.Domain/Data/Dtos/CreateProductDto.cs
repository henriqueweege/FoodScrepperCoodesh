using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodScrapper.Domain.Data.Dtos
{
    public class CreateProductDto
    {
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string Url { get; set; }
        public string ProductName { get; set; }
        public string Quantity { get; set; }
        public string Categories { get; set; }
        public string Packaging { get; set; }
        public string Brands { get; set; }
        public string ImageUrl { get; set; }
    }
}
