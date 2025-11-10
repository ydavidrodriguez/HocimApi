using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Models.Correo;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Holcim.Application.DataBase.Correo.Commands.Create
{
    public class CreateCorreoRfxCommandHandler:ICreateCorreoRfxCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IConfiguration _configuration;

        public CreateCorreoRfxCommandHandler(IConfiguration configuration, IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
            _configuration = configuration;
        }
        public async Task<object> Execute(List<string> usuariosRemitentes, string Asunto, string DescripcionCorreo,
         Dictionary<string, Dictionary<string, string>> parametrosPorUsuario)
        {
            var correo = _dataBaseService.Correo.First(x => x.Descripcion == DescripcionCorreo);

            var sqsClient = new AmazonSQSClient(
                _configuration["AWS:awsAccessKeyId"],
                _configuration["AWS:awsSecretAccessKey"],
                RegionEndpoint.EUWest1
            );

            string queueUrl = _configuration["AWS:queeurlamazon"];

            foreach (var destinatario in usuariosRemitentes)
            {
                if (!parametrosPorUsuario.ContainsKey(destinatario))
                    continue; // O lanzar una excepción si es obligatorio

                var parametros = parametrosPorUsuario[destinatario];
                string htmlProcesado = ReplacePlaceholders(correo.Html.Replace("\"", "'"), parametros);

                var createEmailRequest = new CreateEmailRequest
                {
                    Asunto = Asunto,
                    Destinatarios = new List<string> { destinatario },
                    Body = htmlProcesado
                };

                string mensajeJson = JsonConvert.SerializeObject(createEmailRequest);

                var sendMessageRequest = new SendMessageRequest
                {
                    QueueUrl = queueUrl,
                    MessageBody = mensajeJson
                };

                await sqsClient.SendMessageAsync(sendMessageRequest);
            }

            return ResponseApiService.Response(StatusCodes.Status201Created, "Correos enviados correctamente");
        }

        private string ReplacePlaceholders(string template, Dictionary<string, string> replacements)
        {
            foreach (var replacement in replacements)
            {
                // Replace all occurrences of the placeholder with its corresponding value
                template = template.Replace(replacement.Key, replacement.Value);
            }

            return template;
        }
    }
}
