using System.Windows;
using WPF_App.Models;

namespace WPF_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.Content=new Package();
        }

        private void bntPackageStatus_OnClick(object sender, RoutedEventArgs e)
        {
            mainFrame.Content=new Package();
        }

        private void bntLogin_OnClick(object sender, RoutedEventArgs e)
        {
            if(Globals.LoggedInUserEmail!=null) mainFrame.Content=new DetailPage();
            else mainFrame.Content=new Login();
        }

        private void bntDetailPage_OnClick(object sender, RoutedEventArgs e)
        {
            if(Globals.LoggedInUserEmail==null) mainFrame.Content=new Login();
            else mainFrame.Content=new DetailPage();

        }
    }
}