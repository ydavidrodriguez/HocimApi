using Microsoft.AspNetCore.Mvc;

namespace Holcim.Application.DataBase.Rfx.Commands.List
{
    public interface IListRfxCommandHandler
    {
        Task<object> Execute(string? Nombre, Guid? EstadoId, bool? Gestion);

    }
}
