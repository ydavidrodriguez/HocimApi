using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holcim.Application.DataBase.Correo.Commands.Create
{
    public interface ICreateCorreoRfxCommandHandler
    {
        Task<object> Execute(List<string> usuariosRemitentes, string Asunto, string DescripcionCorreo,
             Dictionary<string, Dictionary<string, string>> parametrosPorUsuario);
    }
}
