using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NntpAndUnitProject
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private NntpClientService _nntpClient;  
        private ObservableCollection<string> _userGroups;  
        private ConnectionModel _connectionModel;
        private bool _isAuthenticated;

        public ObservableCollection<string> UserGroups
        {
            get => _userGroups;
            set { _userGroups = value; OnPropertyChanged("UserGroups"); }
        }

        public string Server { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public MainViewModel()
        {
            _nntpClient = new NntpClientService();  
            _userGroups = new ObservableCollection<string>();

            _connectionModel = new ConnectionModel("news.sunsite.dk", 119, "janand02@easv365.dk", "2dfd02");

            Server = _connectionModel.Server;
            Port = _connectionModel.Port;
            Username = _connectionModel.Username;
            Password = _connectionModel.Password;
        }

        public void ConnectToServer()
        {
            _connectionModel = new ConnectionModel(Server, Port, Username, Password);
            _isAuthenticated = _nntpClient.Connect(_connectionModel);

            if (!_isAuthenticated)
            {
                MessageBox.Show("Failed to authenticate to the server.", "Connection Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Successfully connected to server.", "Connection Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        public void GetNewsgroups()
        {
            if (!_isAuthenticated)
            {
                MessageBox.Show("You must connect and authenticate before retrieving newsgroups.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBox.Show("News Groups collecting");

            try
            {
                string response = _nntpClient.SendCommand("LIST NEWSGROUPS");

                var newsgroups = response.Split('\n');
                foreach (string group in newsgroups)
                {
                    if (!string.IsNullOrWhiteSpace(group))
                    {
                        UserGroups.Add(group.Trim());
                    }
                }

                MessageBox.Show("Newsgroups retrieved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving newsgroups: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
