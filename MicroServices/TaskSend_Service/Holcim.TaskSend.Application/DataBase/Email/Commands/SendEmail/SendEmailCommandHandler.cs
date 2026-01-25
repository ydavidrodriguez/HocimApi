using Amazon.SQS.Model;
using Amazon;
using Amazon.SQS;
using Holcim.TaskSend.Application.External.Smtp;
using Holcim.TaskSend.Domian.Models.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Holcim.TaskSend.Application.DataBase.Email.Commands.SendEmail
{
    public class SendEmailCommandHandler : BackgroundService
    {

        private readonly ISmtpCommandHandler _smtpCommandHandler;
        private readonly IConfiguration _configuration;

        public SendEmailCommandHandler(ISmtpCommandHandler smtpCommandHandler, IConfiguration configuration)
        {
            _smtpCommandHandler = smtpCommandHandler;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            IAmazonSQS sqsClient = new AmazonSQSClient(RegionEndpoint.USEast1);

            try
            {

                Console.WriteLine("Tarea en segundo plano email iniciada.");

                while (!stoppingToken.IsCancellationRequested)
                {

                    // Tu lógica aquí
                    Console.WriteLine($"Tarea ejecutada a las email {DateTime.Now}");



                    // Definir la URL de la cola SQS
                    string queueUrl = _configuration["quueurlAws"];

                    var receiveMessageRequest = new ReceiveMessageRequest
                    {
                        QueueUrl = queueUrl,
                        MaxNumberOfMessages = 4,  // Número máximo de mensajes a recibir
                        WaitTimeSeconds = 5      // Tiempo de espera para polling largo
                    };


                    // Recibir mensajes
                    var receiveMessageResponse = await sqsClient.ReceiveMessageAsync(receiveMessageRequest);

                    if (receiveMessageResponse.Messages.Count > 0)
                    {

                        foreach (var correo in receiveMessageResponse.Messages) 
                        {
                            Console.WriteLine($"Mensaje recibido: {correo.Body}");

                            // Deserializar el JSON a un objeto de tipo Persona
                            var emailRecibido = JsonConvert.DeserializeObject<CreateEmailRequest>(correo.Body);

                            await _smtpCommandHandler.Execute(emailRecibido);

                            // Eliminar el mensaje de la cola
                            var deleteMessageRequest = new DeleteMessageRequest
                            {
                                QueueUrl = queueUrl,
                                ReceiptHandle = correo.ReceiptHandle
                            };
                            await sqsClient.DeleteMessageAsync(deleteMessageRequest);

                        }

                    }
                    else
                    {
                        Console.WriteLine("No se encontraron mensajes.");

                    }

                    // Espera de 2 minutos entre ejecuciones
                    await Task.Delay(TimeSpan.FromSeconds(60), stoppingToken);
                    Console.WriteLine("Tarea en segundo plano detenida.");

                }
            }
            catch (System.Exception ex)
            {

                Console.WriteLine("Error Tarea en segundo plano" + ex.Message.ToString());
            }



        }

    }
}
