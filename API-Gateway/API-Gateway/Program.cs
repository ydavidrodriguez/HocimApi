using Microsoft.AspNetCore.Mvc;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

#pragma warning disable ASP5001
#pragma warning disable CS0618

var builder = WebApplication.CreateBuilder(args);

//[GP] Se configura el json para el enrutamiento.
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();
builder.Services.AddOcelot(builder.Configuration);

//[AM] Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader());
});

//[GP Se documenta el Gateway con sus API's
builder.Services.AddSwaggerForOcelot(builder.Configuration);
builder.Services
    .AddMvc()
    .SetCompatibilityVersion(CompatibilityVersion.Latest);

var app = builder.Build();

app.UsePathBase("/api/gateway/v1");
app.UseStaticFiles();
app.UseSwaggerForOcelotUI(builder.Configuration, o =>
{
    o.DownstreamSwaggerEndPointBasePath = "/api/gateway/v1/swagger/docs";
    o.PathToSwaggerGenerator = "/swagger/docs";
});

//[AM] Aplicar política CORS
app.UseCors("CorsPolicy");

// app.UseHttpsRedirection();

//[GP] Se usa la dependencia Ocelot
await app.UseOcelot();
app.Run();