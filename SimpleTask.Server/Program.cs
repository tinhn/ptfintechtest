using Microsoft.EntityFrameworkCore;
using SimpleTask.Server.Data;
using System;

var builder = WebApplication.CreateBuilder(args);
var pgsqlConnectionString = builder.Configuration.GetConnectionString("PgsqlConnection");
// Add services to the container.
builder.Services.AddDbContext<SimpleTaskDbContext>(options => options.UseNpgsql(pgsqlConnectionString));
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Create the database if it doesn't exist
using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    var context = service.GetRequiredService<SimpleTaskDbContext>();

    context.Database.EnsureCreated();
    SampleData.Initialize(context);
}

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

// global cors policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
