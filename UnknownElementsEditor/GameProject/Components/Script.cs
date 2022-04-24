using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Media.Imaging;

namespace UnknownElementsEditor.GameProject
{
    [DataContract]
    public class Script : EntityComponent
    {
        [DataMember]
        public bool IsExecutable { get; set; }
        [DataMember]
        public string scriptPath { get; set; }

        public Script(GameEntity asset) : base(asset)
        {
            GameObject = asset;
            ComponentName = this.GetType().Name;

            IsExecutable = true;
            scriptPath = "";
        }

        public override void RunScript(Transform transform, WriteableBitmap writeBitMap)
        {
            Debug.Assert(File.Exists(scriptPath));
            if (IsExecutable)
            {
                foreach (string executeLine in System.IO.File.ReadLines(scriptPath))
                {
                    string line = executeLine.ToLower();
                    string[] executeInfo = line.Split(' ');

                    switch (executeInfo[0])
                    {
                        case "right":
                            transform.Position.X += Convert.ToInt32(executeInfo[1]);
                            break;
                        case "left":
                            transform.Position.X -= Convert.ToInt32(executeInfo[1]);
                            break;
                        case "up":
                            transform.Position.Y -= Convert.ToInt32(executeInfo[1]);
                            break;
                        case "down":
                            transform.Position.Y += Convert.ToInt32(executeInfo[1]);
                            break;
                        case "end":
                            this.IsExecutable = false;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
