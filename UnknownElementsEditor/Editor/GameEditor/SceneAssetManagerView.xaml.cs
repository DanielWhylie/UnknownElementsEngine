using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using UnknownElementsEditor.GameProject;

namespace UnknownElementsEditor.Editor.GameEditor
{
    /// <summary>
    /// Interaction logic for SceneAssetManagerView.xaml
    /// </summary>
    public partial class SceneAssetManagerView : UserControl
    {
        public SceneAssetManagerView()
        {
            InitializeComponent();
        }

        public void OnSelectionChange(Object sender, SelectionChangedEventArgs e)
        {
            UserProject dContext = (UserProject)DataContext;

            ProjectScene scene = dContext.projectScenes[activateSceneComboBox.SelectedIndex];

            foreach (ProjectScene item in dContext.projectScenes)
            {
                if (item == scene)
                {
                    dContext.ActiveScene = item;
                    scene.IsActive = true;
                }
                else
                {
                    item.IsActive = false;
                }
            }
        }

        public void OnAddSceneButtonClick(Object sender, RoutedEventArgs e)
        {
            if (sender == addSceneButton)
            {
                UserProject dContext = (UserProject)DataContext;

                dContext.AddSceneToProject("Scene " + dContext.projectScenes.Count());
            }
        }

        public void OnRemoveSceneButtonClick(Object sender, RoutedEventArgs e)
        {
            UserProject dContext = (UserProject)DataContext;

            Button removeButton = (Button)sender;

            dContext.RemoveSceneFromProject((ProjectScene)removeButton.Tag);
        }

        public void OnAssetAdd(Object sender, RoutedEventArgs e)
        {
            MenuItem addAssetButton = (MenuItem)sender;
            ProjectScene scene = (ProjectScene)addAssetButton.Tag;
            Debug.Assert(!String.IsNullOrWhiteSpace(addAssetButton.Header.ToString()));

            if (addAssetButton.Header.ToString() == "Square")
            {
                scene.AddAssetToScene(new Square(scene, addAssetButton.Header.ToString()));
            }
            else if (addAssetButton.Header.ToString() == "Circle")
            {
                scene.AddAssetToScene(new Circle(scene, addAssetButton.Header.ToString()));
            }
        }
        public void OnRemoveAssetButtonClick(Object sender, RoutedEventArgs e)
        {
            Button removeButton = (Button)sender;
            GameEntity dContext = (GameEntity)removeButton.Tag;
            
            //errors when asset is removed from an non active scene FIXED
            dContext.AttachedScene.RemoveAssetFromScene((GameEntity)removeButton.Tag);
        }

        public void OnAssetListBoxSelectionChange(Object sender, EventArgs e)
        {
            ListBox entityListBox = (ListBox)sender;

            var asset = entityListBox.SelectedItem;
            PropertyManagerView.propertyViewInstance.DataContext = asset;
        }
    }
}
