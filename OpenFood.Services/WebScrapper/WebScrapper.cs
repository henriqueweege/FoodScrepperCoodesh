using HtmlAgilityPack;
using FoodScrapper.Domain.Data.Dtos;
using FoodScrapper.Infrastructure.WebScrapper.PropertiesStrategy;

namespace FoodScrapper.Services.WebScrapper
{
    public class WebScrapper
    {
        private Uri BaseUri { get; set; }
        private List<string> ProductLinks { get; set; }
        public List<CreateProductDto> Products { get; set; }
        private BarcodeStrategy BarcodeStrategy { get; set; }
        private BrandsStrategy BrandsStrategy { get; set; }
        private CategoriesStrategy CategoriesStrategy { get; set; }
        private CodeStrategy CodeStrategy { get; set; }
        private ImageUrlStrategy ImageUrlStrategy { get; set; }
        private PackagingStrategy PackagingStrategy { get; set; }
        private ProductNameStrategy ProductNameStrategy { get; set; }
        private QuantityStrategy QuantityStrategy { get; set; }

        public WebScrapper(string url)
        {

            BarcodeStrategy = new BarcodeStrategy();
            BrandsStrategy = new BrandsStrategy();
            CategoriesStrategy = new CategoriesStrategy();
            CodeStrategy = new CodeStrategy();
            ImageUrlStrategy = new ImageUrlStrategy();
            PackagingStrategy = new PackagingStrategy();
            ProductNameStrategy = new ProductNameStrategy();
            QuantityStrategy = new QuantityStrategy();

            BaseUri = new Uri(url);
            Products = new List<CreateProductDto>();
            ProductLinks = GetLinkProducts(GetHtml(url));

            GetProductInfo();
        }

        private HtmlDocument GetHtml(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = client.GetStringAsync(url);
                response.Wait();
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(response.Result);
                return htmlDoc;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<string> GetLinkProducts(HtmlDocument doc)
        {
            try
            {
                var ulList = doc.DocumentNode.Descendants("ul").Where(node => node.GetAttributeValue("class", "").Contains("products")).First();
                var liList = ulList.Descendants().Where(x => x.Name == "li");
                var aList = liList.Select(x => x.Descendants().Where(x => x.Name == "a").First());
                var href = aList.Select(x => x.Attributes["href"]).Select(x => x.Value);

                return href.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetProductInfo()
        {
            for (var i =0; Products.Count<100;i++)
            {
                try
                {
                    var productUrl = $"{BaseUri}{ProductLinks[i].Substring(1, ProductLinks[i].Length - 1)}";
                    var doc = GetHtml(productUrl);

                    var product = new CreateProductDto();
                    product.Url = productUrl;
                    product.ProductName = ProductNameStrategy.GetInfo(doc);
                    product.Quantity = QuantityStrategy.GetInfo(doc);
                    product.Brands = BrandsStrategy.GetInfo(doc);
                    product.Packaging = PackagingStrategy.GetInfo(doc);
                    product.Categories = CategoriesStrategy.GetInfo(doc);
                    product.Barcode = BarcodeStrategy.GetInfo(doc);
                    product.Code = CodeStrategy.GetInfo(doc);
                    product.ImageUrl = ImageUrlStrategy.GetInfo(doc);

                    Products.Add(product);
                    
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
