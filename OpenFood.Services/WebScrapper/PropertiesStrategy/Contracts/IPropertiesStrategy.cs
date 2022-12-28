using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodScrapper.Infrastructure.WebScrapper.PropertiesStrategy.Contracts
{
    public interface IPropertiesStrategy
    {
        public string GetInfo(HtmlDocument doc);
    }
}
