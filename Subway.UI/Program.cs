using DocumentFormat.OpenXml.EMMA;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Subway.UI.Models.dto;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1",
    new() { Title = "Fritz's Contacts API", Version = "v1" });
});
builder.Services.AddScoped<IValidator<ProductDto>, ProductDtoValidator>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Token:Issuer"],
        ValidAudience = builder.Configuration["Token:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
        ClockSkew = TimeSpan.Zero
    };
});

var app = builder.Build();


app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{

}

app.UseAuthorization();

app.UseSwagger(x => x.SerializeAsV2 = true);

app.UseHttpsRedirection();
app.MapControllers();


app.Run();
