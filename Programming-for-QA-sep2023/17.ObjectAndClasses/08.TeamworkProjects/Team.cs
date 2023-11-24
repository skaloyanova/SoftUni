using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.TeamworkProjects
{
    public class Team
    {
        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }

        public Team(string name, string creator)
        {
            this.Name = name;
            this.Creator = creator;
            this.Members = new List<string>();
        }

        public override string ToString()
        {
            return this.Name;
        }

        public string ListTeamMembers()
        {
            this.Members.Sort();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.Name);
            sb.AppendLine($"- {this.Creator}");
            sb.Append(string.Join(Environment.NewLine, this.Members.Select(m => $"-- {m}").ToList()));

            return sb.ToString();
        }
    }
}
