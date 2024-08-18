using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Ozz.Core.Authorization;
using Ozz.Core.Extensions.Swagger;
using SATSApp.Business.Handlers.Students;
using SATSApp.Data;
using System.Reflection;
using System.Text;

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

//1:JWT token 
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"];
var issuer = jwtSettings["Issuer"];
var audience = jwtSettings["Audience"];

//JWT Authentication Ekleme 
builder.Services.AddAuthentication(Options =>
{
    Options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;//Kimlik doðrulamasý için eklememiz gerekiyor
    Options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,//Token'ý oluþturan taraf,Güvenlik açýsýnda true yaparýz 
        ValidateAudience = false, //Token'ýn hedef kitlesi ,kullanacak taraf 
        ValidateLifetime = true, // Token'ý süresinin dolup dolmadýðýný kontrol etme 
        ValidateIssuerSigningKey = true,//Token'u imzalamak için kullanýlan anahtarýn doðruluðunu kontrol eder ,güvenliði saðlamak için zorunlu bir alandýr
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),//Token imzalanmasý için kullanýlan key anahtar verilir ,Token'ýn geçerli olup olmadýðýný kontrol eder 
        ClockSkew = TimeSpan.FromMinutes(5) //Token'ýn süresi dolduðunda bir miktara daha esnekli saðlar
    };
});

builder.Services.AddAuthentication();

builder.Services.AddScoped<TokenService>();

builder.Services.AddSwaggerConfiguration();


//Json Web Token Ayarlamalarý 

var app = builder.Build();

//Swagger_2
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Controller_2
app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
