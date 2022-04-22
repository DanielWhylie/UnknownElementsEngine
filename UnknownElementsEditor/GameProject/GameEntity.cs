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
    public class GameEntity : ViewModelTemplate
    {
        private string _entityName;
        [DataMember]
        public string EntityName{
            get => _entityName;
            set
            {
                if (_entityName != value)
                {
                    _entityName = value;
                    OnPropertyChanged(nameof(EntityName));
                }
            }
        }
        [DataMember]
        public GameEntity EntityType { get; set; }
        [DataMember]
        public ProjectScene AttachedScene { get; set; }
        [DataMember(Name = "Components")]
        private ObservableCollection<EntityComponent> _entityComponents = new ObservableCollection<EntityComponent>();
        public ReadOnlyObservableCollection<EntityComponent> EntityComponents { get; private set; }

        public GameEntity()
        {
            EntityType = this;

            EntityName = null;
            AttachedScene = null;

            OnDesirialized(new StreamingContext());
            _entityComponents.Add(new Transform(this));
        }

        public GameEntity(ProjectScene scene, string name)
        {
            EntityName = name;
            AttachedScene = scene;
            EntityType = this;

            OnDesirialized(new StreamingContext());
            _entityComponents.Add(new Transform(this));
        }

        public void AddComponentToEntity()
        {
            _entityComponents.Add(new EntityComponent(this));
        }

        public void RemoveComponentFromEntity(EntityComponent component)
        {
            Debug.Assert(_entityComponents.Contains(component));

            _entityComponents.Remove(component);
        }

        [OnDeserialized]
        private void OnDesirialized(StreamingContext streamingContext)
        {
            if (_entityComponents != null)
            {
                EntityComponents = new ReadOnlyObservableCollection<EntityComponent>(_entityComponents);
                OnPropertyChanged(nameof(EntityComponents));
            }
        }
    }
}
