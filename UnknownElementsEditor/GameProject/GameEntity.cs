using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Windows.Media.Imaging;

namespace UnknownElementsEditor.GameProject
{
    [DataContract]
    [KnownType(typeof(UnknownElementsEditor.GameProject.Circle))]
    [KnownType(typeof(UnknownElementsEditor.GameProject.Square))]
    public class GameEntity : ViewModelTemplate
    {
        private string _entityName;
        [DataMember]
        public string EntityName
        {
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
        public string EntityType { get; set; }
        [DataMember]
        public ProjectScene AttachedScene { get; set; }
        [DataMember(Name = "Components")]
        private ObservableCollection<EntityComponent> _entityComponents = new ObservableCollection<EntityComponent>();
        public ReadOnlyObservableCollection<EntityComponent> EntityComponents { get; private set; }

        public GameEntity()
        {
            EntityType = this.EntityName;

            EntityName = null;
            AttachedScene = null;

            OnDesirialized(new StreamingContext());
            _entityComponents.Add(new Transform(this));

        }

        public GameEntity(ProjectScene scene, string name)
        {
            EntityName = name;
            AttachedScene = scene;
            EntityType = this.EntityName;

            OnDesirialized(new StreamingContext());
            _entityComponents.Add(new Transform(this));

        }

        public void AddComponentToEntity(EntityComponent component)
        {
            Debug.Assert(component != null);

            _entityComponents.Add(component);
        }

        public void RemoveComponentFromEntity(EntityComponent component)
        {
            Debug.Assert(_entityComponents.Contains(component));

            _entityComponents.Remove(component);
        }

        public EntityComponent GetComponent(Type componentToFind)
        {
            foreach (EntityComponent component in _entityComponents)
            {
                if (component.GetType() == componentToFind)
                {
                    return component;
                }
            }

            return null;
        }

        public virtual void DrawAsset(UnknownElementsEditor.GameProject.Transform transformComponent, WriteableBitmap writeBitMap) { }

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
