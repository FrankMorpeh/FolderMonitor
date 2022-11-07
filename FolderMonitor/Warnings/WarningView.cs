using System.Windows.Controls;
using System.Windows;

namespace FolderMonitor.Warnings
{
    public static class WarningView
    {
        public static void ShowStackPanelWarningByType(StackPanel warningStackPanel, TextBlock warningTextBlock, IWarning errorType)
        {
            warningTextBlock.Text = errorType.Text;
            warningStackPanel.Visibility = Visibility.Visible;
        }
        public static void CloseStackPanelWarning(StackPanel warningStackPanel)
        {
            warningStackPanel.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}