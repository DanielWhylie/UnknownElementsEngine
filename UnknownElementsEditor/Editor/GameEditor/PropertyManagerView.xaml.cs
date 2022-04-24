using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UnknownElementsEditor.GameProject;

namespace UnknownElementsEditor.Editor
{
    /// <summary>
    /// Interaction logic for PropertyManagerView.xaml
    /// </summary>
    public partial class PropertyManagerView : UserControl
    {
        public static PropertyManagerView propertyViewInstance { get; private set; }

        public PropertyManagerView()
        {
            InitializeComponent();
            DataContext = null;
            propertyViewInstance = this;
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

        public void OnComonentAdd(Object sender, RoutedEventArgs e)
        {
            GameEntity dContext = (GameEntity)DataContext;

            if (sender == transformMenuItem)
            {
                dContext.AddComponentToEntity(new UnknownElementsEditor.GameProject.Transform(dContext));
            }
            else if (sender == gravityMenuItem)
            {
                dContext.AddComponentToEntity(new UnknownElementsEditor.GameProject.Gravity(dContext));
            }
            else if (sender == boxCollider2DMenuItem)
            {
                dContext.AddComponentToEntity(new UnknownElementsEditor.GameProject.BoxCollider2D(dContext));
            }
            else if (sender == scriptMenuItem)
            {
                dContext.AddComponentToEntity(new UnknownElementsEditor.GameProject.Script(dContext));
            }
        }

    }
}
