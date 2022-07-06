using System.Windows;
using System.Windows.Controls;
using WPF_App.Models;

namespace WPF_App;

public partial class DetailPage : Page
{
    public DetailPage()
    {
        InitializeComponent();
        tbLoggedInAs.Text = $"Logged in as: {Globals.LoggedInUserEmail}";
     
    }



    private async void BtnGetPackages_OnClick(object sender, RoutedEventArgs e)
    {
        var dgData = await WebApi.GetAllPackages();
        dgBoxes.ItemsSource = dgData;
    }
}