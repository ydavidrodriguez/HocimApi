namespace Holcim.Application.DataBase.Correo.Commands.Create
{
    public interface ICreateCorreoCommandHandler
    {
        Task<object> Execute(List<string> usuariosRemitentes, string Asunto, string DescripcionCorreo,
           Dictionary<string, string> parameterescorreo);
    }
}
