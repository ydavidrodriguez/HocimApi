using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

public class SecretsManagerService : ISecretsManagerService
{
    private readonly IAmazonSecretsManager _client;

    public SecretsManagerService()
    {
        _client = new AmazonSecretsManagerClient(
            RegionEndpoint.GetBySystemName("eu-west-1")
        );
    }

    public async Task<string> GetSecretAsync(string secretName)
    {
        try
        {
            var response = await _client.GetSecretValueAsync(
                new GetSecretValueRequest
                {
                    SecretId = secretName,
                    VersionStage = "AWSCURRENT"
                });

            return response.SecretString;
        }
        catch (Exception e)
        {
            return e.ToString();
        }
        
    }
}
