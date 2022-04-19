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
    class UserProject : ViewModelTemplate
    {
        public static string fileExtention { get; } = ".unknownelements";
        [DataMember]
        public string projectName { get; private set; } = "project";
        [DataMember]
        public string projectPath { get; private set; }
        public string fullProjectPath => $@"{projectPath}{projectName}{fileExtention}";
        [DataMember(Name = "Scenes")]
        private ObservableCollection<ProjectScene> _projectScenes = new ObservableCollection<ProjectScene>();
        public ReadOnlyObservableCollection<ProjectScene> ProjectScenes { get; private set; }
        public static UserProject currentLoadedProject = (UserProject)Application.Current.MainWindow.DataContext;
        public ProjectScene _activeScene;
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
            currentLoadedProject = null;
        }

        [OnDeserialized]
        private void OnDesirialized(StreamingContext streamingContext)
        {
            if (_projectScenes != null)
            {
                ProjectScenes = new ReadOnlyObservableCollection<ProjectScene>(_projectScenes);
                OnPropertyChanged(nameof(ProjectScenes));
                ActiveScene = ProjectScenes.FirstOrDefault(x => x.IsActive);
            }
        }
    }
}
