using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galytix.GWPSolution.WebAPI.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Galytix.GWPSolution.WebAPI.Controllers
{
    [Route("server/api/gwp")]
    [ApiController]
    public class CountryGwpController : ControllerBase
    {
        private readonly IGWPOperations _gWPOperations;
        private readonly ILogger _logger;
        public CountryGwpController(Operations.IGWPOperations gWPOperations, ILogger<CountryGwpController> logger)
        {
            this._gWPOperations = gWPOperations;
            this._logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "Welcome! Galytix GWP Solution.";
        }

        /// <summary>
        /// Action method for get average according to country and line of business.
        /// </summary>
        /// <param name="gwpAverageRequestModel">Request payload.</param>
        /// <returns>Return action result.</returns>
        [HttpPost("avg")]
        public IActionResult Post([FromBody] Model.GwpAverageRequestModel gwpAverageRequestModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    this._logger.LogError("Payload is invalid.");
                    return new BadRequestResult();
                }
                                var averageResult = this._gWPOperations.GetGwpAverage(gwpAverageRequestModel);
                if (averageResult != null && averageResult.Any())
                {
                    return new ObjectResult(averageResult) { StatusCode = 200 };
                }
                return new NoContentResult();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return new BadRequestResult();
            }

        }

    }
}
