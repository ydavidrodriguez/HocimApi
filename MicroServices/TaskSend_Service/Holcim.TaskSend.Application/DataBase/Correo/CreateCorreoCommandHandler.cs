using Amazon.SQS.Model;
using Amazon.SQS;
using AutoMapper;
using Holcim.TaskSend.Application.Feature;
using Holcim.TaskSend.Domian.Models.Email;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Amazon;

namespace Holcim.TaskSend.Application.DataBase.Correo
{
    public class CreateCorreoCommandHandler: ICreateCorreoCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CreateCorreoCommandHandler( IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<object> Execute(CreateEmailRequest createEmailRequest)
        {

            var sqsClient = new AmazonSQSClient("AKIA2NK3YLNBDFSFPA63", "g78CfJ8AhNtiSfKn72Wa+47CWs/CLJGZgT2SSFPv", RegionEndpoint.EUWest1); // Specify your region

            // Define the SQS queue URL
            string queueUrl = _configuration["awsurl"];
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

    }
}
