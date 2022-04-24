using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace UnknownElementsEditor.GameProject
{
    [DataContract]
    public class BoxCollider2D : EntityComponent
    {
        [DataMember]
        public Vector2D Position { get; set; }
        [DataMember]
        public Vector2D Rotation { get; set; }
        [DataMember]
        public Vector2D Size { get; set; }

        public BoxCollider2D(GameEntity asset) : base(asset)
        {
            GameObject = asset;
            ComponentName = this.GetType().Name;
            Position = new Vector2D();
            Rotation = new Vector2D();
            Size = new Vector2D(10, 10);
        }
    }
}
