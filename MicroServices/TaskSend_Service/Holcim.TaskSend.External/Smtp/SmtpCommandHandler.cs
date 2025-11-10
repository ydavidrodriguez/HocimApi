using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Holcim.TaskSend.Application.External.Smtp;
using Holcim.TaskSend.Application.Feature;
using Holcim.TaskSend.Domian.Models.Email;
using Microsoft.AspNetCore.Http;

namespace Holcim.TaskSend.External.Smtp
{
    public class SmtpCommandHandler : ISmtpCommandHandler
    {


        public async Task<object> Execute(CreateEmailRequest createEmailRequest)
        {

            try
            {

                // Configuración de SES
              
                // Parámetros del correo
                // foreach (var email in createEmailRequest.Destinatarios)
                // {
                //     var sendRequest = new SendEmailRequest
                //     {
                //         Source = "camoreno@nexos-software.com.co", // Dirección de correo verificada
                //         Destination = new Destination
                //         {
                //             ToAddresses = new List<string> { email }
                //         },
                //         Message = new Message
                //         {
                //             Subject = new Content(createEmailRequest.Asunto),
                //             Body = new Body
                //             {
                //                 Html = new Content(createEmailRequest.Body)
                //             }
                //         }
                //     };
                //     var response = await sesClient.SendEmailAsync(sendRequest);
                //     Console.WriteLine("Correo enviado con éxito. ID: " + response.MessageId);
                // }

                return ResponseApiService.Response(StatusCodes.Status201Created, createEmailRequest);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Correo no enviado con éxito. ID: " + ex.Message.ToString());
                return ResponseApiService.Response(StatusCodes.Status203NonAuthoritative, null, "Correo , no enviado con éxito. ID: " + ex.Message.ToString());
            }



        }

    }
}
