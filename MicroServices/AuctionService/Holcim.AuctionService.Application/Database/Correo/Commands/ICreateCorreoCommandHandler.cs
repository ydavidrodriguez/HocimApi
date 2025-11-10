using  Holcim.AuctionService.Domain.Models.Correo;

namespace Holcim.Application.DataBase.Correo.Commands
{
    public interface ICreateCorreoCommandHandler
    {
        Task<object> Execute(List<string> usuariosRemitentes, string Asunto, string DescripcionCorreo,
             Dictionary<string, Dictionary<string, string>> parametrosPorUsuario);
    }
}
