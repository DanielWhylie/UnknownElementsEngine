using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace UnknownElementsEditor.Editor.GameEditor
{
    /// <summary>
    /// Interaction logic for GraphicalEditorView.xaml
    /// </summary>
    public partial class GraphicalEditorView : UserControl
    {
        //[DllImport("user32.dll")]
        //static extern IntPtr SetParent(IntPtr hwc, IntPtr hwp);

        public UserProject dContext;

        public GraphicalEditorView()
        {
            InitializeComponent();
            Loaded += OnGraphicalEditorViewLoaded;
        }

        private void OnGraphicalEditorViewLoaded(object sender, RoutedEventArgs e)
        {
            Debug.Assert(DataContext != null);
            dContext = DataContext as UserProject;
        }

        public int GraphicViewWidth;
        public int GraphicViewHeight;
        public WriteableBitmap writeBitMap;
        public void StartGraphics(object sender, RoutedEventArgs e)
        {
            //    string[] splitCurrentDirectory = Directory.GetCurrentDirectory().Split(System.IO.Path.DirectorySeparatorChar);
            //    for (int i = 1; i <= 3; i++)
            //    {
            //        splitCurrentDirectory[splitCurrentDirectory.Count() - i] = "";
            //    }
            //    splitCurrentDirectory[splitCurrentDirectory.Count() - 3] = System.IO.Path.DirectorySeparatorChar.ToString();
            //    string enginePath = String.Join(System.IO.Path.DirectorySeparatorChar.ToString(), splitCurrentDirectory) + @"\bin\Debug\netcoreapp3.1\UnknownElementsEngine.exe";

            //    Process p = Process.Start(enginePath);
            //    p.WaitForInputIdle();
            //    SetParent(p.MainWindowHandle, );




            GraphicViewWidth = (int)viewPort.Width;
            GraphicViewHeight = (int)viewPort.Height;

            writeBitMap = BitmapFactory.New(GraphicViewWidth, GraphicViewHeight);
            viewPort.Source = writeBitMap;
            

            CompositionTarget.Rendering += Rendering;
        }
        public Vector2D pos = new Vector2D(0, 0);
        public Vector2D siz = new Vector2D(10, 10);
        private void Rendering(object sender, EventArgs e)
        {
            writeBitMap.Clear();
            pos.X += 1;
            pos.Y += 1;

            writeBitMap.FillEllipse((int)pos.X, (int)pos.Y, (int)pos.X + (int)siz.X, (int)pos.Y + (int)siz.Y, Colors.Red);
        }
    }
}
