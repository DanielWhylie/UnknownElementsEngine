using System.Runtime.Serialization;

namespace UnknownElementsEditor.GameProject
{
    [DataContract]
    public class Transform : EntityComponent
    {
        [DataMember]
        public Vector2D Position { get; set; }
        [DataMember]
        public Vector2D Rotation { get; set; }
        [DataMember]
        public Vector2D Size { get; set; }
        [DataMember]
        public float Mass { get; set; }

        public Transform(GameEntity asset) : base(asset)
        {
            GameObject = asset;
            ComponentName = this.GetType().Name;
            Position = new Vector2D();
            Rotation = new Vector2D();
            Size = new Vector2D(10, 10);
            Mass = 0;
        }
    }
}
