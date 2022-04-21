using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnknownElementsEditor.GameProject
{
    public class EntityComponent
    {
        public GameEntity GameObject { get; set; }

        public EntityComponent()
        {
            GameObject = null;
        }

        public EntityComponent(GameEntity asset)
        {
            GameObject = asset;
        }
    }
}
