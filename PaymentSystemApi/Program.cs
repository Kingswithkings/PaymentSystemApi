using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PaymentSystemApi.Data;
using PaymentSystemApi.Interfaces.IBaseRepository;
using PaymentSystemApi.Interfaces.IServices;
using PaymentSystemApi.Models;
using PaymentSystemApi.Profiles.Automappings;
using PaymentSystemApi.Repository;
using PaymentSystemApi.Services;
using static PaymentSystemApi.Interfaces.IBaseRepository.IBaseRepository;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
         options.UseSqlServer(builder.Configuration.GetConnectionString("PaymentSystemApiConnectionString")));
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IMerchantService, MerchantService>();
builder.Services.AddAutoMapper(typeof(PaymentSystemMappings));
builder.Services.AddScoped<IBaseRespository<Merchant>, MerchantRepository>();

builder.Services.AddScoped<IBaseRespository<Customer>, CustomerRepository>();
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