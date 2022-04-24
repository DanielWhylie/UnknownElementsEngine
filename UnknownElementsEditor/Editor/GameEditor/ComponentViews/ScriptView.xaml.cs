using Microsoft.WindowsAPICodePack.Dialogs;
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
using UnknownElementsEditor.GameProject;

namespace UnknownElementsEditor.Editor
{
    /// <summary>
    /// Interaction logic for ScriptView.xaml
    /// </summary>
    public partial class ScriptView : UserControl
    {
        public ScriptView()
        {
            InitializeComponent();
        }

        public void OnRemoveButtonClick(Object sender, RoutedEventArgs e)
        {
            Script dContext = DataContext as Script;
            GameEntity asset = dContext.GameObject;

            asset.RemoveComponentFromEntity(dContext);
        }

        public void OnBrowseButtonClick(Object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog fileBrowserDialog = new CommonOpenFileDialog();

            fileBrowserDialog.InitialDirectory = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\UnknownElements";

            if (fileBrowserDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Script dContext = DataContext as Script;
                GameEntity asset = dContext.GameObject;

                Script scriptComponent = (Script)asset.GetComponent("Script");
                scriptComponent.scriptPath = fileBrowserDialog.FileName;
            }
        }

        public void OnRenameTextBoxChange(Object sender, KeyEventArgs e)
        {
            TextBox box = sender as TextBox;

            if (e.Key == Key.Enter)
            {
                // Kill logical focus
                FocusManager.SetFocusedElement(FocusManager.GetFocusScope(box), null);

                // Kill keyboard focus
                Keyboard.ClearFocus();
            }
        }
    }
}
