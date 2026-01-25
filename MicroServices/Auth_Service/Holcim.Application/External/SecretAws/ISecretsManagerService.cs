public interface ISecretsManagerService
{
   Task<string> GetSecretAsync(string secretName);
}