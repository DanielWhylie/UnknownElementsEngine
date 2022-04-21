using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace UnknownElementsEditor.GameProject
{
    public class Square : GameEntity
    {
        public bool IsVisable;
        public Color SquareColor;

        public Square()
        {
            IsVisable = true;
        }

        public Square(ProjectScene scene, string name)
        {
            EntityName = name;
            AttachedScene = scene;
            IsVisable = true;
        }
    }

}
