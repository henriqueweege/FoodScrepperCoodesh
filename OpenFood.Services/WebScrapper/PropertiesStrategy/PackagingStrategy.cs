using HtmlAgilityPack;
using FoodScrapper.Infrastructure.WebScrapper.PropertiesStrategy.Contracts;

namespace FoodScrapper.Infrastructure.WebScrapper.PropertiesStrategy
{
    public class PackagingStrategy : IPropertiesStrategy
    {
        public string GetInfo(HtmlDocument doc)
        {
            try
            {
                var p = doc.DocumentNode.Descendants("p").Where(d => d.Id == "field_packaging").FirstOrDefault();

                if (p != null)
                {

                    var span = p.ChildNodes.Where(span => span.Id == "field_packaging_value").FirstOrDefault();

                    if (span != null)
                    {
                        var packing = span.InnerText;

                        return packing;

                    }
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
