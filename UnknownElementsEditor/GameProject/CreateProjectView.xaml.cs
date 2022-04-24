using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Windows;
using System.Windows.Controls;

namespace UnknownElementsEditor.GameProject
{
    /// <summary>
    /// Interaction logic for CreateProjectView.xaml
    /// </summary>
    public partial class CreateProjectView : UserControl
    {
        public CreateProjectView()
        {
            InitializeComponent();
        }

        public void OnBrowseFileButtonClick(Object sender, RoutedEventArgs e)
        {
            if (sender == fileBrowseButton)
            {
                CommonOpenFileDialog fileBrowserDialog = new CommonOpenFileDialog();

                fileBrowserDialog.InitialDirectory = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\UnknownElements";
                fileBrowserDialog.IsFolderPicker = true;

                if (fileBrowserDialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    projectPathEntry.Text = fileBrowserDialog.FileName;
                    Window.GetWindow(this).Focus();
                }
                else
                {
                    Window.GetWindow(this).Focus();
                }
            }
        }

        public void OnCreateButtonClick(Object sender, RoutedEventArgs e)
        {
            if (sender == createButton)
            {
                NewProject dContext = (NewProject)DataContext;
                string projectPath = dContext.CreateProject((ProjectTemplate)templatesListBox.SelectedItem);

                bool dialogResult = false;
                Window window = Window.GetWindow(this);

                if (!String.IsNullOrEmpty(projectPath))
                {
                    dialogResult = true;

                    ProjectInfo projectInfo = new ProjectInfo
                    {
                        projectName = dContext.ProjectName,
                        projectPath = projectPath
                    };

                    UserProject project = OpenProject.OpenUserProject(projectInfo);

                    window.DataContext = project;
                }

                window.DialogResult = dialogResult;
                window.Close();
            }

        }
    }
}
