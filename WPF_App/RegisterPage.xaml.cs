using System.Windows;
using System.Windows.Controls;
using WPF_App.Models;

namespace WPF_App;

public partial class RegisterPage : Page
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private async void btnReg_Click(object sender, RoutedEventArgs e)
    {
        string email = tbxEmail.Text;
            string password = pbxPassword.Password;
            string confirmPassword = pbxConfirmPassword.Password;
            string name = tbxname.Text;


            var created = await WebApi.RegisterUser(email, password, confirmPassword, name);

            Globals.LoggedInUserToken = await WebApi.AuthenticateUser(email, password);
            MessageBox.Show("Registration successful");
            NavigationService.Navigate(new DetailPage());
        }
    

    private void btnBack_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }
}