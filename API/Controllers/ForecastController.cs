using HwEFCoreWebAPI.Contracts;
using HwEFCoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HwEFCoreWebAPI.Controllers
{
    [Route("api/clima")]
    [ApiController]
    public class ForecastController : ControllerBase
    {
        /// <summary>
        /// DB Context
        /// </summary>
        private readonly ForecastContext Context;

        public ForecastController(ForecastContext context)
        {
            Context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ForecastDataContract>> GetForecast([FromQuery(Name = "dia")] uint dia)
        {
            var person = await Context.Forecasts.FirstOrDefaultAsync(x => x.Day == dia);

            if (person == null)
            {
                return NotFound();
            }

            return new ForecastDataContract(person);
        }

        [HttpGet("Prueba")]
        public ActionResult<ForecastDataContract> GetForecast()
        {
            return new ForecastDataContract();
        }
    }
}
