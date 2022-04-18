using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace UnknownElementsEditor.GameProject
{
    [DataContract(Name = "Game")]
    class UserProject : ViewModelTemplate
    {
        public static string fileExtention { get; } = ".unknownelements";
        [DataMember]
        public string projectName { get; private set; }
        [DataMember]
        public string projectPath { get; private set; }
        public string fullProjectPath => $@"{projectPath}{projectName}{fileExtention}";
        [DataMember(Name = "Scenes")]
        private ObservableCollection<ProjectScene> _projectScenes = new ObservableCollection<ProjectScene>();
        public ReadOnlyObservableCollection<ProjectScene> ProjectScenes { get; }

        public UserProject(string name, string path)
        {
            projectName = name;
            projectPath = path;

            _projectScenes.Add(new ProjectScene("First Scene", this));
        }
    }
}
