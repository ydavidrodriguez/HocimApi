using Holcim.Domain.Entities.Archivos;
using Holcim.Domain.Models.Archivo;

namespace Holcim.Application.DataBase.Sobre.Commands.Update
{
    public interface IUpdateSobreCommandHandler
    {
        Task<object> Execute(ArchivoSobrePreguntas ArchivoSobre);
    }
}
