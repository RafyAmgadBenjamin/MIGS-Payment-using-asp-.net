using System;
using System.Linq;

namespace MIGS.Extensions
{
    public static class AttributeExtensions
    {
        public static T GetAttribute<T>(this Object value) where T : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name)
                .GetCustomAttributes(false)
                .OfType<T>()
                .SingleOrDefault();
        }
    }
}
