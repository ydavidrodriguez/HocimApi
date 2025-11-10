namespace Holcim.Domain.Models.Informes
{
    public class CreateInformesRolRequest
    {
     
        public Guid InformesId { get; set; }
        public List<Guid> RolId { get; set; }
    }
}
