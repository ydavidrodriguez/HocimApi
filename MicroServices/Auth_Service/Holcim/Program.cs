using System.Text;
using Holcim;
using Holcim.Application;
using Holcim.External;
using Holcim.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var servicioConfig = builder.Configuration.GetSection("Servicios");
builder.Services.AddHttpContextAccessor();
// Add services to the container.

builder.Services
    .AddWebApi()
    .AddExternal(builder.Configuration)
    //.AddCommon()
    //.AddPersistence(builder.Configuration)
    .AddApplication();

builder.Services.AddControllers(options =>
{
    //options.Filters.Add<EnforceFromQueryAttribute>();
} );
builder.Services.AddCors(options =>

    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    })
    );



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("ApiGatewayService", client =>
{
    var apiGateway = servicioConfig["ApiGatwey"];
    if (!string.IsNullOrWhiteSpace(apiGateway))
    {
        client.BaseAddress = new Uri(apiGateway);
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("NuevaPolitica");

app.UseAuthorization();

app.MapControllers();

app.Run();
