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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UnknownElementsEditor.Editor
{
    /// <summary>
    /// Interaction logic for ComponentView.xaml
    /// </summary>
    
    [ContentProperty("CompContent")]
    public partial class ComponentView : UserControl
    {
        public ComponentView()
        {
            InitializeComponent();
        }

        public string Header
        {
            get
            {
                return (string)GetValue(HeaderProperty);
            }
            set
            {
                SetValue(HeaderProperty, value);
            }
        }

        public static DependencyProperty HeaderProperty = DependencyProperty.Register(nameof(Header), typeof(string), typeof(ComponentView));

        public FrameworkElement CompContent
        {
            get
            {
                return (FrameworkElement)GetValue(CompContentProperty);
            }
            set
            {
                SetValue(CompContentProperty, value);
            }
        }

        public static DependencyProperty CompContentProperty = DependencyProperty.Register(nameof(CompContent), typeof(FrameworkElement), typeof(ComponentView));
    }
}
