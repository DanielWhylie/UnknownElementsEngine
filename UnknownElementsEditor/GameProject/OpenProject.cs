using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;

namespace UnknownElementsEditor.GameProject
{
    [DataContract]
    class ProjectInfo
    {
        [DataMember]
        public string projectName { get; set; }
        [DataMember]
        public string projectPath { get; set; }
        [DataMember]
        public DateTime projectDate { get; set; }
        public string fullPath
        {
            get => $@"{projectPath}{projectName}{UserProject.fileExtention}";
        }

        public byte[] screenshot { get; set; }
    }

    [DataContract]
    class ProjectInfoCollection
    {
        [DataMember]
        public List<ProjectInfo> projectInfos { get; set; }
    }

    class OpenProject
    {
        private readonly static string appInfoPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\UnknownElementsEditor\";
        private readonly static string projectInfoPath;
        private readonly static ObservableCollection<ProjectInfo> _projectInfos = new ObservableCollection<ProjectInfo>();
        public static ReadOnlyObservableCollection<ProjectInfo> ProjectInfos { get; }

        static OpenProject()
        {
            try
            {
                if (!Directory.Exists(appInfoPath))
                {
                    Directory.CreateDirectory(appInfoPath);
                }

                projectInfoPath = $@"{appInfoPath}ProjectInfo.xml";
                ProjectInfos = new ReadOnlyObservableCollection<ProjectInfo>(_projectInfos);
                ReadProjectInfo();
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
            }
        }

        private static void ReadProjectInfo()
        {
            if (File.Exists(projectInfoPath))
            {
                List<ProjectInfo> OrderednfoList = Serializer.ReadFromXml<ProjectInfoCollection>(projectInfoPath).projectInfos.OrderBy(x => x.projectName).ToList();
                _projectInfos.Clear();

                foreach (ProjectInfo info in OrderednfoList)
                {
                    if (File.Exists(info.fullPath))
                    {
                        info.screenshot = File.ReadAllBytes($@"{info.projectPath}\.UnknownElements\Screenshot.png");
                        _projectInfos.Add(info);
                    }
                }
            }
        }

        private static void WriteProjectInfo()
        {
            List<ProjectInfo> orderedProjectInfos = _projectInfos.OrderBy(x => x.projectName).ToList();

            ProjectInfoCollection infoCollection = new ProjectInfoCollection()
            {
                projectInfos = orderedProjectInfos
            };

            Serializer.WriteToXml(infoCollection, projectInfoPath);
        }

        public static UserProject OpenUserProject(ProjectInfo info)
        {
            ReadProjectInfo();
            ProjectInfo projectInfo = _projectInfos.FirstOrDefault(x => x.fullPath == info.fullPath);

            if (projectInfo == null)
            {
                projectInfo = info;
                projectInfo.projectDate = DateTime.Now;

                _projectInfos.Add(projectInfo);
            }
            else
            {
                projectInfo.projectDate = DateTime.Now;
            }

            WriteProjectInfo();

            return UserProject.LoadProject(projectInfo.fullPath);
        }
    }
}
