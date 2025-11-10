using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using AutoMapper;
using Holcim.TaskSend.Application.Feature;
using Holcim.TaskSend.Domian.Models.Email;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.TaskSend.Application.DataBase.Email.Commands.Create
{
    public class CreateEmailCommandHandler : ICreateEmailCommandHandler
    {

       
        private readonly IMapper _mapper;

        public CreateEmailCommandHandler( IMapper mapper)
        {
        
            _mapper = mapper;

        }

        public async Task<object> Execute(CreateEmailRequest createEmailRequest)
        {

            var sqsClient = new AmazonSQSClient("AKIA2NK3YLNBDFSFPA63", "g78CfJ8AhNtiSfKn72Wa+47CWs/CLJGZgT2SSFPv", RegionEndpoint.EUWest1); // Specify your region

            // Define the SQS queue URL
            string queueUrl =  _configuration["awsurl"];
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
