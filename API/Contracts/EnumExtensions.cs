using System;
using System.ComponentModel;

namespace HwEFCoreWebAPI.Contracts
{
    public static class EnumExtensions
    {
        public static string Description(this Enum @enum)
        {
            var description = string.Empty;
            var fields = @enum.GetType().GetFields();
            foreach (var field in fields)
            {
                var descriptionAttribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (descriptionAttribute != null && field.Name.Equals(@enum.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    description = descriptionAttribute.Description;
                    break;
                }
            }

            return description;
        }
    }
}
