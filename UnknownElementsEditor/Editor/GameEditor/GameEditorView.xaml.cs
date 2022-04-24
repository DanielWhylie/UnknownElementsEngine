using System;
using System.Windows;
using System.Windows.Controls;
using UnknownElementsEditor.GameProject;

namespace UnknownElementsEditor.Editor
{
    /// <summary>
    /// Interaction logic for GameEditorView.xaml
    /// </summary>
    public partial class GameEditorView : UserControl
    {
        public WindowState winState;

        public GameEditorView()
        {
            InitializeComponent();

        }

        public void OnMenuClick(Object sender, RoutedEventArgs e)
        {
            UserProject dContext = (UserProject)DataContext;

            if (sender == saveMenuItem)
            {
                UserProject.SaveProject(dContext);
            }

            else if (sender == exitMenuItem)
            {
                UserProject.SaveProject(dContext);

                Application.Current.Shutdown();
            }
            else if (sender == fullScreenMenuItem)
            {
                winState = Application.Current.MainWindow.WindowState;
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
                fullScreenMenuItem.IsEnabled = false;
                windowedscreenMenuItem.IsEnabled = true;
            }
            else if (sender == windowedscreenMenuItem)
            {
                Application.Current.MainWindow.WindowState = winState;
                windowedscreenMenuItem.IsEnabled = false;
                fullScreenMenuItem.IsEnabled = true;
            }
        }
    }
}
