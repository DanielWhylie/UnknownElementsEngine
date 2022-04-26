using System.Runtime.Serialization;

namespace UnknownElementsEditor.GameProject
{
    [DataContract]
    public class Gravity : EntityComponent
    {
        [DataMember]
        public bool IsWeightless { get; set; }
        [DataMember]
        public float Acceleration { get; set; }

        public Gravity(GameEntity asset) : base(asset)
        {
            GameObject = asset;
            ComponentName = this.GetType().Name;
            IsWeightless = false;
            Acceleration = 1;
        }

        public override void AddGravityToObject(Transform transform)
        {
            if (!IsWeightless)
            {
                transform.Position.Y += transform.Mass * Acceleration;
            }
        }
    }
}
