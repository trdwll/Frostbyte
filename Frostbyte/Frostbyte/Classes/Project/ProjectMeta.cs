using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frostbyte.Classes.Project
{
    class ProjectMeta
    {
        public readonly Dictionary<string, string> variables = new Dictionary<string, string>();

        public ProjectMeta(Project project, string fileName)
        {
            variables.Add("{ProjectName}", project.ProjectName);
            variables.Add("{FileName}", fileName);
            variables.Add("{Year}", DateTime.Now.Year.ToString());
            variables.Add("{DateCreated}", DateTime.Now.ToString("ddMMMyyyy").ToUpper());
            variables.Add("{Author}", Environment.UserName);
        }

        public string ParseFileContents(string Contents)
        {
            foreach (KeyValuePair<string, string> Entry in variables)
            {
                Contents = Contents.Replace(Entry.Key, Entry.Value);
            }

            return Contents;
        }
    }
}
