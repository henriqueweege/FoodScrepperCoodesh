using HtmlAgilityPack;
using FoodScrapper.Infrastructure.WebScrapper.PropertiesStrategy.Contracts;

namespace FoodScrapper.Infrastructure.WebScrapper.PropertiesStrategy
{
    public class CodeStrategy : IPropertiesStrategy
    {
        public string GetInfo(HtmlDocument doc)
        {
            try
            {
                var p = doc.DocumentNode.Descendants("p").Where(d => d.Id == "barcode_paragraph").FirstOrDefault();

                if (p != null)
                {
                    var infoTag = p.InnerText.Split(":")[1].Replace("\n", "").Replace(" ", "");
                    var code = infoTag.Split("(")[0];
                    return code;
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
