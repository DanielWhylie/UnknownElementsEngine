using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UnknownElementsEditor.GameProject
{
    [DataContract]
    class ProjectScene : ViewModelTemplate
    {
        private string _sceneName;
        [DataMember]
        public string SceneName
        {
            get => _sceneName;
            set
            {
                if (_sceneName != value)
                {
                    _sceneName = value;
                    OnPropertyChanged(nameof(SceneName));
                }
            }
        }

        [DataMember]
        public UserProject project { get; private set; }

        private bool _isActive;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    OnPropertyChanged(nameof(IsActive));
                }
            }
        }

        public ProjectScene(string sceneName, UserProject proj)
        {
            Debug.Assert(proj != null);

            SceneName = sceneName;
            project = proj;
        }
        //TODO: add list of game entities


    }
}
