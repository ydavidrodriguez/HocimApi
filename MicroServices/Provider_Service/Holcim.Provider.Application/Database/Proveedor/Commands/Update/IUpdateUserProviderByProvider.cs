using Holcim.Provider.Domain.Models.Usuario;

namespace Holcim.Provider.Application.Database.Proveedor.Commands.Update
{
    public interface IUpdateUserProviderByProvider
    {
        Task<object> Execute(PutUsuarioUpdateRequest putUsuarioUpdateRequest);
    }
}
