using FoodScrapper.Domain.Data.Model;
using FoodScrapper.Infrastructure.JsonHandler;
using FoodScrapper.Infrastructure.TaskHandler;
using FoodScrapper.Repository.DataContext;
using FoodScrapper.Repository.DataContext.Contract;
using FoodScrapper.Repository.Repository;
using FoodScrapper.Repository.Repository.Contract;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var isMySqlDataBase = builder.Configuration.GetSection("IsMySqlDataBase").Value;
var isMySql = bool.Parse(isMySqlDataBase ?? "false");

if (isMySql)
{
    builder.Services.AddDbContext<IDataContext, MySqlDataContext>();
    builder.Services.AddTransient<IRepository<ProductModel>, MySqlProductRepository>();
    JsonHandler.MySqlConnectionString = builder.Configuration.GetSection("MySqlConnectionString").Value; 
}
else
{
    builder.Services.AddTransient<IDataContext, MongoDbDataContext>();
    builder.Services.AddTransient<IRepository<ProductModel>, MongoDbProductRepository>();
    JsonHandler.MongoDbStringConnection =  builder.Configuration.GetSection("MongoDbConnectionString").Value;
    JsonHandler.MongoDbDataBaseName =  builder.Configuration.GetSection("MongoDbDataBaseName").Value;;
}


var messages = File.ReadAllText("./messages.json");
JsonHandler.Message = JsonConvert.DeserializeObject<dynamic>(messages)["ChallengeMessage"].Value;

new TaskRegisterer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen(c =>
{

    c.SwaggerDoc("v1", new OpenApiInfo
    {

        Version = "1.0.0",
        Title = "FoodScrapper",
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.Run();