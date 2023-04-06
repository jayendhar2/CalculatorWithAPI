using CoinApi.DB_Models;
using CoinApi.Request_Models;
using CoinApi.Services;
using CoinApi.Services.Exercise;
using CoinApi.Shared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoinApi.Controllers
{
    public class ExerciseController : BaseController
    {
        private readonly IExerciseService exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }

        [HttpGet("loadExercises")]
        public async Task<IActionResult> loadDB()
        {
            var result = exerciseService.loadDB();
            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
