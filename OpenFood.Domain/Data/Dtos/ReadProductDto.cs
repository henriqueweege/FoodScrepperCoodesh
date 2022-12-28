using FoodScrapper.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodScrapper.Domain.Data.Dtos
{
    public class ReadProductDto
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        private string status { get; set; }
        public string Status 
        { 
            get
            {
                return status;
            } 
            set
            { 
                if(value == "1")
                {
                    status = StatusEnum.Imported.ToString();
                }
                else if(value == "0") 
                {
                    status = StatusEnum.Draft.ToString();
                }
                else
                {
                    status = value;
                }
            }
        }
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
