using System.ComponentModel;
using System.Runtime.Serialization;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace UnknownElementsEditor.GameProject
{
    [DataContract]
    public class Square : GameEntity
    {
        [DataMember]
        public bool IsVisable { get; set; }
        [DataMember]
        [DefaultValue(typeof(Color), "Black")]
        public Color assetColor { get; set; }

        public Square(ProjectScene scene, string name) : base(scene, name)
        {
            EntityName = name;
            AttachedScene = scene;
            IsVisable = true;
            assetColor = Colors.Blue;
        }

        public Square(Square entity) : base(entity.AttachedScene, entity.EntityName)
        {
            EntityName = entity.EntityName;
            AttachedScene = entity.AttachedScene;
            IsVisable = entity.IsVisable;
            assetColor = entity.assetColor;

            this.RemoveComponentFromEntity(this.GetComponent(typeof(UnknownElementsEditor.GameProject.Transform)));

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

            if (assetColor != Colors.Black)
            {
                writeBitMap.FillRectangle((int)transformComponent.Position.X, (int)transformComponent.Position.Y, (int)transformComponent.Position.X + (int)transformComponent.Size.X, (int)transformComponent.Position.Y + (int)transformComponent.Size.Y, assetColor);
                return;
            }

            writeBitMap.FillRectangle((int)transformComponent.Position.X, (int)transformComponent.Position.Y, (int)transformComponent.Position.X + (int)transformComponent.Size.X, (int)transformComponent.Position.Y + (int)transformComponent.Size.Y, Colors.Black);
        }
    }

}
