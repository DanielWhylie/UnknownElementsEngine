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
    public class Square : GameEntity
    {
        [DataMember]
        public bool IsVisable { get; set; }
        [DataMember]
        public Color SquareColor { get; set; }
        [DataMember]
        public Vector2D Size { get; set; }

        public Square()
        {
            IsVisable = true;
            Size = new Vector2D(10, 10);
        }

        public Square(ProjectScene scene, string name) : base(scene, name)
        {
            EntityName = name;
            AttachedScene = scene;
            IsVisable = true;
            Size = new Vector2D(10, 10);
        }
    }

}
