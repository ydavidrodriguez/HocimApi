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
        private readonly ISecretsManagerService _secretsManagerService;

        public CreateCorreoRfxCommandHandler(IConfiguration configuration, IDataBaseService dataBaseService, ISecretsManagerService secretsManagerService)
        {
            _dataBaseService = dataBaseService;
            _configuration = configuration;
            _secretsManagerService = secretsManagerService;
        }
        public async Task<object> Execute(List<string> usuariosRemitentes, string Asunto, string DescripcionCorreo,
         Dictionary<string, Dictionary<string, string>> parametrosPorUsuario)
        {
            var correo = _dataBaseService.Correo.First(x => x.Descripcion == DescripcionCorreo);

            // var awsAccessKeyId = await _secretsManagerService.GetSecretAsync("awsAccessKeyId");
            // var awsSecretAccessKey = await _secretsManagerService.GetSecretAsync("awsSecretAccessKey");
            // var awsQueeurlamazon = await _secretsManagerService.GetSecretAsync("awsQueeurlamazon");

            var sqsClient = new AmazonSQSClient(RegionEndpoint.EUWest1);

            string queueUrl = _configuration["AWS:quueurlAws"];

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
                    Body = ""
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
