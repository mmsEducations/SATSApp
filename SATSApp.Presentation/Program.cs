using Microsoft.EntityFrameworkCore;
using SATSApp.Business.Handlers;
using SATSApp.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Controller_1
builder.Services.AddControllers();

//Swagger_1
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetStudentsQueryHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddDbContext<SATSAppDbContext>(options =>
    options.UseNpgsql(@"Host=localhost;Database=postgres;Username=postgres;Password=mms;Search Path=sats")
);


var app = builder.Build();

//Swagger_2
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Controller_2
app.MapControllers();



app.Run();
