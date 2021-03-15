using System;

namespace StopCheck2.Data.DB.Model
{
    public class ReferenceAttribute : Attribute
    {
        public string PropertyName { get; private set; }

        public ReferenceAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}
