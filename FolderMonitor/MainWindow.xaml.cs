using FolderMonitor.Pages;
using System;
using System.Windows;

namespace FolderMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, EventArgs e)
        {
            mainFrame.Content = new MainMenuPage(this); // move to main menu
        }
    }
}