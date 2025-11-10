using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.Rfx;
using Holcim.Domain.Models.Rfx;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.Application.DataBase.Rfx.Commands.PostreassignRfxUser
{
    public class PostreassignRfxUserCommandHandler : IPostreassignRfxUserCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public PostreassignRfxUserCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;

        }

        public async Task<object> Execute(PostreassignRfxUserRequest postreassignRfxUserRequest)
        {

            Domain.Entities.Rfx.Rfx rfx = _dataBaseService.Rfx.Where(x => x.IdRfx == postreassignRfxUserRequest.RfxId).First();

            if (rfx != null)
            {
                UsuarioReasignacion usuarioReasignacion = new UsuarioReasignacion();

                usuarioReasignacion.RfxId = rfx.IdRfx;
                usuarioReasignacion.UsuarioOld = rfx.UsuarioCreacion;
                usuarioReasignacion.Estado = true;
                usuarioReasignacion.IdUsuarioReasignacion = Guid.NewGuid();
                usuarioReasignacion.FechaFinal = postreassignRfxUserRequest.FechaFinal;
                usuarioReasignacion.MotivoId = postreassignRfxUserRequest.Motivo;
                usuarioReasignacion.FechaInicio = postreassignRfxUserRequest.FechaInicio;
                usuarioReasignacion.Usuarios = JsonConvert.SerializeObject(postreassignRfxUserRequest.UsuarioId);

                _dataBaseService.UsuarioReasignacion.Add(usuarioReasignacion);


                foreach (var usuarioencargado in postreassignRfxUserRequest.UsuarioId)
                {
                    UsuarioEncargadoRfx usuarioEncargadoRfx = new UsuarioEncargadoRfx();

                    usuarioEncargadoRfx.IdUsuarioEncargadoRfx = Guid.NewGuid();
                    usuarioEncargadoRfx.UsuarioId = usuarioencargado;
                    usuarioEncargadoRfx.RfxId = postreassignRfxUserRequest.RfxId;
                    usuarioEncargadoRfx.Estado = true;

                    _dataBaseService.UsuarioEncargadoRfx.Add(usuarioEncargadoRfx);
                }

                await _dataBaseService.SaveAsync();

                return ResponseApiService.Response(StatusCodes.Status201Created, postreassignRfxUserRequest);

            }

            return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Rfx No Encontrado");

        }


    }
}
