using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace UnknownElementsEditor.GameProject
{
    public class ProjectTemplate
    {
        public string projectFileName { get; set;}
        public string projectType { get; set; }
        public List<String> projectFolders { get; set; }
        public byte[] projectScreenshot { get; set; }
        public string projectScreenshotPath { get; set; }
        public string projectFilePath { get; set; }

    }

    class NewProject : ViewModelTemplate
    {
        private readonly string _templatePath = @"..\..\..\..\UnknownElementsEditor\UnknownElementsEditor\ProjectTemplates";

        private string _projectName = "NewProject";
        public string ProjectName
        {
            get => _projectName;
            set
            {
                if (_projectName != value)
                {
                    _projectName = value;
                    OnPropertyChanged(nameof(ProjectName));
                }
            }
        }

        private string _projectPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\UnknownElements";
        public string ProjectPath
        {
            get => _projectPath;
            set
            {
                if (_projectPath != value)
                {
                    _projectPath = value;
                    OnPropertyChanged(nameof(ProjectPath));
                }
            }
        }

        private ObservableCollection<ProjectTemplate> _projectTemplates = new ObservableCollection<ProjectTemplate>();
        public ReadOnlyObservableCollection<ProjectTemplate> ProjectTemplates { get; }

        public NewProject()
        {
            ProjectTemplates = new ReadOnlyObservableCollection<ProjectTemplate>(_projectTemplates);

            try
            {
                String[] templateFiles = Directory.GetFiles(_templatePath, "template.xml", SearchOption.AllDirectories);
                
                Debug.Assert(templateFiles.Any());

                foreach (string file in templateFiles)
                {
                    //ProjectTemplate emptyTemplate = new ProjectTemplate()
                    //{
                    //    projectFileName = "tempProjectName.unknownelements",
                    //    projectType = "Empty 2D Project",
                    //    projectFolders = new List<string>() { ".UnknownElements", "Content", "GameCode" }
                    //};

                    //Serializer.WriteToXml(emptyTemplate, file);

                    ProjectTemplate template = Serializer.ReadFromXml<ProjectTemplate>(file);

                    template.projectFilePath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(file), template.projectFileName));

                    template.projectScreenshotPath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(file), "Screenshot.png"));
                    template.projectScreenshot = File.ReadAllBytes(template.projectScreenshotPath);

                    _projectTemplates.Add(template);

                }
            }
            catch (Exception e)
            {
                //TODO: Change debug output
                Debug.WriteLine(e);
            }
        }

    }
}
