using System;
using System.Collections.Generic;
using System.Text;
using AssemblyBrowserLib.Assembly.Namespace.Types.Elements;
namespace AssemblyBrowserLib.Assembly.Namespace.Types
{
    public class TypeNSInfo
    {
        public string Name {get; private set; }
        public string Attributes;
        public List<Field> Fields;
        public List<Property> Properties;
        public List<Method> Methods;
        public TypeNSInfo() { }
        public TypeNSInfo (string name, string attributes, List<Field>fields, List<Property> properties, List<Method> methods)
        {
            Name = name;
            Attributes = attributes;
            Fields = fields;
            Properties = properties;
            Methods = methods;
        }
        public string ToString()
        {
            return Attributes + " " + Name;
        }
    }
}
