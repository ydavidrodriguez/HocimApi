using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.Enums;
using Holcim.Domain.Entities.ProveedorRfx;
using Holcim.Domain.Entities.Rfx;
using Holcim.Domain.Models.Idioma;
using Holcim.Domain.Models.Rfx;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.Application.DataBase.Invitados.Commands.Create
{
    public class CreateInvitadosCommandHandler : ICreateInvitadosCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateInvitadosCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(CreateRfxRequest request, Guid rfxId, Guid EstadoId)
        {

            if (request.ProveedoresInvitados != null)
            {

                foreach (var email in request.ProveedoresInvitados)
                {
                    var proveedor = _dataBaseService.Proveedor.FirstOrDefault(x => x.Correo == email);

                    if (proveedor != null)
                    {
                        _dataBaseService.ProveedorRfx.Add(new ProveedorRfx
                        {
                            IdProveedorRfx = Guid.NewGuid(),
                            ProveedorId = proveedor.IdProveedor,
                            RfxId = rfxId,
                            EstadoId = EstadoId
                        });

                    }
                    else
                    {

                        Domain.Entities.Proveedor.Proveedor proveedorCreate = new Domain.Entities.Proveedor.Proveedor();
                        proveedorCreate.IdProveedor = Guid.NewGuid();
                        proveedorCreate.Correo = email;
                        proveedorCreate.Estado = true;
                        proveedorCreate.FechaActulizacion = DateTime.Now;
                        proveedorCreate.FechaCreacion = DateTime.Now;
                        proveedorCreate.NombreEmpresa = EnumDomain.EmpresaGenerica.GetEnumMemberValue().ToString();
                        proveedorCreate.IdiomaId = null;
                        proveedorCreate.PaisId = _dataBaseService.Pais.Where(x => x.Nombre ==
                        EnumDomain.PaisGenerico.GetEnumMemberValue().ToString()).First().IdPais;
                        proveedorCreate.RegistroMercantil = "0";
                        proveedorCreate.Telefono = "0";
                        proveedorCreate.UsuarioId = null;
                        proveedorCreate.ZonaHorariaId = _dataBaseService.ZonaHoraria.Where(x => x.Nombre ==
                        EnumDomain.ZonaHorariaGenerico.GetEnumMemberValue().ToString()).First().IdZonaHoraria;

                        _dataBaseService.Proveedor.Add(proveedorCreate);

                        _dataBaseService.ProveedorRfx.Add(new ProveedorRfx
                        {

                            IdProveedorRfx = Guid.NewGuid(),
                            ProveedorId = proveedorCreate.IdProveedor,
                            RfxId = rfxId,
                            EstadoId = EstadoId

                        }
                        );
                    }

                }

                InvitacionProveedorRfx invitacionProveedorRfx = new InvitacionProveedorRfx();

                invitacionProveedorRfx.IdInvitacionProveedorRfx = Guid.NewGuid();
                invitacionProveedorRfx.RfxId = rfxId;
                invitacionProveedorRfx.Correo = JsonConvert.SerializeObject(request.ProveedoresInvitados);

                _dataBaseService.InvitacionProveedorRfx.Add(invitacionProveedorRfx);
                await _dataBaseService.SaveAsync();
                return ResponseApiService.Response(StatusCodes.Status201Created, "Invitados creados Correctamente");

            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status201Created, "Invitados creados Correctamente");
            }
        }
    }
}
