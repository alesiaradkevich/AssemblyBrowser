using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
namespace AssemblyBrowser
{
    public class TreeNode : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
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

        public void OnPropertyChanged([CallerMemberName]string prop="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public TreeNode() { }
        public TreeNode(string name, ObservableCollection<TreeNode> nodes=null)
        {
            Name = name;
            Nodes = nodes;
        }
    }
}
