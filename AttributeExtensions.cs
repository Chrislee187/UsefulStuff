using System;

namespace UsefulStuff
{
    public static class AttributeExtensions
    {
        public static string GetTypeName(this Attribute attribute)
        {
            return ((string)((dynamic)attribute.TypeId).Name);
        }
    }
}