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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UnknownElementsEditor.GameProject
{
    /// <summary>
    /// Interaction logic for OpenProjectView.xaml
    /// </summary>
    public partial class OpenProjectView : UserControl
    {
        public OpenProjectView()
        {
            InitializeComponent();
        }

        public void OnCreateButtonClick(Object sender, RoutedEventArgs e)
        {
            if (sender == openProjectButton)
            {
                UserProject project = OpenProject.OpenUserProject(projectListBox.SelectedItem as ProjectInfo);

                bool dialogResult = false;

                if (project != null)
                {
                    dialogResult = true;
                }

                Window.GetWindow(this).DialogResult = dialogResult;
                Window.GetWindow(this).Close();
            }

        }
    }
}
