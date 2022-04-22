using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Runtime.Serialization;

namespace UnknownElementsEditor.GameProject
{
    [DataContract]
    public class Circle : GameEntity
    {
        [DataMember]
        public bool IsVisable { get; set; }
        [DataMember]
        public Color SquareColor { get; set; }
        [DataMember]
        public float Radius { get; set; }
        [DataMember]
        public bool IsFilled { get; set; }

        public Circle()
        {
            IsVisable = true;
            Radius = 10;
        }

        public Circle(ProjectScene scene, string name)
        {
            EntityName = name;
            AttachedScene = scene;
            IsVisable = true;
            Radius = 10;
        }
    }
}
