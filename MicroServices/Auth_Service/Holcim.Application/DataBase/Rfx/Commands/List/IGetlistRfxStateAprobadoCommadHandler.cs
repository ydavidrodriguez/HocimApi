namespace Holcim.Application.DataBase.Rfx.Commands.List
{
    public interface IGetlistRfxStateAprobadoCommadHandler
    {
       public Task<object> Execute(Guid IdUsuario);
    }
}
