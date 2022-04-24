using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
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
            UserProject dContext = DataContext as UserProject;

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
                UserProject dContext = DataContext as UserProject;

                dContext.AddSceneToProject("Scene " + dContext.projectScenes.Count());
            }
        }

        public void OnRemoveSceneButtonClick(Object sender, RoutedEventArgs e)
        {
            UserProject dContext = DataContext as UserProject;

            Button removeButton = sender as Button;

            dContext.RemoveSceneFromProject(removeButton.Tag as ProjectScene);
        }

        public void OnAssetAdd(Object sender, RoutedEventArgs e)
        {
            MenuItem addAssetButton = sender as MenuItem;
            ProjectScene scene = addAssetButton.Tag as ProjectScene;
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
            UserProject dContext = DataContext as UserProject;

            Button removeButton = sender as Button;

            dContext.ActiveScene.RemoveAssetFromScene(removeButton.Tag as GameEntity);
        }

        public void OnAssetListBoxSelectionChange(Object sender, SelectionChangedEventArgs e)
        {
            ListBox entityListBox = sender as ListBox;

            var asset = entityListBox.SelectedItem;
            PropertyManagerView.propertyViewInstance.DataContext = asset;
        }
    }
}
