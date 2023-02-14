using LoginPassword;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);




//connection with sql database

builder.Services.AddDbContext<ContextClass>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));


// Add services to the container.


//commet add by tushar
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
