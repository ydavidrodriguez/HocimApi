namespace Holcim.ContractsService.Domain.Entities.Pasos
{
    public class PasosPerfiles
    {
        public Guid IdPasosPerfiles { get; set; }
        public PasoFlujo PasoFlujo { get; set; }
        public Guid PasoFlujoId { get; set; }
        public Guid PerfilId { get; set; }
        public bool EnvioCorreo { get; set; }
        public string? FechaEnvioCorreo  { get; set; }

    }
}

