using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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
            //Fixed error where program crashes as DataContext is null after forcibly exiting ProjectBrowserWin.xaml
            if (DataContext == null)
            {
                Environment.Exit(0);
            }
            dContext = (UserProject)DataContext;
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
                UnknownElementsEditor.GameProject.Transform transformComponent = (UnknownElementsEditor.GameProject.Transform)asset.GetComponent(typeof(UnknownElementsEditor.GameProject.Transform));

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
