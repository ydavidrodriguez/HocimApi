using Holcim.Domain.Models.Pais;

namespace Holcim.Application.DataBase.Pais.Commands.Update
{
    public interface IUpdatePaisCommandHandler
    {
        Task<object> Execute(UpdatePaisRequest updatePaisRequest);
    }
}
