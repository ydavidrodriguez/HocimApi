using Holcim.Application.DataBase.TrazabilidadRfx.Commands.Create;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.Enums;
using Holcim.Domain.Entities.Proveedor;
using Holcim.Domain.Models.Proveedor;
using Holcim.Domain.Models.Rfx;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Holcim.Application.DataBase.Rfx.Commands.Create
{
    public class PostCreateAdjudicarRfxCommandHandler : IPostCreateAdjudicarRfxCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly ICreateTrazabilidadCommandHandler _createTrazabilidadCommandHandler;


        public PostCreateAdjudicarRfxCommandHandler(IDataBaseService dataBaseService,
            ICreateTrazabilidadCommandHandler createTrazabilidadCommandHandler)
        {
            _dataBaseService = dataBaseService;
            _createTrazabilidadCommandHandler = createTrazabilidadCommandHandler;
        }

        public async Task<object> Execute(List<PostCreateProveedorAdjudicar> ListPostCreateProveedorAdjudicar)
        {

            if (ListPostCreateProveedorAdjudicar != null && ListPostCreateProveedorAdjudicar.Count > 0)
            {

                foreach (var Proveedoradjudicado in ListPostCreateProveedorAdjudicar)
                {

                    AdjudicacionProveedor adjudicacionProveedor = new AdjudicacionProveedor();

                    adjudicacionProveedor.IdAdjudicacionProveedor = Guid.NewGuid();
                    adjudicacionProveedor.ProveedorId = Proveedoradjudicado.ProveedorId;
                    adjudicacionProveedor.ItemId = Proveedoradjudicado.ItemId;
                    adjudicacionProveedor.ProveedorId = Proveedoradjudicado.ProveedorId;
                    adjudicacionProveedor.RfxId = Proveedoradjudicado.RfxId;
                    adjudicacionProveedor.FechaAdjudicacion = DateTime.Now;
                    adjudicacionProveedor.Estado = true;

                    _dataBaseService.AdjudicacionProveedor.Add(adjudicacionProveedor);

                }

                var Estado = _dataBaseService.Estado.Include(x => x.TipoEstado).
                    Where(x => x.Nombre == EnumDomain.Adjudicado.GetEnumMemberValue().ToString()
                    && x.TipoEstado.Descripcion == EnumDomain.rfx.GetEnumMemberValue().ToString()).FirstOrDefaultAsync();


                CreateRfxRequest createRfxRequest = new CreateRfxRequest();
                createRfxRequest.EstadoId = Estado.Result.IdEstado;
                createRfxRequest.UsuarioCreacion = ListPostCreateProveedorAdjudicar[0].UsuarioId;
                await _createTrazabilidadCommandHandler.Execute(createRfxRequest, ListPostCreateProveedorAdjudicar[0].RfxId);
                await _dataBaseService.SaveAsync();

                return ResponseApiService.Response(StatusCodes.Status201Created, ListPostCreateProveedorAdjudicar);
            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status201Created, "Cambiar Producto");
            }

        }

    }
}
