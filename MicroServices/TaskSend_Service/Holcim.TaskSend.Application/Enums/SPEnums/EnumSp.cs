using System.Runtime.Serialization;

namespace Holcim.TaskSend.Application.Enums.SPEnums
{
    public enum EnumSp
    {
        //Obtener la lista de subasta pendiente
        [EnumMember(Value = "GETSTATEPENDINGAPRROVE")]
        GETSTATEPENDINGAPRROVE,

        //Actualizar el estado de la subasta
        [EnumMember(Value = "POSTUPDATEUACTIONSTATE")]
        POSTUPDATEUACTIONSTATE,
        

    }
}
