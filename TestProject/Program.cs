using BusinessLayer;
using BusinessLayer.Categories;
using BusinessLayer.CategoryBal;
using BusinessLayer.Products;
using BusinessLayer.ProductsBal;
using DataLayer;
using DataLayer.DataContext;
using DataLayer.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ProductContext>();
builder.Services.AddScoped<ProductDal,ProductDal>();
builder.Services.AddScoped<CategoryDal, CategoryDal>();
builder.Services.AddScoped<IProduct, Products>();
builder.Services.AddScoped<ICategory, Categories>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
