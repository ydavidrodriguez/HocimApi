namespace Holcim.Application.DataBase.Usuario.Commands.List
{
    public interface IGetUsuarioToken
    {
        Task<Domain.Entities.Usuario.UsuarioToken> Execute(Guid idusuario);
    }
}
