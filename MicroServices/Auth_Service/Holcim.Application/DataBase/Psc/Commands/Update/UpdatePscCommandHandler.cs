using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.Pscs;
using Holcim.Domain.Models.Psc;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Psc.Commands.Update
{
    public class UpdatePscCommandHandler : IUpdatePscCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdatePscCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(UpdatePscRequest UpdatePscRequest)
        {
            var Entity = _dataBaseService.Pscs.Where(x => x.IdPscs == UpdatePscRequest.IdPscs).FirstOrDefault();
            if (Entity != null) 
            {
                var pscs = _dataBaseService.Pscs.Where(x => x.PscsId == UpdatePscRequest.PscsId && x.IdPscs != UpdatePscRequest.IdPscs).FirstOrDefault();
                if (pscs == null) 
                {
                     Entity.PscsId = UpdatePscRequest.PscsId;
                     Entity.PscsNombre = UpdatePscRequest.PscsNombre;
                     Entity.CategoriaPscId = UpdatePscRequest.CategoriaPscId;
                     Entity.GrupoPscId = UpdatePscRequest.GrupoPscId;
                     Entity.Estado = UpdatePscRequest.Estado;
                     Entity.FechaActulizacion = DateTime.Now;
                     _dataBaseService.Pscs.Update(Entity);
                     await _dataBaseService.SaveAsync();

                    return ResponseApiService.Response(StatusCodes.Status201Created, UpdatePscRequest);

                }
                else 
                {
                    return ResponseApiService.Response(StatusCodes.Status202Accepted, null,"Pscs Ya Existe");
                }
               
            }
            else 
            {
                return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Pscs Ya Existe");
            }
            
        }
    }
}
