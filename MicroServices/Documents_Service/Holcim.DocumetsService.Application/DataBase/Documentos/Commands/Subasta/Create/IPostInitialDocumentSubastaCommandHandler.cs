using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holcim.DocumetsService.Application.DataBase.Documentos.Commands.Subasta.Create
{
    public interface IPostInitialDocumentSubastaCommandHandler
    {
        Task<object> Execute(IFormFile formFile, string jsondata);
    }
}
