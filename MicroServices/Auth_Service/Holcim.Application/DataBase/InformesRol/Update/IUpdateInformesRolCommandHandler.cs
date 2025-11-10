using Holcim.Domain.Models.Informes;

namespace Holcim.Application.DataBase.InformesRol.Update
{
    public interface IUpdateInformesRolCommandHandler
    {
        Task<object> Execute(UpdateInformesRolRequest updateInformesRolRequest);
    }
}
