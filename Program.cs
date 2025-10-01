using Microsoft.EntityFrameworkCore;
using RallyChampAPI.DBContext;
using RallyChampAPI.MappingProfiles;
using AutoMapper;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container


builder.Services.AddDbContext<RallyChampContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RallyChampDBConnectionString")));
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler
    = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles)
    .AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(RaceProfile).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
