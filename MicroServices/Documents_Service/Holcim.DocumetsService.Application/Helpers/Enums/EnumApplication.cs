using System.Runtime.Serialization;

namespace Holcim.DocumetsService.Application.Helpers.Enums
{
    public enum EnumApplication
    {
        [EnumMember(Value = "contrato")]
        Contrato,

        [EnumMember(Value = "subasta")]
        Subasta,

        [EnumMember(Value = "rfx")]
        Rfx,

    }
}
