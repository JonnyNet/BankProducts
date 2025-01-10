using BankProducts.Application;
using BankProducts.Domain;
using BankProducts.Infrastructure;
using Microsoft.OpenApi.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services

    .AddDomain()
    .AddEndpointsApiExplorer()
    .AddInfrastructure(builder.Configuration, "Default")
    .AddApplication()
    .AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
    builder =>
    {
        builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(_ => true)
        .AllowCredentials();
    });
});

builder.Services.AddSwaggerGen(c =>
 {
     c.SwaggerDoc("v1", new OpenApiInfo
     {
         Version = "v1",
         Title = "Web API",
         Description = "Microservicio",
         Contact = new OpenApiContact
         {
             Name = "Customer Service",
             Email = "servicioalcliente@bank.com",
             Url = new Uri("https://www.bank.com.co/contactanos/")
         }
     });
 });

WebApplication app = builder.Build();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API");
    c.RoutePrefix = string.Empty;
});

app.RunMigrationsRepositories();
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.Run();
