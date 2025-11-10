namespace Holcim.Application.DataBase.Usuario.Commands.Create
{
    public interface ICreateUsuarioGenericoCommandHandler
    {
        Task<object> Execute(Domain.Entities.Usuario.Usuario usuario,
            List<Guid>? ListRolid, Guid TipoUsuario);
    }
}
