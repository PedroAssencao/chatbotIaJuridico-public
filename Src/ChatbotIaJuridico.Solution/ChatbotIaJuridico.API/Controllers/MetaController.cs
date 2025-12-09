using System.Text.Json;
using ChatbotIaJuridico.Services.Meta.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChatbotIaJuridico.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MetaController : ControllerBase
    {
        protected readonly IMetaServices _services;

        public MetaController(IMetaServices services)
        {
            _services = services;
        }

        [HttpPost("hook")]
        public async Task<IActionResult> HandleWebhookAsync(JsonDocument requestBody)
        {
            try
            {
                await _services.main(requestBody);
                return Ok();
            }
            catch (Exception)
            {
                return Ok();
            }
        }

        [HttpGet("hook")]
        public IActionResult HandleWebhook([FromQuery(Name = "hub.challenge")] string hubChallenge) => Ok(hubChallenge);
    }
}
