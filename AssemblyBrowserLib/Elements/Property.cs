using System;
using System.Collections.Generic;
using System.Text;

namespace AssemblyBrowserLib.Assembly.Namespace.Types.Elements
{
    public class Property
    {
        public string Name;
        public string SetMethod;
        public string GetMethod;
        public Property (string name, string setMethod, string getMethod)
        {
            Name = name;
            SetMethod = setMethod;
            GetMethod = getMethod;
        }
        public string ToString()
        {
            string result = Name;
            if (GetMethod != null)
            {
                result += " { " + GetMethod + " } ";
            }
            if (SetMethod != null)
            {
                result += " { " + SetMethod + " { ";
            }
            return "Property "+result;
        }
    }
}
