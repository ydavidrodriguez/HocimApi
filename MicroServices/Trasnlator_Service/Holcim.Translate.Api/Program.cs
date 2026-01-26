using Holcim.Translate.Api.Middleware;
using Holcim.Translate.Application;

var builder = WebApplication.CreateBuilder(args);
var servicioConfig = builder.Configuration.GetSection("Servicios");
builder.Services.AddHttpContextAccessor();
builder.Services
    .AddApplication();

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<EnforceFromQueryAttribute>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("ApiGatewayService", client =>
{
    client.BaseAddress = new Uri(servicioConfig["ApiGatwey"]);
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
