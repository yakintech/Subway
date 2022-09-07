using FluentValidation;
using FluentValidation.AspNetCore;
using Subway.UI.Models.dto;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddScoped<IValidator<ProductDto>, ProductDtoValidator>();

var app = builder.Build();



app.UseHttpsRedirection();
app.MapControllers();


app.Run();
