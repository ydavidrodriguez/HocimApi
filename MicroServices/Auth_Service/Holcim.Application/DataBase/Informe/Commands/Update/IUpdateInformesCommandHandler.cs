using Holcim.Domain.Models.Informes;

namespace Holcim.Application.DataBase.Informe.Commands.Update
{
    public interface IUpdateInformesCommandHandler
    {
        Task<object> Execute(UpdateInformesRequest updateInformesRequest);
    }
}
