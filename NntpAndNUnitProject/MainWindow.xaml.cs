using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NntpAndUnitProject
{

    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();  
            DataContext = _viewModel;  
        }

        private void ServerPropertiesButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Server: {_viewModel.Server}\nPort: {_viewModel.Port}\nUsername: {_viewModel.Username}",
                "Server Properties",
                MessageBoxButton.OK);
        }

        private void ConnectToServerButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ConnectToServer();
        }

        private void GetNewsgroupButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.GetNewsgroups();
        }
    }
}