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

namespace Password_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> passwords = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            // Test data
            passwords.Add("Gmail | test@gmail.com | 123456");
            listPasswords.ItemsSource = passwords;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string newData = $"{txtService.Text} | {txtUsername.Text} | {txtPassword.Text}";
            passwords.Add(newData);

            // Update list
            listPasswords.ItemsSource = null;
            listPasswords.ItemsSource = passwords;

            // Clear list
            txtService.Text = "Service";
            txtUsername.Text = "Username";
            txtPassword.Text = "Password";
        }
    }
}
