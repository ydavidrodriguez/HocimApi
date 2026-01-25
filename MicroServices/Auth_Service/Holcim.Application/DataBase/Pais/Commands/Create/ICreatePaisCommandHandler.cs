using Holcim.Domain.Models.Pais;

namespace Holcim.Application.DataBase.Pais.Commands.Create
{
    public interface ICreatePaisCommandHandler
    {
        Task<object> Execute(List<CreatePaisRequest> createPaisRequest);
    }
}
