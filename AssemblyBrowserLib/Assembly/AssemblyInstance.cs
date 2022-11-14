using System;
using System.Collections.Generic;
using System.Text;
using AssemblyBrowserLib.Assembly.Namespace;

namespace AssemblyBrowserLib.Assembly
{
    public class AssemblyInstance
    {
        public string Name { get; private set; }
        public Dictionary<string, NamespaceInfo> Namespaces { get; }
        public AssemblyInstance(string name, Dictionary<string, NamespaceInfo> namespaces)
        {
            Name = name;
            Namespaces = namespaces;
        }
        public string ToString()
        {
            return Name;
        }
    }
}
