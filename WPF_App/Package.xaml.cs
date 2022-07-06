using System.Windows;
using System.Windows.Controls;

namespace WPF_App;

public partial class Package : Page
{
    public Package()
    {
        InitializeComponent();
    }

    private async void ButtonGetPackage_Click(object sender, RoutedEventArgs e)
    {
        var dgData = await WebApi.GetGetPackageByIdAsync(packageId.Text);
        dgBoxes.ItemsSource = dgData;
    }

    private void btnLoginOnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new Login());
    }
}