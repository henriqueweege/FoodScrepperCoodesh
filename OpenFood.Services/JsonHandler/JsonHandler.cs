using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodScrapper.Infrastructure.JsonHandler
{
    public static class JsonHandler
    {
        public static string MySqlConnectionString { get; set; }
        public static string MongoDbStringConnection { get; set; }
        public static string MongoDbDataBaseName { get; set; }
        public static string Message { get; set; }
    }
}
