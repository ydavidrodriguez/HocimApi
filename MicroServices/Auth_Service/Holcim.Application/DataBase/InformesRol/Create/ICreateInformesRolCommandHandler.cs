using Holcim.Domain.Models.Informes;

namespace Holcim.Application.DataBase.InformesRol.Create
{
    public interface ICreateInformesRolCommandHandler
    {
        Task<object> Execute(List<CreateInformesRolRequest> createInformesRequest);
    }
}
