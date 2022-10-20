using System.Globalization;

var builder = WebApplication.CreateBuilder(args);


// Test
var now = DateTime.Now;
var culture = new CultureInfo("th-TH");
Console.WriteLine(now.ToString("dd MMMM yyyy", culture));
Console.WriteLine(now.ToString("dd MMM yyyy", culture));

// Add services to the container.

builder.Services.AddControllers();
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
