using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewTestHashavimWeb.Helper;

namespace NewTestHashavimWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly DllService _dllService;

        public OrganizationController(DllService dllService)
        {
            _dllService = dllService;
        }


        [HttpGet("GetWorkerList")]
        public IActionResult GetWorkerList()
        {
            object organizationServiceInstance = _dllService.CreateInstance("Services.OrganizationService");

            var workers = _dllService.InvokeMethod(organizationServiceInstance, "GetWorkerList");

            return Ok(workers);
        }
    }
}
