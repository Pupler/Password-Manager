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

using System.Linq;

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
            updateList();

            // Clear fields
            clearFields();

        }

        private void updateList()
        {
            listPasswords.ItemsSource = null;
            listPasswords.ItemsSource = passwords;
        }

        private void clearFields()
        {
            txtService.Text = "Service";
            txtUsername.Text = "Username";
            txtPassword.Text = "Password";
        }

        private void passwordSearch(object sender, TextChangedEventArgs e)
        {
            if (passwordSearch_input == null || listPasswords == null) return;
            if (passwordSearch_input.Text == "Search...") return;

            var searchText = passwordSearch_input.Text.ToLower();
            var filteredPasswords = passwords.Where(p => p.ToLower().Contains(searchText)).ToList();
            listPasswords.ItemsSource = filteredPasswords;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%";

            var random = new Random();

            string password = new string(Enumerable.Repeat(chars, 12)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            txtPassword.Text = password;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = listPasswords.SelectedItem.ToString();

            if (listPasswords.SelectedItem != null)
            {
                passwords.Remove(selectedItem);

                // Update list
                updateList();
            }
        }

        private void copyClick(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string text = btn.Tag.ToString();
            Clipboard.SetText(text);
        }
    }
}
