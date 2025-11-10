using Holcim.TaskSend.Api;
using Holcim.TaskSend.Application;
using Holcim.TaskSend.Application.DataBase.Contratos.Commands.LaunchAprovalFlow;
using Holcim.TaskSend.Application.DataBase.Contratos.Commands.SendContratos;
using Holcim.TaskSend.Application.DataBase.Email.Commands.SendEmail;
using Holcim.TaskSend.Application.DataBase.Subasta.Commands.UpdateStateSubasta;
using Holcim.TaskSend.External;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddWebApi()
    .AddApplication()
    .AddExternal(builder.Configuration);
//.AddCommon()
//.AddPersistence(builder.Configuration)
builder.Services.AddHostedService<SendEmailCommandHandler>();
builder.Services.AddHostedService<SendContratosCommandHandler>();
builder.Services.AddHostedService<LaunchAprovalFlowCommandHandler>();
builder.Services.AddHostedService<UpdateStateSubastaCommandHandler>();

builder.Services.AddControllers();
builder.Services.AddCors(options =>

    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        ;
    })
    );


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("NuevaPolitica");

app.UseAuthorization();

app.MapControllers();

app.Run();
