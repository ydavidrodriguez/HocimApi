using System.Runtime.Serialization;

namespace Holcim.AuctionService.Application.Enum
{
    public enum EnumsProcedure
    {
        [EnumMember(Value = "GETPROVIDERAUCTIONEMAIL")]
        GETPROVIDERAUCTIONEMAIL,

        [EnumMember(Value = "Suspendido")]
        Suspendido,

        [EnumMember(Value = "subasta")]
        TipoEstado

    }
}
