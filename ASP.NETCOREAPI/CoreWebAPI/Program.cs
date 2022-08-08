using BusinessAccessLayerLib.Services;
using DataAccessLayerLib.Data;
using DataAccessLayerLib.Interfaces;
using DataAccessLayerLib.Models;
using DataAccessLayerLib.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var _configuration = builder.Configuration;

// Add services to the container.
// Add services to the container.
// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddHttpClient();
builder.Services.AddTransient<IRepository<Person>, PersonRepository>();

builder.Services.AddTransient<PersonService, PersonService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CoreWebAPI", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoreWebAPI v1");
    });
}
//middleware services
app.UseHttpsRedirection();
app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();
