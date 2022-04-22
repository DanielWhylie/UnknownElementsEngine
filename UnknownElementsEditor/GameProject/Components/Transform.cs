using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UnknownElementsEditor.GameProject
{
    [DataContract]
    public class Transform : EntityComponent
    {
        [DataMember]
        public Vector2D Position { get; set; }
        [DataMember]
        public bool IsPositionConstrained { get; set; }
        [DataMember]
        public Vector2D Rotation{ get; set; }
        [DataMember]
        public bool IsRotationConstrained { get; set; }
        [DataMember]
        public Vector2D Size { get; set; }
        [DataMember]
        public bool IsSizeConstrained { get; set; }
        [DataMember]
        public float Mass { get; set; }


        public Transform(GameEntity asset) : base(asset)
        {
            ComponentName = this.GetType().Name;
            GameObject = asset;
            Position = new Vector2D();
            Rotation = new Vector2D();
            Size = new Vector2D(10, 10);
            Mass = 0;
        }
    }
}
