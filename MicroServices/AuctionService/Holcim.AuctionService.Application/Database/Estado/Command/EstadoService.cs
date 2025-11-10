using Holcim.AuctionService.Application;
using Holcim.AuctionService.Application.External;
using Newtonsoft.Json;

namespace Holcim.AuctionService.Services
{
    public class EstadoService : IEstadoService
    {
        private readonly IDapperProcedure _dapperProcedure;
        private readonly IDataBaseService _dataBaseService;

        public EstadoService(IDapperProcedure dapperProcedure, IDataBaseService dataBaseService)
        {
            _dapperProcedure = dapperProcedure;
            _dataBaseService = dataBaseService;
        }

        public async Task<Guid> GetEstadoIdByNameAsync(string nombreEstado)
        {
            try
            {
                // Filtrar el TipoEstado correspondiente
                var parameters = new { descripcion = "subasta" };
                var result = _dapperProcedure.GetQuery(parameters, "FiltrarTipoEstadoPorDescripcion");
                List<TipoEstado> tipoEstado = JsonConvert.DeserializeObject<List<TipoEstado>>(result);

                // Buscar el Estado por nombre, TipoEstadoId y activo
                var estado = _dataBaseService.Estado
                    .Where(e => e.Nombre == nombreEstado && e.Activo && e.TipoEstadoId == tipoEstado[0].IdTipoEstado)
                    .FirstOrDefault();

                if (estado == null)
                {
                    throw new Exception($"No se encontró el estado con el nombre: {nombreEstado}");
                }

                return estado.IdEstado;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el estado: {ex.Message}");
            }
        }
    }

    public interface IEstadoService
    {
        Task<Guid> GetEstadoIdByNameAsync(string nombreEstado);
    }
}
