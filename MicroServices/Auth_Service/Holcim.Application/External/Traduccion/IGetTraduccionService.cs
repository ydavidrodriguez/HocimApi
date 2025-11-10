namespace Holcim.Application.External.Traduccion
{
    public interface IGetTraduccionService
    {
        Task<string> Execute(string tesxto);
        string GetTranslatedName(string jsonNombre, string key);
    }
}
