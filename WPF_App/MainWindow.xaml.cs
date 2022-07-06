using System.Windows;

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

        private void ButtoClick(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new Package();
        }
    }
}