using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Windows;
using System.Diagnostics;
using System.IO;

namespace UnknownElementsEditor.GameProject
{
    [DataContract(Name = "Game")]
    public class UserProject : ViewModelTemplate
    {
        public static string fileExtention { get; } = ".unknownelements";
        [DataMember]
        public string projectName { get; private set; } = "project";
        [DataMember]
        public string projectPath { get; private set; }
        public string fullProjectPath => $@"{projectPath}{projectName}{Path.DirectorySeparatorChar.ToString()}{projectName}{UserProject.fileExtention}";
        [DataMember(Name = "Scenes")]
        private ObservableCollection<ProjectScene> _projectScenes = new ObservableCollection<ProjectScene>();
        public ReadOnlyObservableCollection<ProjectScene> projectScenes { get; private set; }
        public static UserProject currentLoadedProject = (UserProject)Application.Current.MainWindow.DataContext;
        private ProjectScene _activeScene;
        [DataMember]
        public ProjectScene ActiveScene
        {
            get => _activeScene;
            set
            {
                if (_activeScene != value)
                {
                    _activeScene = value;
                    OnPropertyChanged(nameof(ActiveScene));
                }
            }
        }

        public UserProject(string name, string path)
        {
            projectName = name;
            projectPath = path;

            OnDesirialized(new StreamingContext());
        }

        public static UserProject LoadProject(string file)
        {
            Debug.Assert(File.Exists(file));
            UserProject project = Serializer.ReadFromXml<UserProject>(file);

            return project;
        }

        public static void SaveProject(UserProject project)
        {
            Serializer.WriteToXml(project, project.fullProjectPath);
        }

        public void UnloadProject()
        {

        }

        public void AddSceneToProject(string name)
        {
            Debug.Assert(!String.IsNullOrWhiteSpace(name));

            _projectScenes.Add(new ProjectScene(name, this));
        }

        public void RemoveSceneFromProject(ProjectScene scene)
        {
            Debug.Assert(_projectScenes.Contains(scene));

            _projectScenes.Remove(scene);
        }

        [OnDeserialized]
        private void OnDesirialized(StreamingContext streamingContext)
        {
            if (_projectScenes != null)
            {
                projectScenes = new ReadOnlyObservableCollection<ProjectScene>(_projectScenes);
                OnPropertyChanged(nameof(projectScenes));
                ActiveScene = projectScenes.FirstOrDefault(x => x.IsActive);
            }
        }
    }
}
