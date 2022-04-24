using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
            Script dContext = (Script)DataContext;
            GameEntity asset = dContext.GameObject;

            asset.RemoveComponentFromEntity(dContext);
        }

        public void OnBrowseButtonClick(Object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog fileBrowserDialog = new CommonOpenFileDialog();

            fileBrowserDialog.InitialDirectory = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\UnknownElements";

            if (fileBrowserDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Script dContext = (Script)DataContext;
                GameEntity asset = dContext.GameObject;

                Script scriptComponent = (Script)asset.GetComponent(typeof(Script));
                scriptComponent.scriptPath = fileBrowserDialog.FileName;
            }
        }

        public void OnRenameTextBoxChange(Object sender, KeyEventArgs e)
        {
            TextBox box = (TextBox)sender;

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
