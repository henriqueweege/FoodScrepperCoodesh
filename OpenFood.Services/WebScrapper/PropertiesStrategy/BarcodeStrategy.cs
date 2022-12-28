using HtmlAgilityPack;
using FoodScrapper.Infrastructure.WebScrapper.PropertiesStrategy.Contracts;

namespace FoodScrapper.Infrastructure.WebScrapper.PropertiesStrategy
{
    public class BarcodeStrategy : IPropertiesStrategy
    {
        public string GetInfo(HtmlDocument doc)
        {
            try
            {
                var p = doc.DocumentNode.Descendants("p").Where(p => p.Id == "barcode_paragraph").FirstOrDefault();

                if (p != null)
                {
                    return p.InnerText.Split(":")[1].Replace("\n", "").Replace(" ", "");
                }

                return "None";
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
