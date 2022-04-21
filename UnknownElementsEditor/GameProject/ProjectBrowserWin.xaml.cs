using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
                    browserView.Margin = new Thickness(-800,0,0,0);
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

        private void CreateProjectView_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
