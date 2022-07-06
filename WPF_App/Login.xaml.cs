using System.Windows;
using System.Windows.Controls;
using WPF_App.Models;

namespace WPF_App;

public partial class Login : Page
{
    public Login()
    {
        InitializeComponent();
    }
    
    private async void btnLogin_Click(object sender, RoutedEventArgs e)
    {
        string email = tbxEmail.Text;
        string password = pbxPassword.Password;

        
        Globals.LoggedInUserToken = await WebApi.AuthenticateUser(email, password);
        Globals.LoggedInUserEmail = email;
        if (Globals.LoggedInUserToken == null)
        {
            MessageBox.Show("Invalid username or password");
            return;
        }
        
        MessageBox.Show("Login successful");
        NavigationService.Navigate(new DetailPage());
    }

    private void btnRegister_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new RegisterPage());
    }
}