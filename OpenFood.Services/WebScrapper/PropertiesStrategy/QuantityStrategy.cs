using HtmlAgilityPack;
using FoodScrapper.Infrastructure.WebScrapper.PropertiesStrategy.Contracts;

namespace FoodScrapper.Infrastructure.WebScrapper.PropertiesStrategy
{
    public class QuantityStrategy : IPropertiesStrategy
    {
        public string GetInfo(HtmlDocument doc)
        {
            try
            {
                var p = doc.DocumentNode.Descendants("p").Where(d => d.Id == "field_quantity").FirstOrDefault();

                if (p != null)
                {
                    var quantity = p.InnerText.Split(":")[1].Replace("\n", "").Replace(" ", "");
                    return quantity;
                }

                return "None";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
