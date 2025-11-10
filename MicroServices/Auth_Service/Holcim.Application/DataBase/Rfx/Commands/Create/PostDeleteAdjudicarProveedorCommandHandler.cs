using Holcim.Application.DataBase.TrazabilidadRfx.Commands.Create;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.Enums;
using Holcim.Domain.Models.Proveedor;
using Holcim.Domain.Models.Rfx;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Holcim.Application.DataBase.Rfx.Commands.Create
{
    public class PostDeleteAdjudicarProveedorCommandHandler : IPostDeleteAdjudicarProveedorCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly ICreateTrazabilidadCommandHandler _createTrazabilidadCommandHandler;


        public PostDeleteAdjudicarProveedorCommandHandler(IDataBaseService dataBaseService,
            ICreateTrazabilidadCommandHandler createTrazabilidadCommandHandler)
        {
            _dataBaseService = dataBaseService;
            _createTrazabilidadCommandHandler = createTrazabilidadCommandHandler;
        }

        public async Task<object> Execute(PostDeleteProveedorAdjudicar postDeleteProveedorAdjudicar)
        {

            if (postDeleteProveedorAdjudicar != null)
            {

                var adjudiaciondelete = _dataBaseService.AdjudicacionProveedor.
                    Where(x => x.IdAdjudicacionProveedor == postDeleteProveedorAdjudicar.IdAdjudiacion)
                    .FirstOrDefaultAsync();

                if (adjudiaciondelete.Result != null)
                {
                    _dataBaseService.AdjudicacionProveedor.Remove(adjudiaciondelete.Result);
                }

                await _dataBaseService.SaveAsync();

                var Estado = _dataBaseService.Estado.Include(x => x.TipoEstado).
                    Where(x => x.Nombre == EnumDomain.Adjudicado.GetEnumMemberValue().ToString()
                    && x.TipoEstado.Descripcion == EnumDomain.rfx.GetEnumMemberValue().ToString()).FirstOrDefaultAsync();


                CreateRfxRequest createRfxRequest = new CreateRfxRequest();
                createRfxRequest.EstadoId = Estado.Result.IdEstado;
                createRfxRequest.UsuarioCreacion = postDeleteProveedorAdjudicar.usuarioId;
                await _createTrazabilidadCommandHandler.Execute(createRfxRequest, adjudiaciondelete.Result.RfxId);
                await _dataBaseService.SaveAsync();

                return ResponseApiService.Response(StatusCodes.Status201Created, postDeleteProveedorAdjudicar);
            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status201Created, "Cambiar Producto");
            }

        }

    }
}
