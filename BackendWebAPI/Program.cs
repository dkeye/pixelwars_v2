using BackendWebAPI.Models;
using BackendWebAPI.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(new WebApplicationOptions { WebRootPath = "../static" });  // �������� ����� ��� �������� �������

// Add services to the container.
builder.Services.Configure<PixelWarsDatabaseSettings>(builder.Configuration.GetSection("PixelWarsDatabase"));
builder.Services.AddSingleton<PixelWarsService>();
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseStaticFiles();

// Configure the HTTP request pipeline.t
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
