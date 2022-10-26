using System.Windows.Controls;

using App4.ViewModels;

namespace App4.Views;

public partial class BlankPage : Page
{
    public BlankPage(BlankViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
