using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using System.Windows.Shapes;
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
            dContext = main.DataContext as UserProject;
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
                asset.DrawAsset((UnknownElementsEditor.GameProject.Transform)asset.GetComponent("Transform"), writeBitMap);

                UnknownElementsEditor.GameProject.Transform assetTransform = (UnknownElementsEditor.GameProject.Transform)asset.GetComponent("Transform");
                UnknownElementsEditor.GameProject.Script assetScript = (UnknownElementsEditor.GameProject.Script)asset.GetComponent("Script");

                foreach (var item in asset.EntityComponents)
                {
                    if (item.ComponentName == "Gravity")
                    {
                        asset.GetComponent("Gravity").AddGravityToObject(assetTransform);
                    }
                    else if (item.ComponentName == "Script")
                    {
                        asset.GetComponent("Script").RunScript(assetTransform, writeBitMap);
                    }
                }
            }
        }
    }
}
