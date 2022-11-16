using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using AssemblyBrowserLib;
using AssemblyBrowserLib.Assembly;
using AssemblyBrowserLib.Assembly.Namespace;
using AssemblyBrowserLib.Assembly.Namespace.Types;
using System.Windows;
using Microsoft.Win32;
using AssemblyBrowserLib.Assembly.Namespace.Types.Elements;

namespace AssemblyBrowser
{
    public class MainWindowModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public AssemblyBrowserLib.AssemblyBrowser Assembly;
        private ObservableCollection<TreeNode> _nodes;
        public ObservableCollection<TreeNode> Nodes
        {
            get { return _nodes; }
            set
            {
                _nodes = value;
                OnPropertyChanged();
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public ObservableCollection<TreeNode> NsToCollection(Dictionary<string, NamespaceInfo> namespaces)
        {
            var collection = new ObservableCollection<TreeNode>();
            foreach (var ns in namespaces)
            {
                collection.Add(new TreeNode(ns.Value.ToString(), TypesToCollection(ns.Value.Types)));
            }
            return collection;
        }

        public ObservableCollection<TreeNode> TypesToCollection(List<TypeNSInfo> types)
        {
            var collection = new ObservableCollection<TreeNode>();
            foreach (var type in types)
            {
                collection.Add(new TreeNode(type.ToString(), TypeElementsToCollection(type)));
            }
            return collection;
        }
        private ObservableCollection<TreeNode> TypeElementsToCollection(TypeNSInfo type)
        {
            var collection = new ObservableCollection<TreeNode>();
            foreach (var field in type.Fields)
            {
                collection.Add(new TreeNode(field.ToString()));
            }
            foreach (var property in type.Properties)
            {
                collection.Add(new TreeNode(property.ToString()));
            }
            foreach (var method in type.Methods)
            {
                collection.Add(new TreeNode(method.ToString()));
            }
            return collection;
        }
        public void LoadAssembly(object o=null, RoutedEventArgs e=null)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter += "DllFiles (*.dll)|*.dll";
            if (fileDialog.ShowDialog() == false)
            {
                return;
            }
            Assembly = new AssemblyBrowserLib.AssemblyBrowser(fileDialog.FileName);
            Nodes = new ObservableCollection<TreeNode>
            {
                new TreeNode(Assembly.ToString(), NsToCollection(Assembly.Namespaces))
            };
        }
    }
}
