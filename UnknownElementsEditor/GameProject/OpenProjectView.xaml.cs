using System;
using System.Windows;
using System.Windows.Controls;

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

        public void OnOpenButtonClick(Object sender, RoutedEventArgs e)
        {
            if (sender == openProjectButton)
            {
                UserProject project = OpenProject.OpenUserProject((ProjectInfo)projectListBox.SelectedItem);

                bool dialogResult = false;

                if (project != null)
                {
                    dialogResult = true;
                }

                Window.GetWindow(this).DataContext = project;
                Window.GetWindow(this).DialogResult = dialogResult;
                Window.GetWindow(this).Close();
            }

        }
    }
}
