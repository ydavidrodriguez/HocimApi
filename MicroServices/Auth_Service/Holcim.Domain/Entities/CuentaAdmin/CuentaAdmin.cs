namespace Holcim.Domain.Entities.CuentaAdmin
{
    public class CuentaAdmin
    {
        public Guid IdCuentaAdmin { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario.Usuario Usuario { get; set; }
        public Guid PaisId { get; set; }
        public Pais.Pais Pais { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }


    }
}
