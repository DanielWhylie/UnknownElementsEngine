using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.Diagnostics;

namespace UnknownElementsEditor.GameProject
{
    [DataContract]
    [KnownType(typeof(UnknownElementsEditor.GameProject.Transform))]
    [KnownType(typeof(UnknownElementsEditor.GameProject.Gravity))]
    [KnownType(typeof(UnknownElementsEditor.GameProject.BoxCollider2D))]
    [KnownType(typeof(UnknownElementsEditor.GameProject.Script))]
    public class EntityComponent : ViewModelTemplate
    {
        [DataMember]
        public string ComponentName { get; set; }
        [DataMember]
        public GameEntity GameObject { get; set; }

        public EntityComponent(GameEntity asset)
        {
            GameObject = asset;
        }

        public virtual void AddGravityToObject(Transform transform) { }
        public virtual void RunScript(Transform transform, WriteableBitmap writeBitMap) { }
    }
}
