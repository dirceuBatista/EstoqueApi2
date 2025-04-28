using System.Text;
using EstoqueApi;
using EstoqueApi.Data;
using EstoqueApi.Services;
using EstoqueApi.Services.TokenService;
using EstoqueApi.Services.UserServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };

});

builder
    .Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });
builder.Services.AddTransient<TokenService>();
builder.Services.AddScoped<CustumerService>();
builder.Services.AddScoped<TennisService>();
builder.Services.AddScoped<SaleService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddDbContext<DataContext>();
var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


app.Run();
