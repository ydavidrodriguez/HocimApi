namespace Holcim.Application.DataBase.Rfx.Commands.Delete
{
    public interface IDeleteRfxTemplateCommandHandler
    {
        Task<object> Execute(Guid idRfxTemporal);
    }
}
