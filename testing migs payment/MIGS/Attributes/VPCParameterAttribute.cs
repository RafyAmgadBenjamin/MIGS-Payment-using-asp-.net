using System;

namespace MIGS.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class VPCParameterAttribute : Attribute
    {
        public string Value { get; set; }

        public VPCParameterAttribute() { }

        public VPCParameterAttribute(string value)
        {
            this.Value = value;
        }
    }
}
