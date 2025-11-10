using AutoMapper;
using Dapper;
using Holcim.Application.DataBase.Correo.Commands.Create;
using Holcim.Application.DataBase.Proveedor.Commands.Update;
using Holcim.Application.DataBase.Usuario.Commands.Create;
using Holcim.Application.External.Dapper;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.Enums;
using Holcim.Domain.Entities.Enums.SPEnums;
using Holcim.Domain.Models;
using Holcim.Domain.Models.Proveedor;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Proveedor.Commands.Create
{
    public class CreateProveedorCommandHandler : ICreateProveedorCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        private readonly ICreateCorreoCommandHandler _createCorreoCommandHandler;
        private readonly IDapperProcedure _dapperProcedure;
        private readonly ICreateUsuarioGenericoCommandHandler _createUsuarioGenericoCommandHandler;
        private readonly IUpdateProveedorCommandHandler _updateProveedorCommandHandler;

        public CreateProveedorCommandHandler(IDataBaseService dataBaseService, IMapper mapper,
            ICreateCorreoCommandHandler createCorreoCommandHandler, IDapperProcedure dapperProcedure,
            ICreateUsuarioGenericoCommandHandler createUsuarioGenericoCommandHandler,
            IUpdateProveedorCommandHandler updateProveedorCommandHandler)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
            _mapper = mapper;
            _createCorreoCommandHandler = createCorreoCommandHandler;
            _dapperProcedure = dapperProcedure;
            _createUsuarioGenericoCommandHandler = createUsuarioGenericoCommandHandler;
            _updateProveedorCommandHandler = updateProveedorCommandHandler;
        }

        public async Task<object> Execute(CreatProveedorRequest creatProveedorRequest)
        {

            if (_dataBaseService.Proveedor.Where(x => x.NombreEmpresa == creatProveedorRequest.NombreEmpresa || x.RegistroMercantil == creatProveedorRequest.RegistroMercantil).FirstOrDefault() == null)
            {
                //Creacion de Usuario Para el Proveedor
                Domain.Entities.Rol.Rol rolentity = _dataBaseService.Rol.Where(x => x.Nombre.Trim() == EnumDomain.RolProveedor.GetEnumMemberValue().ToString().Trim()).First();
                if (rolentity != null)
                {
                    List<Guid> listRol = new List<Guid>();
                    listRol.Add(rolentity.IdRol);

                    //Creacion del usuario 
                    Domain.Entities.Usuario.Usuario usuario = new Domain.Entities.Usuario.Usuario();

                    usuario.Nombre = creatProveedorRequest.Nombre;
                    usuario.Correo = creatProveedorRequest.Correo;
                    usuario.Apellido = creatProveedorRequest.Apellido;
                    usuario.PrimerIngreso = true;
                    usuario.IdiomaId = creatProveedorRequest.IdiomaId.Value;

                    BaseResponseModel userresponse = (BaseResponseModel)await _createUsuarioGenericoCommandHandler.Execute(usuario, listRol, _dataBaseService.TipoUsuario.Where(x => x.Nombre == EnumDomain.TipoUsuarioProveedor.GetEnumMemberValue().ToString().Trim()).First().IdTipoUsuario);
                    var Entitymapper = _mapper.Map<Domain.Entities.Proveedor.Proveedor>(creatProveedorRequest);
                    //Creacion del Proveedor
                    Domain.Entities.Proveedor.Proveedor proveedor = _dataBaseService.Proveedor.Where(x => x.Correo == creatProveedorRequest.Correo).FirstOrDefault();
                    if (proveedor != null)
                    {
                        UpdateProveedorRequest updateProveedorRequest = _mapper.Map<UpdateProveedorRequest>(proveedor);
                        await _updateProveedorCommandHandler.Execute(updateProveedorRequest, false);
                    }
                    else
                    {
                        Entitymapper.IdProveedor = Guid.NewGuid();
                        Entitymapper.Estado = true;
                        Entitymapper.FechaCreacion = DateTime.Now;
                        Entitymapper.FechaActulizacion = DateTime.Now;
                        Entitymapper.UsuarioId = usuario.IdUsuario;
                        Entitymapper.Correo = creatProveedorRequest.Correo;
                        Entitymapper.ZonaHorariaId = creatProveedorRequest.ZonaHorariaId;
                        _dataBaseService.Proveedor.Add(Entitymapper);
                    }

                    // Prepare the replacement values
                    var replacements = new Dictionary<string, string>
                    {
                        { "{0}", creatProveedorRequest.Nombre },
                        { "{1}",  creatProveedorRequest.Correo },
                        { "{2}", userresponse.Data.Contrasena}
                    };

                    await _createCorreoCommandHandler.Execute(new List<string> { creatProveedorRequest.Correo },
                        "Creacion Proveedor Holcim",
                         EnumDomain.CreacionProveedorHolcim.GetEnumMemberValue().ToString(), replacements);

                    await _dataBaseService.SaveAsync();

                    var parametersUsuarioProveedor = new DynamicParameters();
                    parametersUsuarioProveedor.Add("@IdUsuario", usuario.IdUsuario);
                    parametersUsuarioProveedor.Add("@IdProveedor", Entitymapper.IdProveedor);

                    _dapperProcedure.UpdateQuery(parametersUsuarioProveedor, EnumSp.SPPOSTPROVEEDORUSUARIO.GetEnumMemberValue().ToString());


                }

                return ResponseApiService.Response(StatusCodes.Status201Created, creatProveedorRequest);

            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Proveedor Ya Existe");

            }


        }

    }
}
