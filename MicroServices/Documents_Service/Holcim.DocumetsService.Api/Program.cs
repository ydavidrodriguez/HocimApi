using Holcim.DocumetsService.Api.Middleware;
using Holcim.DocumetsService.Application;
using Holcim.DocumetsService.External;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
var servicioConfig = builder.Configuration.GetSection("Servicios");
// Add services to the container.
builder.Services
    //.AddWebApi()
    .AddExternal(builder.Configuration)
    //.AddCommon()
    //.AddPersistence(builder.Configuration)
    .AddApplication();

builder.Services.AddHttpClient("ApiGatewayService", client =>
{
    client.BaseAddress = new Uri(servicioConfig["ApiGatwey"]);
});


builder.Services.AddControllers(options =>
{
    options.Filters.Add<EnforceFromQueryAttribute>();
});
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("NuevaPolitica");

app.UseAuthorization();

app.MapControllers();

app.Run();
