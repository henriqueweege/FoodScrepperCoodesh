using HtmlAgilityPack;
using FoodScrapper.Infrastructure.WebScrapper.PropertiesStrategy.Contracts;

namespace FoodScrapper.Infrastructure.WebScrapper.PropertiesStrategy
{
    public class CategoriesStrategy : IPropertiesStrategy
    {
        public string GetInfo(HtmlDocument doc)
        {
            try
            {
                var p = doc.DocumentNode.Descendants("p").Where(d => d.Id == "field_categories").FirstOrDefault();

                if (p != null)
                {
                    var span = p.ChildNodes.FirstOrDefault(span => span.Id.Contains("field_categories_value"));
                    return span.InnerText;
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
