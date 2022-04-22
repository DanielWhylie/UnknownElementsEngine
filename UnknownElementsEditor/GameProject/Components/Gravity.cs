using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }


        public void AddGravityToObject(Transform transform)
        {
            if (!IsWeightless)
            {
                transform.Position.Y += (transform.Mass * Acceleration);
            }
        }
    }
}
