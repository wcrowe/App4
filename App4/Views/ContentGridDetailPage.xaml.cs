using System.Windows.Controls;

using App4.ViewModels;

namespace App4.Views;

public partial class ContentGridDetailPage : Page
{
    public ContentGridDetailPage(ContentGridDetailViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
