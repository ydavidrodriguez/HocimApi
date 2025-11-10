using Holcim.Provider.Domain.Models.Proveedor;

namespace Holcim.Provider.Application.Database.Proveedor.Commands.Create
{
    public interface ICreateProviderBulkCommandHandler
    {
        object Execute(List<CreateUserBulkRequest> createUserBulkRequest);
    }
}
