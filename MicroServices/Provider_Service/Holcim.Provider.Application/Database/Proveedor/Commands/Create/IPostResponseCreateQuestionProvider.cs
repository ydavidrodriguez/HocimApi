using Holcim.Provider.Domain.Entities;
using Holcim.Provider.Domain.Models;

namespace Holcim.Provider.Application.Database.Proveedor.Commands.Create
{
    public interface IPostResponseCreateQuestionProvider
    {
        Task<object> Execute(List<RespuestaPreguntaRequest> respuestaPregunta);
    }
}
