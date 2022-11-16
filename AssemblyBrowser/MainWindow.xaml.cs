using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace AssemblyBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowModel Model;
        
        public MainWindow()
        {
            InitializeComponent();
            Model = new MainWindowModel();
            DataContext = Model; 
            var commandBinding = new CommandBinding();
            commandBinding.Command = ApplicationCommands.Open;
            commandBinding.Executed += Model.LoadAssembly;
            btnLoad.CommandBindings.Add(commandBinding);
           // Model.LoadAssembly();
           // treeView1.Items.Add(Model.Nodes);
        }

        
    }
}
