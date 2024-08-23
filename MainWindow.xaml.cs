using System.Windows.Input;
using System.Windows;

namespace WebView_Browser
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeBrowser();
        }

        private async void InitializeBrowser()
        {
            await Browser.EnsureCoreWebView2Async(null);
            Browser.Source = new Uri("https://pbitminecraft.github.io/");
        }

        private void AddressBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                NavigateToAddress();
            }
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateToAddress();
        }

        private void NavigateToAddress()
        {
            var address = AddressBar.Text;
            if (!address.StartsWith("http"))
            {
                address = "https://" + address;
            }

            Browser.Source = new Uri(address);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Browser.CanGoBack)
            {
                Browser.GoBack();
            }
        }

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            if (Browser.CanGoForward)
            {
                Browser.GoForward();
            }
        }

        private void ReloadButton_Click(object sender, RoutedEventArgs e)
        {
            Browser.Reload();
        }
    }
}