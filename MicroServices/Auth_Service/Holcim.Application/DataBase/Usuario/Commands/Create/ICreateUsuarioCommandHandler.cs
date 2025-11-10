using Holcim.Domain.Models.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.Application.DataBase.Usuario.Commands.Create
{
    public interface ICreateUsuarioCommandHandler
    {
         Task<object> Execute(CreateUsuarioRequest createUsuarioRequest);

    }
}
