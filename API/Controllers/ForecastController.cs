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
        private readonly ForecastContext Context;

        public ForecastController(ForecastContext context)
        {
            Context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ForecastDataContract>> GetForecast([FromQuery(Name = "dia")] uint dia)
        {
            var forecast = await this.Context.Forecasts.FirstOrDefaultAsync(x => x.Day == dia);

            if (forecast == null)
            {
                return NotFound();
            }

            return new ForecastDataContract(forecast);
        }

        [HttpGet("prueba")]
        public ActionResult<ForecastDataContract> GetForecast()
        {
            return new ForecastDataContract() { Dia = 10321, Clima = "sequía" };
        }
    }
}
