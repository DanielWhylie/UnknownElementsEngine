using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;

namespace UnknownElementsEditor.GameProject
{
    [DataContract]
    [KnownType(typeof(UnknownElementsEditor.GameProject.Transform))]
    [KnownType(typeof(UnknownElementsEditor.GameProject.Gravity))]
    [KnownType(typeof(UnknownElementsEditor.GameProject.BoxCollider2D))]
    public class EntityComponent : ViewModelTemplate
    {
        public string ComponentName { get; set; }
        [DataMember]
        public GameEntity GameObject { get; set; }

        public EntityComponent(GameEntity asset)
        {
            GameObject = asset;
        }

    }
}
