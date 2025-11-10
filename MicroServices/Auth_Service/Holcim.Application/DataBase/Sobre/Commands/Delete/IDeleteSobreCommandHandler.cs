using Holcim.Domain.Entities.Archivos;

namespace Holcim.Application.DataBase.Sobre.Commands.Delete
{
    public interface IDeleteSobreCommandHandler
    {
        Task<object> Execute(List<ArchivoSobre> ArchivoSobre);
    }
}
