using Holcim.FileSend.Application.Feature;
using Holcim.FileSend.Domain.Models;
using Microsoft.AspNetCore.Http;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Holcim.FileSend.Application.DataBase.FileRfx.Commands.Create
{
    public class CreateFileRfxCommandHandler : ICreateFileRfxCommandHandler
    {

        public CreateFileRfxCommandHandler()
        {

        }
        public async Task<object> Execute(List<IFormFile> Files)
        {

            List<PostCargueItemsRfxResponse> postCargueItemsRfxResponses = new List<PostCargueItemsRfxResponse>();
            Stream stream = Files[0].OpenReadStream();
            IWorkbook MiExcel = null;

            if (Path.GetExtension(Files[0].FileName) == ".xlsx")
            {
                MiExcel = new XSSFWorkbook(stream);
            }
            else
            {
                MiExcel = new HSSFWorkbook(stream);
            }

            ISheet HojaExcel = MiExcel.GetSheetAt(0);
            int cantidadFilas = HojaExcel.LastRowNum;

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                if (fila != null)
                {
                    if (fila.RowNum > 0)
                    {
                        if (fila.Cells.Where(x => x.StringCellValue != null).FirstOrDefault() != null)
                        {
                            PostCargueItemsRfxResponse postCargueItemsRfxResponse = new PostCargueItemsRfxResponse
                            {

                                 item = fila.GetCell(0).ToString(),
                                 PscsId = Guid.Parse(fila.GetCell(1).ToString()),
                                 UnidadMediadId = Guid.Parse(fila.GetCell(2).ToString()),
                                 Cantidad = int.Parse(fila.GetCell(3).ToString()),
                                 ValorUnd = int.Parse(fila.GetCell(4).ToString())

                            };

                            postCargueItemsRfxResponses.Add(postCargueItemsRfxResponse);

                        }
                    }
                }
            }
            return ResponseApiService.Response(StatusCodes.Status201Created, new object());

        }

    }
}
