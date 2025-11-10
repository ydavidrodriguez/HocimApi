using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using AutoMapper;
using Holcim.DocumetsService.Application.Feature;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Holcim.DocumetsService.Application.DataBase.Documentos.Commands.Create
{
    public class CreateDocumentCommandHandler : ICreateDocumentCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;


        public CreateDocumentCommandHandler(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _config = configuration;

        }
        public async Task<object> Execute(IFormFile formFile)
        {

            string bucketName = _config["bucketName"]; // Nombre del bucket
            RegionEndpoint bucketRegion = RegionEndpoint.EUWest1; // Región del bucket
            //IAmazonS3 s3Client;

            //s3Client = new AmazonS3Client(_config["Key"], _config["Secret"], bucketRegion);
            using (var s3Client = new AmazonS3Client(_config["Key"], _config["Secret"], bucketRegion))
            {

                using (var stream = formFile.OpenReadStream())
                {
                    var fileTransferUtility = new TransferUtility(s3Client);

                    var putRequest = new TransferUtilityUploadRequest
                    {
                        BucketName = bucketName,
                        Key = formFile.FileName,
                        ContentType = formFile.ContentType,
                        InputStream = stream
                    };

                    await fileTransferUtility.UploadAsync(putRequest);

                    //PutObjectResponse response = await s3Client.PutObjectAsync(putRequest);
                    Console.WriteLine("Archivo subido con éxito.");

                }
            }

            return ResponseApiService.Response(StatusCodes.Status201Created, "Archivo subido con éxito.");

        }


    }
}
