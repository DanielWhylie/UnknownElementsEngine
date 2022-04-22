using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
            UserProject dContext = DataContext as UserProject;

            if (sender == saveMenuItem)
            {
                UserProject.SaveProject(dContext);
            }
            //else if (sender == openProjectButton)
            //{
            //    string projectPath = openProjectPathTextBox.Text;

            //    if (!String.IsNullOrEmpty(projectPath))
            //    {
            //        string fullFileName = projectPath.Split(Convert.ToChar($@"\")).Last();
            //        string fileNameOnly = fullFileName.Split(Convert.ToChar(".")).First();

            //        ProjectInfo projectInfo = new ProjectInfo
            //        {
            //            projectName = fileNameOnly,
            //            projectPath = projectPath
            //        };

            //        UserProject project = OpenProject.OpenUserProject(projectInfo);

            //        Window.GetWindow(this).DataContext = project;
            //    }
            //}

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

        //public void OnBrowseFileButtonClick(Object sender, RoutedEventArgs e)
        //{
        //    UserProject dContext = DataContext as UserProject;

        //    if (sender == fileBrowseButton)
        //    {
        //        CommonOpenFileDialog fileBrowserDialog = new CommonOpenFileDialog();

        //        fileBrowserDialog.InitialDirectory = $@"{dContext.fullProjectPath}";

        //        if (fileBrowserDialog.ShowDialog() == CommonFileDialogResult.Ok)
        //        {
        //            string fileName = fileBrowserDialog.FileName;

        //            if (!fileBrowserDialog.FileName.Contains(UserProject.fileExtention))
        //            {
        //                fileName += UserProject.fileExtention;
        //            }

        //            openProjectPathTextBox.Text = fileName;
        //        }
        //    }
        //}

    }
}
