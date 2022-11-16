using System;
using System.Collections.Generic;
using System.Text;

namespace AssemblyBrowserLib.Assembly.Namespace.Types.Elements
{
    public class Field
    {
        public string Name;
        public string Attributes;
        public string Type;
        public Field(string name, string attributes, string type)
        {
            Name = name;
            Attributes = attributes;
            Type = type;
        }
        public string ToString()
        {
            return "Field: " + Attributes + " " + Type + " " + Name;
        }
    }
}
