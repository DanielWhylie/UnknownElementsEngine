using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnknownElementsEditor
{
    public class Vector2D
    {
        public float X;
        public float Y;

        public Vector2D(float vectorX = 0, float vectorY = 0)
        {
            X = vectorX;
            Y = vectorY;
        }

        public static float Distance(Vector2D vector, Vector2D distanceToVector)
        {
            float d;

            float x = (float)Math.Pow(distanceToVector.X - vector.X, 2) + (float)Math.Pow(distanceToVector.X - vector.X, 2);

            d = (float)Math.Sqrt(x);

            return d;
        }
    }
}
