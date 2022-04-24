using System;
using System.Windows;

namespace UnknownElementsEditor.GameProject
{
    /// <summary>
    /// Interaction logic for ProjectBrowserWin.xaml
    /// </summary>
    public partial class ProjectBrowserWin : Window
    {
        public ProjectBrowserWin()
        {
            InitializeComponent();
        }

        private void OnToggleButtonClick(Object sender, RoutedEventArgs e)
        {
            if (sender == openProjectButton)
            {
                if (createProjectButton.IsChecked == true || unknownNewsButton.IsChecked == true)
                {
                    createProjectButton.IsChecked = false;
                    unknownNewsButton.IsChecked = false;
                    browserView.Margin = new Thickness(-800, 0, 0, 0);
                }

                openProjectButton.IsChecked = true;
            }
            else if (sender == createProjectButton)
            {
                if (openProjectButton.IsChecked == true || unknownNewsButton.IsChecked == true)
                {
                    openProjectButton.IsChecked = false;
                    unknownNewsButton.IsChecked = false;
                    browserView.Margin = new Thickness(-1600, 0, 0, 0);
                }

                createProjectButton.IsChecked = true;
            }
            else
            {
                if (openProjectButton.IsChecked == true || createProjectButton.IsChecked == true)
                {
                    openProjectButton.IsChecked = false;
                    createProjectButton.IsChecked = false;
                    browserView.Margin = new Thickness(0);
                }

                unknownNewsButton.IsChecked = true;
            }
        }
    }
}
