namespace Holcim.Application.DataBase.Archivo.Commands.List
{
    public interface IListArchivosByTypeArchivoCommand
    {
        Task<object> Execute(Guid TipoRfx);
    }
}
