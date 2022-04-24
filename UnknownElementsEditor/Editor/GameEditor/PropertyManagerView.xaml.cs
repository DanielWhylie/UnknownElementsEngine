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
            TextBox box = sender as TextBox;

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
            GameEntity dContext = DataContext as GameEntity;

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
