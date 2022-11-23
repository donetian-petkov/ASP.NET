using Microsoft.OpenApi.Models;
using WebShopDemo.Core.Contracts;
using WebShopDemo.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1" , new OpenApiInfo()
    {
        Title = "My WebShop",
        Description = "This is a simple webshop",
        License = new OpenApiLicense()
        {
            Name = "EUPL v1.2"
        }
    });
    
    c.IncludeXmlComments("WebShopAPIDocumentation.xml");
});
builder.Services.AddScoped<IProductService, ProductService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();