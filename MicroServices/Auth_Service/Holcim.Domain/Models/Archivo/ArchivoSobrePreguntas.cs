using Holcim.Domain.Entities.Archivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holcim.Domain.Models.Archivo
{
    public class ArchivoSobrePreguntas
    {
        public ArchivoSobre ArchivoSobre { get; set; }
        public List<PreguntaDto>? CrearPregunta { get; set; } 
    }
    public class PreguntaDto
    {
        public Guid? IdPreguntaArchivo { get; set; }
        public string Pregunta { get; set; } 
        public string Detalle { get; set; }
        public Guid TipoRespuesta { get; set; } 
        public bool Requerido { get; set; }
        public List<string> Opciones { get; set; } 
    }
}
