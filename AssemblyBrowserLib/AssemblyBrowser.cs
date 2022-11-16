using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using AssemblyBrowserLib.Assembly;
using AssemblyBrowserLib.Assembly.Namespace;
using AssemblyBrowserLib.Assembly.Namespace.Types;
using AssemblyBrowserLib.Assembly.Namespace.Types.Elements;

namespace AssemblyBrowserLib
{
    public class AssemblyBrowser
    {
        public string Name { get; private set; }
        public Dictionary<string, NamespaceInfo> Namespaces { get; }
        public AssemblyBrowser(string pathToAssembly)
        {
            var assembly = System.Reflection.Assembly.LoadFrom(pathToAssembly);
            var exportedNamespaces = new Dictionary<string, NamespaceInfo>();
            var exportedTypes = new List<TypeNSInfo>();
            foreach (var exportedType in assembly.ExportedTypes)
            {
                var fields = GetTypeFields(exportedType);
                var properties = GetTypeProperties(exportedType);
                var methods = GetTypeMethods(exportedType);
                if (exportedNamespaces.ContainsKey(exportedType.Namespace))
                {
                    exportedNamespaces[exportedType.Namespace].Types.Add(new TypeNSInfo(exportedType.FullName,
                        exportedType.Attributes.ToString(), fields, properties, methods));
                }
                else
                {
                    exportedNamespaces.Add(exportedType.Namespace, new NamespaceInfo(exportedType.Namespace, new List<TypeNSInfo>{
                        new TypeNSInfo(exportedType.FullName, exportedType.Attributes.ToString(), fields, properties, methods)}));
                }
            }
            Name = assembly.FullName;
            Namespaces = exportedNamespaces;
        }
        public string ToString()
        {
            return Name;
        }
      /*  public static AssemblyBrowser LoadAssembly(string pathToAssembly)
        {
            var assembly = System.Reflection.Assembly.LoadFrom(pathToAssembly);
            var exportedNamespaces = new Dictionary<string, NamespaceInfo>();
            var exportedTypes = new List<TypeNSInfo>();
            foreach (var exportedType in assembly.ExportedTypes)
            {
                var fields = GetTypeFields(exportedType);
                var properties = GetTypeProperties(exportedType);
                var methods = GetTypeMethods(exportedType);
                if (exportedNamespaces.ContainsKey(exportedType.Namespace))
                {
                    exportedNamespaces[exportedType.Namespace].Types.Add(new TypeNSInfo(exportedType.FullName,
                        exportedType.Attributes.ToString(), fields, properties, methods));
                }
                else
                {
                    exportedNamespaces.Add(exportedType.Namespace, new NamespaceInfo(exportedType.Namespace, new List<TypeNSInfo>{
                        new TypeNSInfo(exportedType.FullName, exportedType.Attributes.ToString(), fields, properties, methods)}));
                }
            }
            return new AssemblyBrowser(assembly.FullName, exportedNamespaces);
        }*/
        public static List<Field> GetTypeFields(Type type)
        {
            var fields = new List<Field>();
            foreach (var field in type.GetRuntimeFields())
            {
                fields.Add(new Field(field.Name, field.Attributes.ToString(), field.FieldType.Name));
            }
            return fields;

        }
        public static List<Property> GetTypeProperties(Type type)
        {
            var properties = new List<Property>();
            foreach (var property in type.GetRuntimeProperties())
            {
                properties.Add(new Property(property.Name, property.SetMethod?.Name,
                    property.GetMethod?.Name));
            }
            return properties;
        }
        public static List<Method> GetTypeMethods(Type type)
        {
            var methods = new List<Method>();
            string name;
            string attributes;
            string returnType;
            string[] parameters;
            foreach(var method in type.GetRuntimeMethods())
            {
                name = method.Name;
                var attrs = method.Attributes;
                attributes = "";
                if (attrs.HasFlag(MethodAttributes.Public))
                {
                    attributes += "public ";
                }
                else
                {
                    if (attrs.HasFlag(MethodAttributes.Private))
                    {
                        attributes += "private ";
                    }
                    else
                    {
                        attributes += "protected ";
                    }
                }
                if (attrs.HasFlag(MethodAttributes.Static))
                {
                    attributes += "static ";
                }
                else
                {
                    if (attrs.HasFlag(MethodAttributes.Abstract))
                    {
                        attributes += "abstract ";
                    }
                    else
                    {
                        attributes += "virtual ";
                    }
                }
                returnType = method.ReturnType.Name;
                parameters=method.GetParameters().Select(parameters=>""+
                parameters.ParameterType.Name.ToString() +" "+parameters.Name).ToArray();
                methods.Add(new Method(name, attributes, returnType, parameters));

            }
            return methods;
        }
    }
}
