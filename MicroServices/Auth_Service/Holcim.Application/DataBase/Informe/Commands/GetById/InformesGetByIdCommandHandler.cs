using AutoMapper;
using Holcim.Application.Feature;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Informe.Commands.GetById
{ 
    public class InformesGetByIdCommandHandler : IInformesGetByIdCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public InformesGetByIdCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(Guid IdInformes)
        {
            var dataservice = _dataBaseService.Informes.Where(x => x.IdInformes == IdInformes);
            return ResponseApiService.Response(StatusCodes.Status201Created, dataservice);

        }

    }
}
