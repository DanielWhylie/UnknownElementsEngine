using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UnknownElementsEditor.GameProject
{
    [DataContract]
    public class ProjectScene : ViewModelTemplate
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

        [DataMember(Name = "Assets")]
        private ObservableCollection<GameEntity> _sceneAssets= new ObservableCollection<GameEntity>();
        public ReadOnlyObservableCollection<GameEntity> SceneAssets { get; private set; }

        public ProjectScene(string sceneName, UserProject proj)
        {
            Debug.Assert(proj != null);

            SceneName = sceneName;
            project = proj;

            OnDesirialized(new StreamingContext());
        }
        //TODO: add list of game entities

        public void AddAssetToScene(string name)
        {
            Debug.Assert(!String.IsNullOrWhiteSpace(name));

            GameEntity newAsset = new GameEntity(this, name);

            Debug.Assert(!_sceneAssets.Contains(newAsset));

            _sceneAssets.Add(new GameEntity(this, name));
        }

        public void RemoveAssetFromScene(GameEntity asset)
        {
            Debug.Assert(_sceneAssets.Contains(asset));

            _sceneAssets.Remove(asset);
        }

        [OnDeserialized]
        private void OnDesirialized(StreamingContext streamingContext)
        {
            if (_sceneAssets != null)
            {
                SceneAssets = new ReadOnlyObservableCollection<GameEntity>(_sceneAssets);
                OnPropertyChanged(nameof(SceneAssets));
            }
        }
    }
}
