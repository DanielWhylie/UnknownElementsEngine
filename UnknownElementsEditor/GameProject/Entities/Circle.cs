using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Runtime.Serialization;
using System.Windows.Media.Imaging;

namespace UnknownElementsEditor.GameProject
{
    [DataContract]
    public class Circle : GameEntity
    {
        [DataMember]
        public bool IsVisable { get; set; }
        [DataMember]
        public Color assetColor { get; set; }
        [DataMember]
        public bool IsFilled { get; set; }

        public Circle(ProjectScene scene, string name)
        {
            EntityName = name;
            AttachedScene = scene;
            IsVisable = true;
            assetColor = Colors.Red;
        }

        public Circle(Circle entity) : base(entity.AttachedScene, entity.EntityName)
        {
            EntityName = entity.EntityName;
            AttachedScene = entity.AttachedScene;
            IsVisable = entity.IsVisable;
            assetColor = entity.assetColor;

            this.RemoveComponentFromEntity(this.GetComponent("Transform"));

            foreach (var item in entity.EntityComponents)
            {
                this.AddComponentToEntity(item);
            }
        }

        public override void DrawAsset(UnknownElementsEditor.GameProject.Transform transformComponent, WriteableBitmap writeBitMap)
        {
            if (!IsVisable)
            {
                return;
            }

            if (assetColor != null)
            {
                writeBitMap.FillEllipse((int)transformComponent.Position.X, (int)transformComponent.Position.Y, (int)transformComponent.Position.X + (int)transformComponent.Size.X, (int)transformComponent.Position.Y + (int)transformComponent.Size.Y, assetColor);
                return;
            }

            writeBitMap.FillEllipse((int)transformComponent.Position.X, (int)transformComponent.Position.Y, (int)transformComponent.Position.X + (int)transformComponent.Size.X, (int)transformComponent.Position.Y + (int)transformComponent.Size.Y, Colors.Black);
        }
    }
}
