using HtmlAgilityPack;
using FoodScrapper.Infrastructure.WebScrapper.PropertiesStrategy.Contracts;

namespace FoodScrapper.Infrastructure.WebScrapper.PropertiesStrategy
{
    public class ProductNameStrategy : IPropertiesStrategy
    {
        public string GetInfo(HtmlDocument doc)
        {
            try
            {
                var h2 = doc.DocumentNode
                               .DescendantsAndSelf("h2")
                               .Where(node => node.GetAttributeValue("class", "").Contains("title-1"))
                               .FirstOrDefault();

                if (h2 != null)
                {

                    var title = h2.FirstChild.InnerText.ToString();
                    var name = title.Split("-")[0];
                    return name;
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
