using System.Runtime.Serialization;

namespace Holcim.Domain.Entities.Enums
{
    public enum EnumDomain
    {
        [EnumMember(Value = "Proveedor")]
        RolProveedor,

        [EnumMember(Value = "Proveedor")]
        TipoUsuarioProveedor,

        [EnumMember(Value = "Holcim")]
        TipoUsuarioHolcim,

        [EnumMember(Value = "CreacionUsuarioHolcim")]
        CreacionUsuarioHolcim,

        [EnumMember(Value = "Aprobado")]
        RfxAprobado,

        [EnumMember(Value = "InvitacionRfx")]
        InvitacionRfxProveedores,

        [EnumMember(Value = "CreacionProveedorHolcim")]
        CreacionProveedorHolcim,


        //Estado

        [EnumMember(Value = "ProveedorRfx")]
        TipoEstadoProveedorRfx,

        [EnumMember(Value = "Pendiente Respuesta")]
        PendienteRespuesta,

        [EnumMember(Value = "Pendiente Aceptacion")]
        PendienteAceptacion,

        [EnumMember(Value = "Proveedor")]
        PaisProveedor,

        [EnumMember(Value = "Grud")]
        PaisGrud,

        [EnumMember(Value = "Sobre Económico")]
        SobreEconómico,

        [EnumMember(Value = "ActualizacionContrasena")]
        ActualizacionContrasena,  
        
        [EnumMember(Value = "Finalizado")]
        Finalizado,

        [EnumMember(Value = "Adjudicado")]
        Adjudicado,

        [EnumMember(Value = "Suspendido")]
        Suspendido,

        //TipoEstado

        [EnumMember(Value = "rfx")]
        rfx,

        //Proveedor Generico
        [EnumMember(Value = "Colombia")]
        PaisGenerico,

        [EnumMember(Value = "America/Bogota")]
        ZonaHorariaGenerico,

        [EnumMember(Value = "Empresa Generica")]
        EmpresaGenerica,

        //Roles

        [EnumMember(Value = "Administrador Sistema")]
        AdministradorSistema,

        [EnumMember(Value = "Administrador Regional")]
        AdministradorRegional,

        [EnumMember(Value = "Administrador Global")]
        AdministradorGlobal,

        [EnumMember(Value = "Genérico")]
        Generico,

        [EnumMember(Value = "Proveedor")]
        Proveedor,

        [EnumMember(Value = "Auditor")]
        Auditor,

        [EnumMember(Value = "Comprador")]
        Comprador,

    }
}
