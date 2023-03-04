using Crosscutting.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crosscutting.Projects
{
    public class ProjectModel : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string OwnerUsername { get; set; }

        public List<string> MembersUsernames { get; set; }

        public double Rating { get; set; }

        public List<Rate> Rates { get; set; }
     }
}
