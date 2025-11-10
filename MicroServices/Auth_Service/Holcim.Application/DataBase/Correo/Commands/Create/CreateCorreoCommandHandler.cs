using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using Holcim.Application.Feature;
using Holcim.Domain.Models.Correo;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Holcim.Application.DataBase.Correo.Commands.Create
{
    public class CreateCorreoCommandHandler : ICreateCorreoCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IConfiguration _configuration;


        public CreateCorreoCommandHandler(IDataBaseService dataBaseService, IConfiguration configuration)
        {
            _dataBaseService = dataBaseService;
            _configuration = configuration;
        }
        public async Task<object> Execute(List<string> usuariosRemitentes, string Asunto, string DescripcionCorreo,
            Dictionary<string, string> parameterescorreo)
        {

            Domain.Entities.Correo.Correo correo =
                 _dataBaseService.Correo.Where(x => x.Descripcion == DescripcionCorreo).First();

            CreateEmailRequest createEmailRequest = new CreateEmailRequest();
            string Replace = correo.Html.Replace("\"", "'").ToString();
            string Htmlfinal = ReplacePlaceholders(Replace, parameterescorreo);
      
            createEmailRequest.Asunto = Asunto;
            createEmailRequest.Destinatarios =  usuariosRemitentes ;
            createEmailRequest.Body = Htmlfinal;

            var sqsClient = new AmazonSQSClient(_configuration["AWS:awsAccessKeyId"],
                _configuration["AWS:awsSecretAccessKey"], RegionEndpoint.EUWest1); // Specify your region

            // Define the SQS queue URL
            string queueUrl = _configuration["AWS:queeurlamazon"];
            string mensajejson = JsonConvert.SerializeObject(createEmailRequest);

            // Create a message
            var sendMessageRequest = new SendMessageRequest
            {
                QueueUrl = queueUrl,
                MessageBody = mensajejson
            };

            // Send the message
            var sendMessageResponse = await sqsClient.SendMessageAsync(sendMessageRequest);
            Console.WriteLine($"Message sent! Message ID: {sendMessageResponse.MessageId}");
            return ResponseApiService.Response(StatusCodes.Status201Created, createEmailRequest);
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
