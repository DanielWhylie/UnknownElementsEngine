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
        public BoxCollider2D(GameEntity asset) : base(asset)
        {
            GameObject = asset;
        }
    }
}
