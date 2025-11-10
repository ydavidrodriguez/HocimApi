using Holcim.Domain.Models.Informes;
using System.Threading.Tasks;

namespace Holcim.Application.DataBase.Informe.Commands.Create
{
    public interface ICreateInformesCommandHandler
    {
        Task<object> Execute(CreateInformesRequest createInformesRequest);
    }
}

