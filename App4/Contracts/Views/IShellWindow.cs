using System.Windows.Controls;

using App4.Behaviors;

using MahApps.Metro.Controls;

namespace App4.Contracts.Views;

public interface IShellWindow
{
    Frame GetNavigationFrame();

    void ShowWindow();

    void CloseWindow();

    Frame GetRightPaneFrame();

    SplitView GetSplitView();

    RibbonTabsBehavior GetRibbonTabsBehavior();
}
