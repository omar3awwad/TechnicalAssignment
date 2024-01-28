using Microsoft.AspNetCore.Mvc;
using TechnicalAssignment.Api.Models;
using TechnicalAssignment.Api.Services;
using TechnicalAssignment.Api.Services.Interfaces;

namespace TechnicalAssignment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModelsController : ControllerBase
    {
        private readonly ILogger<ModelsController> _logger;
        private readonly IMakeService _makeService;
        private readonly IIntegrationService _integrationService;

        public ModelsController(ILogger<ModelsController> logger, IMakeService makeService, IIntegrationService integrationService)
        {
            _logger = logger;
            _makeService = makeService;
            _integrationService = integrationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetModels(string make, int modelyear)
        {
            var makeId = await _makeService.GetIdByName(make);
            if (makeId == null)
                return NoContent();

            var response = await _integrationService.GetModelsForMakeIdAndYear(makeId.Value, modelyear);

            return Ok(new ModelsResponse { Models = response });
        }
    }
}
