using HtmlAgilityPack;
using FoodScrapper.Infrastructure.WebScrapper.PropertiesStrategy.Contracts;

namespace FoodScrapper.Infrastructure.WebScrapper.PropertiesStrategy
{
    public class ImageUrlStrategy : IPropertiesStrategy
    {
        public string GetInfo(HtmlDocument doc)
        {
            try
            {
                var div = doc.DocumentNode
                             .Descendants("div")
                             .Where(node => node.GetAttributeValue("class", "").Contains("reveal-modal") &&
                                            node.GetAttributeValue("id", "").Contains("drop_front"))
                             .FirstOrDefault();

                if (div != null)
                {
                    var img = div.Descendants().Where(d => d.Name == "img").FirstOrDefault();
                    if (img != null)
                    {
                        var imageUrl = img.Attributes["src"].Value;
                        return imageUrl;
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
