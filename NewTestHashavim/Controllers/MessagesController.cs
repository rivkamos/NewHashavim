using Microsoft.AspNetCore.Mvc;
using NewTestHashavimWeb.Helper;

namespace NewTestHashavim.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly DllService _dllService;
        private readonly string _className = "Services.MessageService";
        public MessagesController(DllService dllService)
        {
            _dllService = dllService;
        }

        [HttpPost("SendMessage/{workerId}")]
        public IActionResult SendMessage(int workerId, [FromBody] string message)
        {
            var instance = _dllService.CreateInstance(_className);
            _dllService.InvokeMethod(instance, "SendMessage", workerId, message);
            return Ok();
        }

        [HttpGet("GetMessages/{workerId}")]
        public IActionResult GetMessages(int workerId)
        {
            var instance = _dllService.CreateInstance(_className);
            var result = _dllService.InvokeMethod(instance, "GetMessages", workerId);
            return Ok(result ?? string.Empty);
        }
    }
}
