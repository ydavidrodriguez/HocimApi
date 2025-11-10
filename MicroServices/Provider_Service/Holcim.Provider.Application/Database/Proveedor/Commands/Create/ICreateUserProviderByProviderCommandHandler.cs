using Holcim.Provider.Domain.Models;

namespace Holcim.Provider.Application.Database.Proveedor.Commands.Create
{
    public interface ICreateUserProviderByProviderCommandHandler
    {
        object Execute(CreateUserProviderRequest createUserProviderRequest);
    }
}
