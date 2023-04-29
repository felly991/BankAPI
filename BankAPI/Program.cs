using BankAPI.BackGroundService;
using BankAPI.Data;
using BankAPI.Interface;
using BankAPI.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(op =>
{
    op.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddTransient<ICardCRUD, CardCRUDService>();
builder.Services.AddTransient<IPinCodeAuth, PinCodeAuthService>();
builder.Services.AddTransient<IBalanceOperations, BalanceController>();
builder.Services.AddHostedService<OperationsPerMinuteBackground>();
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
