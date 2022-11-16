using System;
using System.Collections.Generic;
using System.Text;

namespace AssemblyBrowserLib.Assembly.Namespace.Types.Elements
{
    public class Method
    {
        public string Name;
        public string Attributes;
        public string ReturnType;
        public string[] Parameters;
        public Method (string name, string attributes, string returnType, string[] parameters)
        {
            Name = name;
            Attributes = attributes;
            ReturnType = returnType;
            Parameters = parameters;
        }
        public string ToString()
        {
            return "Method: " + Attributes + " " + Name + "(" + String.Join(",", Parameters) + ")";
        }
    }
}
