using Holcim.AuctionService.Api;
using Holcim.AuctionService.Api.Middleware;
using Holcim.AuctionService.Application;
using Holcim.AuctionService.External;

var builder = WebApplication.CreateBuilder(args);

var servicioConfig = builder.Configuration.GetSection("Servicios");

builder.Services
    .AddWebApi()
    .AddExternal(builder.Configuration)
    .AddExternal(builder.Configuration)
    .AddApplication();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<EnforceFromQueryAttribute>();
});

builder.Services.AddHttpClient("ApiGatewayService", client =>
{
    client.BaseAddress = new Uri(servicioConfig["ApiGatwey"]);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins("https://example.com", "https://another-origin.com")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();
    });
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
