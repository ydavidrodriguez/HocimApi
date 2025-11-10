using System.Runtime.Serialization;

namespace Holcim.Domain.Entities.Enums.SPEnums
{
    public static class EnumSpExtensions
    {
        public static string GetEnumMemberValue(this EnumSp enumValue)
        {
            var type = enumValue.GetType();
            var memberInfo = type.GetMember(enumValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                var attributes = memberInfo[0].GetCustomAttributes(typeof(EnumMemberAttribute), false);
                if (attributes != null && attributes.Length > 0)
                {
                    return ((EnumMemberAttribute)attributes[0]).Value!;
                }
            }
            return enumValue.ToString();
        }
    }
}
