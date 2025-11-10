namespace Holcim.Domain.Models.Usuario
{
    public class CreateUsuarioRequest
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public List<Guid> RolId { get; set; }
        public string Correo { get; set; }
        public Guid PaisId { get; set; }
        public bool? Aprobador {  get; set; }    
        public Guid IdiomaId {  get; set; }    

    }
}
