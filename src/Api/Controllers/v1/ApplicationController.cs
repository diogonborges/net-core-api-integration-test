using DAL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/applications")]
    public class ApplicationController : Controller
    {
        private readonly Context context;

        public ApplicationController(Context context)
        {
            this.context = context;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var application = await context.Applications.FirstOrDefaultAsync(x=>x.Name == name);
            return Ok(application);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var applications = await context.Applications.ToListAsync();
            return Ok(applications);
        }
    }
}
