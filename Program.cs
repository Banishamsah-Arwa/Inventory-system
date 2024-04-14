using InventoryManagementSystem;
using InventoryManagementSystem.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = "Server=localhost;Port=5432;Database=postgres;Username=postgres;Password=123456;";
builder.Services.AddSingleton<ICategory>(new CategoryService(connectionString)); 
builder.Services.AddSingleton<Iitem>(new ItemService(connectionString));
builder.Services.AddSingleton<IUser>(new UserService(connectionString));
var purchaseService = new PurchaseService(connectionString);
builder.Services.AddSingleton<IPurchase>(purchaseService );


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
