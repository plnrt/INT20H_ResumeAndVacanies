using Crosscutting;
using Crosscutting.Projects;
using Crosscutting.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SqlLiteManager;
using System.Globalization;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace INT20H_ResumeAndVacanies.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly ILogger<DataController> _logger;

        private readonly IConfiguration _configuration;

        private readonly ISqliteRepositoryManager _sqliteRepositoryManager;
        public DataController (ILogger<DataController> logger, ISqliteRepositoryManager sqliteRepositoryManager, IConfiguration configuration)
        {
            this._logger = logger;
            this._sqliteRepositoryManager = sqliteRepositoryManager;
            this._configuration = configuration;
        }

        [HttpGet]
        //[Authorize]
        [Route("allProjects")]
        public async Task<List<ProjectEntity>> GetAllProjects()
        {
            var res = await this._sqliteRepositoryManager.QueryAll<ProjectEntity>().ConfigureAwait(false);
            return res.ToList();
        }

        [HttpGet]
        //[Authorize]
        [Route("project")]
        public async Task<ProjectModel> GetAllProjects(string id)
        {
            var entity = await this._sqliteRepositoryManager.Load<ProjectEntity>(id).ConfigureAwait(false);

            var result = new ProjectModel() {Name = entity.Name, Category = entity.Category, Description = entity.Description, Guid = entity.Guid, Created = entity.Created, Rating = entity.Rating, MembersUsernames = entity.MembersUsernames, OwnerUsername = entity.OwnerUsername };

            return result ;//..res.ToList();
        }


        [HttpPost]
        //[Authorize]
        [Route("project")]
        public async Task CreateProjects(ProjectModel model)
        {
            this.NormalizeModel(model);

            var entity = new ProjectEntity() { Name = model.Name, Category = model.Category, Description = model.Description, Guid = model.Guid, Created = model.Created, Rating = model.Rating, MembersUsernames = model.MembersUsernames, OwnerUsername = model.OwnerUsername };
            await this._sqliteRepositoryManager.Create<ProjectEntity>(entity).ConfigureAwait(false);
        }

        [HttpPut]
        //[Authorize]
        [Route("project")]
        public async Task UpdateProjects(ProjectModel model)
        {
            if (string.IsNullOrEmpty(model.Guid))
            {
                throw new Exception("Guid is null");
            }
            var entity = new ProjectEntity() { Name = model.Name, Category = model.Category, Description = model.Description, Guid = model.Guid, Created = model.Created, Rating = model.Rating, MembersUsernames = model.MembersUsernames, OwnerUsername = model.OwnerUsername };
            await this._sqliteRepositoryManager.Update<ProjectEntity>(entity, entity.Guid).ConfigureAwait(false);
        }

        [HttpDelete]
        //[Authorize]
        [Route("project")]
        public async Task DeleteProjects(string guid)
        {
            if (string.IsNullOrEmpty(guid))
            {
                throw new Exception("Guid is null");
            }
            await this._sqliteRepositoryManager.Delete<ProjectEntity>(guid).ConfigureAwait(false);
        }


        private void NormalizeModel<T>(T model) where T : BaseEntity
        {
            model.Guid = Guid.NewGuid().ToString();
            model.Created = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
        }

        private string GenerateGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}