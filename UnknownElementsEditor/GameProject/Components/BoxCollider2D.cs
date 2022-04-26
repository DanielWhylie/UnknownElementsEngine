using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;

namespace UnknownElementsEditor.GameProject
{
    [DataContract]
    public class BoxCollider2D : EntityComponent
    {
        [DataMember]
        public Vector2D TopLeftCoor { get; set; }
        [DataMember]
        public Vector2D BottomRightCoor { get; set; }

        public BoxCollider2D(GameEntity asset) : base(asset)
        {
            GameObject = asset;
            ComponentName = this.GetType().Name;

            Transform transform = (Transform)asset.GetComponent(typeof(Transform));

            TopLeftCoor = new Vector2D(transform.Position.X, transform.Position.Y);
            BottomRightCoor = new Vector2D(transform.Position.X + transform.Size.X, transform.Position.Y + transform.Size.Y);

        }

        public override void CheckCollision(Transform colliderTransform)
        {
            Transform transform = (Transform)GameObject.GetComponent(typeof(Transform));

            TopLeftCoor = new Vector2D(transform.Position.X, transform.Position.Y);
            BottomRightCoor = new Vector2D(transform.Position.X + transform.Size.X, transform.Position.Y + transform.Size.Y);

            //
            //if (rect1.x < rect2.x + rect2.w &&
            //rect1.x + rect1.w > rect2.x &&
            //rect1.y < rect2.y + rect2.h &&
            //rect1.h + rect1.y > rect2.y) {
            //    // collision detected!
            //    this.color("green");
            //}
            //rect1.x < rect2.x + rect2.w
            //rect1.x + rect1.w > rect2.x
            //rect1.y < rect2.y + rect2.h
            //rect1.h + rect1.y > rect2.y
            if (colliderTransform.Position.X <= transform.Position.X + transform.Size.X && 
                colliderTransform.Position.X + colliderTransform.Size.X <= transform.Position.X && 
                colliderTransform.Position.Y <= transform.Position.Y + transform.Size.Y && 
                colliderTransform.Position.Y + colliderTransform.Size.Y <= transform.Position.Y)
            {
                Debug.WriteLine("Yaaaaaaaaaaaaaaaaa");
                Vector2D penAmount = PenetrationAmount(transform, colliderTransform);

                transform.Position.X += penAmount.X;
                transform.Position.Y += penAmount.Y;
            }
        }

        private Vector2D PenetrationAmount(Transform transform ,Transform colliderTransform)
        {
            float leftPen = Math.Abs(transform.Position.X - (colliderTransform.Position.X + colliderTransform.Size.X));
            float rightPen = Math.Abs(colliderTransform.Position.X - (transform.Position.X + transform.Size.X));
            float topPen = Math.Abs(transform.Position.Y - (colliderTransform.Position.Y + colliderTransform.Size.Y));
            float bottomPen = Math.Abs(colliderTransform.Position.Y - (transform.Position.Y + transform.Size.Y));

            List<float> penList = new List<float>()
            {
                leftPen,
                rightPen,
                topPen,
                bottomPen
            };

            float min = penList.Min();

            if (min == leftPen)
            {
                return new Vector2D(leftPen, 0);
            }
            else if (min == rightPen)
            {
                return new Vector2D(-rightPen, 0);
            }
            else if (min == topPen)
            {
                return new Vector2D(0, topPen);
            }
            else
            {
                return new Vector2D(0, -bottomPen);
            }
        }
    }
}
