using AutoMapper;
using Holcim.Application.Feature;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Item.Commands.List
{
    public class ListItemCommandHandler : IListItemCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
        public ListItemCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<object> Execute(Guid IdItem)
        {
            return ResponseApiService.Response(StatusCodes.Status201Created, 
                _dataBaseService.Item.Where(x => x.IdItem == IdItem).FirstOrDefault());
        }


    }
}
