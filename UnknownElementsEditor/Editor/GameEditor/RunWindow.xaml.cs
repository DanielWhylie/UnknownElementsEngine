using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using UnknownElementsEditor.GameProject;

namespace UnknownElementsEditor.Editor.GameEditor
{
    /// <summary>
    /// Interaction logic for RunWindow.xaml
    /// </summary>
    public partial class RunWindow : Window
    {
        public UserProject dContext;

        public RunWindow()
        {
            InitializeComponent();
            Loaded += OnRunViewLoaded;
        }

        private void OnRunViewLoaded(object sender, RoutedEventArgs e)
        {
            Window main = Application.Current.MainWindow;

            Debug.Assert(main.DataContext != null);
            DataContext = main.DataContext;
            dContext = (UserProject)main.DataContext;
        }

        public int GraphicViewWidth;
        public int GraphicViewHeight;
        public WriteableBitmap writeBitMap;

        public List<GameEntity> AssetsToRun = new List<GameEntity>();
        public ProjectScene activeScene;

        public void StartGraphics(object sender, RoutedEventArgs e)
        {

            GraphicViewWidth = (int)viewPort.Width;
            GraphicViewHeight = (int)viewPort.Height;

            writeBitMap = BitmapFactory.New(GraphicViewWidth, GraphicViewHeight);
            viewPort.Source = writeBitMap;

            activeScene = dContext.ActiveScene;

            foreach (GameEntity asset in activeScene.SceneAssets)
            {
                GameEntity newAsset;

                if (asset.EntityType.ToLower() == "Square".ToLower())
                {
                    newAsset = new Square((Square)asset);
                }
                else if (asset.EntityType.ToLower() == "Circle".ToLower())
                {
                    newAsset = new Circle((Circle)asset);
                }
                else
                {
                    newAsset = new GameEntity();
                }

                AssetsToRun.Add(newAsset);
            }

            CompositionTarget.Rendering += Rendering;
        }

        private void Rendering(object sender, EventArgs e)
        {
            writeBitMap.Clear();
            foreach (GameEntity asset in AssetsToRun)
            {
                asset.DrawAsset((UnknownElementsEditor.GameProject.Transform)asset.GetComponent(typeof(UnknownElementsEditor.GameProject.Transform)), writeBitMap);

                UnknownElementsEditor.GameProject.Transform assetTransform = (UnknownElementsEditor.GameProject.Transform)asset.GetComponent(typeof(UnknownElementsEditor.GameProject.Transform));
                UnknownElementsEditor.GameProject.Script assetScript = (UnknownElementsEditor.GameProject.Script)asset.GetComponent(typeof(Script));

                foreach (var item in asset.EntityComponents)
                {
                    if (item.ComponentName == "Gravity")
                    {
                        asset.GetComponent(typeof(Gravity)).AddGravityToObject(assetTransform);
                    }
                    else if (item.ComponentName == "Script")
                    {
                        asset.GetComponent(typeof(Script)).RunScript(assetTransform, writeBitMap);
                    }
                }
            }
        }
    }
}
