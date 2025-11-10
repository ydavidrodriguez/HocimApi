using Amazon.S3.Model;
using Amazon.S3;
using AutoMapper;
using Holcim.DocumetsService.Application.Feature;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Amazon;

namespace Holcim.DocumetsService.Application.DataBase.Documentos.Commands.List
{
    public class ConsultDocumentCommandHandler : IConsultDocumentCommandHandler
    {
        
        private readonly IConfiguration _config;


        public ConsultDocumentCommandHandler(IConfiguration configuration)
        {
            _config = configuration;

        }
        public async Task<object> Execute(string path)
        {

            string bucketName = _config["bucketName"]; // Nombre del bucket
            string keyName = path;// Nombre del archivo en el bucket
            RegionEndpoint bucketRegion = RegionEndpoint.EUWest1; // Región del bucket
            IAmazonS3 s3Client;

            s3Client = new AmazonS3Client(_config["Key"], _config["Secret"], bucketRegion);

            var getRequest = new GetObjectRequest
            {
                BucketName = bucketName,
                Key = keyName
            };

            using (GetObjectResponse response = await s3Client.GetObjectAsync(getRequest))
            using (MemoryStream memoryStream = new MemoryStream())
            {
                await response.ResponseStream.CopyToAsync(memoryStream);

                byte[] fileBytes = memoryStream.ToArray();

                return ResponseApiService.Response(StatusCodes.Status201Created, Convert.ToBase64String(fileBytes));

            }

        }
    }
}
