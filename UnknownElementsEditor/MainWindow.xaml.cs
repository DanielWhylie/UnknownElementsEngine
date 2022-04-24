using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using UnknownElementsEditor.GameProject;

namespace UnknownElementsEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnMainWindowLoaded;
            Closing += OnMainWindowClosing;
        }

        private void OnMainWindowLoaded(object sender, RoutedEventArgs e)
        {
            Loaded -= OnMainWindowLoaded;
            OpenProjectBrowserWin();
        }

        private void OnMainWindowClosing(object sender, CancelEventArgs e)
        {
            Closing -= OnMainWindowClosing;

            if (UserProject.currentLoadedProject != null)
            {
                UserProject.currentLoadedProject.UnloadProject();
            }
        }

        private void OpenProjectBrowserWin()
        {
            ProjectBrowserWin projectBrowser = new ProjectBrowserWin();

            if (projectBrowser.ShowDialog() == false || projectBrowser.DataContext == null)
            {
                Application.Current.Shutdown();
            }
            else
            {
                if (UserProject.currentLoadedProject != null)
                {
                    UserProject.currentLoadedProject.UnloadProject();
                }

                DataContext = projectBrowser.DataContext;
            }
        }
    }
}
