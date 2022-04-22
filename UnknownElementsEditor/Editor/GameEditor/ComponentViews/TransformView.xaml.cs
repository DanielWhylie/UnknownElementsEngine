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
    /// Interaction logic for TransformView.xaml
    /// </summary>
    public partial class TransformView : UserControl
    {
        public TransformView()
        {
            InitializeComponent();
        }

        public void OnRemoveButtonClick(Object sender, RoutedEventArgs e)
        {
            UnknownElementsEditor.GameProject.Transform dContext = DataContext as UnknownElementsEditor.GameProject.Transform;
            GameEntity asset = dContext.GameObject;

            asset.RemoveComponentFromEntity(dContext);
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
