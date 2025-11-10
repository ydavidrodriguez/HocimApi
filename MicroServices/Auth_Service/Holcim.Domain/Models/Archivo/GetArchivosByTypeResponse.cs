using Holcim.Domain.Entities.Archivos;
using Holcim.Domain.Entities.TipoArchivo;

namespace Holcim.Domain.Models.Archivo
{
    public class GetArchivosByTypeResponse
    {
        public  TipoArchivo TipoArchivo { get; set; } = new TipoArchivo();
        public  List<ArchivoSobre> Archivos {  get; set; }  = new List<ArchivoSobre>();
         
    }
}

