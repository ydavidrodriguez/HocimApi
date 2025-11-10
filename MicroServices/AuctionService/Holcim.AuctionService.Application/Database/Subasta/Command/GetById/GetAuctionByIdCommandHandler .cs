using Holcim.AuctionService.Application.External;
using Holcim.AuctionService.Application.Feature;
using Holcim.AuctionService.Domain.Models.Items;
using Holcim.AuctionService.Domain.Models.Region;
using Holcim.AuctionService.Domain.Models.Subasta;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.AuctionService.Application.Database.Auction.Commands.GetById
{
    public class GetAuctionByIdCommandHandler : IGetAuctionByIdCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IDapperProcedure _dapperProcedure;

        public GetAuctionByIdCommandHandler(IDataBaseService dataBaseService,
            IDapperProcedure dapperProcedure)
        {
            _dataBaseService = dataBaseService;
            _dapperProcedure = dapperProcedure;
        }

        public async Task<object> Execute(Guid subastaId, Guid? usuarioId)
        {

            var parameters = new { SubastaId = subastaId };
            var Subastastring = _dapperProcedure.GetQuery(parameters, "GETLISTAUCTIONBYID");
            var Subasta = JsonConvert.DeserializeObject<List<GetSubastaById>>(Subastastring);

            //CONSULTAR REGIONES 
            var parametersregion = new { SUBASTAID = subastaId };
            var Regionstring = _dapperProcedure.GetQuery(parameters, "GETLISTGRUBYAUCTION");
            var Regiones = JsonConvert.DeserializeObject<List<GetPaisResponse>>(Regionstring);

            Subasta[0].GetPaisResponseList = Regiones;

            //CONSULTAR ITEMS
            var parametersItems = new { IdSubasta = subastaId };
            var Itemstring = _dapperProcedure.GetQuery(parametersItems, "GETITEMSBYAUTION");
            var Items = JsonConvert.DeserializeObject<List<GetItemsSubasta>>(Itemstring);

            Subasta[0].GetItemsSubasta = Items;

            //CONSULTAR LISTA PROVEEDORE
            var parameterProveedor = new { IdSubasta = subastaId };
            var Proveedortring = _dapperProcedure.GetQuery(parameterProveedor, "GETPROVIDERAUCTION");
            var proveedores = JsonConvert.DeserializeObject<List<GetProveedorResponse>>(Proveedortring);

            if (usuarioId.HasValue && usuarioId != Guid.Empty)
            {
                proveedores = proveedores.Where(p => p.UsuarioId == usuarioId).ToList();
            }

            Subasta[0].GetProveedorResponse = proveedores;

            var colaboradores = _dataBaseService.UsuarioColaboradorSubasta
                .Where(c => c.SubastaId == subastaId && c.Estado)
                .Select(c => c.UsuarioId)
                .ToList();

            Subasta[0].Colaboradores = colaboradores;

            var configuracion = _dataBaseService.ConfiguracionSubastaInglesa
                .FirstOrDefault(c => c.SubastaId == subastaId);

            var configuracionSubasta = new
            {
                MostrarMejorOferta = configuracion?.MostrarMejorOferta ?? false,
                MostrarPosicion = configuracion?.MostrarPosicion ?? false,
                MejorarPropiaPosicion = configuracion?.MejorarPropiaPosicion ?? false,
                PosicionAMejorar = configuracion?.PosicionAMejorar ?? 0
            };
            Subasta[0].ConfiguracionSubasta = configuracionSubasta;

            return ResponseApiService.Response(StatusCodes.Status200OK, Subasta);
        }

    }

}
