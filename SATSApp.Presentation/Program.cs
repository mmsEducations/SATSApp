var builder = WebApplication.CreateBuilder(args);

//Controller_1
builder.Services.AddControllers();

//Swagger_1
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
