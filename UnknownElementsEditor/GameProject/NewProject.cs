using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UnknownElementsEditor.GameProject
{
    [DataContract]
    public class ProjectTemplate
    {
        [DataMember]
        public string projectFileName { get; set;}
        [DataMember]
        public string projectType { get; set; }
        [DataMember]
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
                    IsValidProjectPath();
                    OnPropertyChanged(nameof(ProjectName));
                }
            }
        }

        private string _projectPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\UnknownElementsProjects";
        public string ProjectPath
        {
            get => _projectPath;
            set
            {
                if (_projectPath != value)
                {
                    _projectPath = value;
                    IsValidProjectPath();
                    OnPropertyChanged(nameof(ProjectPath));
                }
            }
        }

        private bool _validPath;
        public bool ValidPath
        {
            get => _validPath;
            set
            {
                if (_validPath != value)
                {
                    _validPath = value;
                    OnPropertyChanged(nameof(ValidPath));
                }
            }
        }

        public string _ValidationErrorMsg;
        public string ValidationErrorMsg
        {
            get => _ValidationErrorMsg;
            set
            {
                if (_ValidationErrorMsg != value)
                {
                    _ValidationErrorMsg = value;
                    OnPropertyChanged(nameof(ValidationErrorMsg));
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

                    IsValidProjectPath();
                }
            }
            catch (Exception e)
            {
                //TODO: Change debug output
                Debug.WriteLine(e);
            }
        }

        private bool IsValidProjectPath()
        {
            string path = ProjectPath;

            if (!path.EndsWith(Path.DirectorySeparatorChar.ToString()) || !path.EndsWith(Path.AltDirectorySeparatorChar.ToString()))
            {
                path += Path.DirectorySeparatorChar.ToString();
            }

            path += $@"{ProjectName}";
            ValidPath = false;

            if (String.IsNullOrWhiteSpace(ProjectName.Trim()))
            {
                ValidationErrorMsg = "Enter a project name";
            }
            else if (ProjectName.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
            {
                ValidationErrorMsg = "Invalid character in project name";
            }
            else if (String.IsNullOrWhiteSpace(ProjectPath.Trim()))
            {
                ValidationErrorMsg = "Enter a project path";
            }
            else if (ProjectName.IndexOfAny(Path.GetInvalidPathChars()) != -1)
            {
                ValidationErrorMsg = "Invalid character in project path";
            }
            else if (Directory.Exists(path) && Directory.EnumerateFileSystemEntries(path).Any())
            {
                ValidationErrorMsg = "Project folder already exists and is occupied";
            }
            else
            {
                ValidationErrorMsg = String.Empty;
                ValidPath = true;
            }

            return ValidPath;
        }

        public string CreateProject(ProjectTemplate template)
        {
            IsValidProjectPath();

            if (!ValidPath)
            {
                return String.Empty;
            }

            if (!ProjectPath.EndsWith(Path.DirectorySeparatorChar.ToString()) || !ProjectPath.EndsWith(Path.AltDirectorySeparatorChar.ToString()))
            {
                ProjectPath += Path.DirectorySeparatorChar.ToString();

            }

            string path = $@"{ProjectPath}{ProjectName}{Path.DirectorySeparatorChar.ToString()}";

            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                foreach (string folderName in template.projectFolders)
                {
                    Directory.CreateDirectory(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(path), folderName)));
                }

                DirectoryInfo pathInfo = new DirectoryInfo(path + @".UnknownElements\");
                pathInfo.Attributes |= FileAttributes.Hidden;

                File.Copy(template.projectScreenshotPath, Path.GetFullPath(Path.Combine(pathInfo.FullName, "Screenshot.png")));

                string xmlProject = File.ReadAllText(template.projectFilePath);
                xmlProject = String.Format(xmlProject, ProjectName, ProjectPath);
                string projectPath = Path.GetFullPath(Path.Combine(path, $"{ProjectName}{UserProject.fileExtention}"));
                File.WriteAllText(projectPath, xmlProject);

                return path;
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
                return String.Empty;
            }
        }

    }
}
