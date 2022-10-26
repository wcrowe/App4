using System.Windows.Controls;

using App4.ViewModels;

using Microsoft.Web.WebView2.Core;

namespace App4.Views;

public partial class WebViewPage : Page
{
    private readonly WebViewViewModel _viewModel;

    public WebViewPage(WebViewViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
        _viewModel = viewModel;
        _viewModel.Initialize(webView);
    }

    private void OnNavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        => _viewModel.OnNavigationCompleted(sender, e);
}
