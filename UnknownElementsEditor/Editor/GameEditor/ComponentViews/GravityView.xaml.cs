using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UnknownElementsEditor.GameProject;

namespace UnknownElementsEditor.Editor
{
    /// <summary>
    /// Interaction logic for GravityView.xaml
    /// </summary>
    public partial class GravityView : UserControl
    {
        public GravityView()
        {
            InitializeComponent();
        }

        public void OnRemoveButtonClick(Object sender, RoutedEventArgs e)
        {
            Gravity dContext = (Gravity)DataContext;
            GameEntity asset = dContext.GameObject;

            asset.RemoveComponentFromEntity(dContext);
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
