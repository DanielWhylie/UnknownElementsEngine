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
                if(item.ComponentName == "Transform")
                {
                    UnknownElementsEditor.GameProject.Transform oldTran = (UnknownElementsEditor.GameProject.Transform)item;
                    UnknownElementsEditor.GameProject.Transform newTran = new UnknownElementsEditor.GameProject.Transform(this);

                    newTran.Position = new Vector2D(oldTran.Position.X, oldTran.Position.Y);
                    newTran.Rotation = new Vector2D(oldTran.Rotation.X, oldTran.Rotation.Y);
                    newTran.Size = new Vector2D(oldTran.Size.X, oldTran.Size.Y);
                    newTran.Mass = oldTran.Mass;
                    this.AddComponentToEntity(newTran);
                }
                else
                {
                    this.AddComponentToEntity(item);
                }
            }
        }

        public override void DrawAsset(UnknownElementsEditor.GameProject.Transform transformComponent, WriteableBitmap writeBitMap)
        {

            if (!IsVisable || transformComponent == null)
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
