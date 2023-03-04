using Crosscutting.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crosscutting
{
    public class UsersListProjectModel : BaseEntity
    {
        public string Username { get; set; }

        public List<ProjectMOdel> FavouriteMealsIds { get; set; } = new List<ProjectMOdel>();
    }
}
