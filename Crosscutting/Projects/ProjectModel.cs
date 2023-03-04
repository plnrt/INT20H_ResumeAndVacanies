using Crosscutting.Rating;

namespace Crosscutting.Projects
{
    public class ProjectModel : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string OwnerUsername { get; set; }

        public string MembersUsernames { get; set; }

        public double Rating { get; set; }

        //public List<Rate> Rates { get; set; }

        public string Category { get; set; }
    }
}
