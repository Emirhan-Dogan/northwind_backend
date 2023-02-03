using NorthwindBackend.Business;

var builder = WebApplication.CreateBuilder(args);

builder.Services.addBusinessServices();
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

Console.WriteLine(Directory.GetCurrentDirectory().ToString());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();