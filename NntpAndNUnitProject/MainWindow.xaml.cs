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
            var dialog = new ServerPropertiesDialog(_viewModel.Server, _viewModel.Port, _viewModel.Username, _viewModel.Password);
            if (dialog.ShowDialog() == true)
            {
                // Update the ViewModel with new values
                _viewModel.Server = dialog.Server;
                _viewModel.Port = dialog.Port;
                _viewModel.Username = dialog.Username;
                _viewModel.Password = dialog.Password;
            }
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