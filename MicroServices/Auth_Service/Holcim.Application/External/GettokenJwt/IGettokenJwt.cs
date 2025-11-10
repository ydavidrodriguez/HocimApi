using Holcim.Domain.Models.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.Application.External.GettokenJwt
{
    public interface IGettokenJwt
    {
        object Execute(LoginUsuarioRequest loginUsuarioRequest);

    }
}
