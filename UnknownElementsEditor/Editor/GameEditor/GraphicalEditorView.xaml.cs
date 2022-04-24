using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public UserProject dContext;
        public RunWindow viewWindow;

        public GraphicalEditorView()
        {
            InitializeComponent();
            assetList = new List<GameEntity>();
            Loaded += OnGraphicalEditorViewLoaded;
        }

        private void OnGraphicalEditorViewLoaded(object sender, RoutedEventArgs e)
        {
            Debug.Assert(DataContext != null);
            dContext = DataContext as UserProject;
            UserProject.SaveProject(dContext);
        }

        public int GraphicViewWidth;
        public int GraphicViewHeight;
        public WriteableBitmap writeBitMap;
        public List<GameEntity> assetList;

        public void StartGraphics(object sender, RoutedEventArgs e)
        {

            GraphicViewWidth = (int)viewPort.Width;
            GraphicViewHeight = (int)viewPort.Height;

            writeBitMap = BitmapFactory.New(GraphicViewWidth, GraphicViewHeight);
            viewPort.Source = writeBitMap;
            

            CompositionTarget.Rendering += Rendering;
        }

        private void Rendering(object sender, EventArgs e)
        {
            ProjectScene activeScene = dContext.ActiveScene;

            writeBitMap.Clear();

            foreach (GameEntity asset in activeScene.SceneAssets)
            {
                UnknownElementsEditor.GameProject.Transform transformComponent = (UnknownElementsEditor.GameProject.Transform)asset.GetComponent("Transform");

                asset.DrawAsset(transformComponent, writeBitMap);
            }
        }

        private void OnPlayButtonClick(object sender, RoutedEventArgs e)
        {
            assetList = dContext.ActiveScene.SceneAssets.ToList();

            viewWindow = new RunWindow();
            viewWindow.Show();
            viewWindow.Focus();
        }
    }
}
