using DocumentFormat.OpenXml.EMMA;
using FluentValidation;
using FluentValidation.AspNetCore;
using Subway.UI.Models.dto;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1",
    new() { Title = "Fritz's Contacts API", Version = "v1" });
});
builder.Services.AddScoped<IValidator<ProductDto>, ProductDtoValidator>();

var app = builder.Build();

app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{

}



app.UseSwagger(x => x.SerializeAsV2 = true);

app.UseHttpsRedirection();
app.MapControllers();


app.Run();
