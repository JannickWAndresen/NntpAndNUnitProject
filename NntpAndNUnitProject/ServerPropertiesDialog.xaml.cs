using System.Windows;

namespace NntpAndUnitProject
{
    public partial class ServerPropertiesDialog : Window
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ServerPropertiesDialog(string server, int port, string username, string password)
        {
            InitializeComponent();
            ServerTextBox.Text = server;
            PortTextBox.Text = port.ToString();
            UsernameTextBox.Text = username;
            PasswordBox.Password = password;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Server = ServerTextBox.Text;
            Port = int.TryParse(PortTextBox.Text, out int port) ? port : 119;
            Username = UsernameTextBox.Text;
            Password = PasswordBox.Password;
            DialogResult = true;
            Close();
        }
    }
}