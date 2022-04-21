using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UnknownElementsEditor.GameProject
{
    [DataContract]
    public class GameEntity
    {
        [DataMember]
        public string EntityName;

        [DataMember]
        public GameEntity EntityType { get; set; }
        [DataMember]
        public ProjectScene AttachedScene { get; set; }
        [DataMember]
        public Vector2D EntityPosition { get; set; }
        [DataMember]
        public Vector2D EntitySize { get; set; }
        [DataMember]
        public float EntityMass { get; set; }

        public GameEntity()
        {
            EntityType = this;

            EntityName = null;
            AttachedScene = null;
            EntityPosition = null;
            EntitySize = null;
            EntityMass = 0;
        }

        public GameEntity(ProjectScene scene, string name)
        {
            EntityName = name;
            AttachedScene = scene;
            EntityPosition = new Vector2D();
            EntitySize = new Vector2D(10, 10);
            EntityType = this;
            EntityMass = 0;
        }

    }
}
