using System;
using System.Collections.Generic;
using System.Text;
using AssemblyBrowserLib.Assembly.Namespace.Types;

namespace AssemblyBrowserLib.Assembly.Namespace
{
    public class NamespaceInfo
    {
        public string Name { get; private set; }
        public List< TypeNSInfo> Types;
        public NamespaceInfo() { }
        public NamespaceInfo(string name, List<TypeNSInfo> types)
        {
            Name = name;
            Types = types;
        }
        public string ToString()
        {
            return Name;
        }
    }
}
