using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Holcim.DocumetsService.Application.Feature;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Holcim.DocumetsService.Application.Helpers
{
    public class PostEnviarDocuments : IPostEnviarDocuments
    {
        private readonly IConfiguration _config;

        public PostEnviarDocuments(IConfiguration configuration)
        {
            _config = configuration;

        }
        public async Task<object> PostExecuteDocuments(IFormFile formFile, string? Path)
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
                        Key = Path,
                        ContentType = formFile.ContentType,
                        InputStream = stream
                    };

                    await fileTransferUtility.UploadAsync(putRequest);

                    Console.WriteLine("Archivo subido con éxito.");

                }
            }

            return ResponseApiService.Response(StatusCodes.Status201Created, "Archivo subido con éxito.");

        }


    }
}
