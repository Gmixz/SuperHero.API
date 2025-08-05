using Microsoft.AspNetCore.Mvc;
using SuperHero.API.Models;


namespace SuperHero.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Models.SuperHero>>> GetSuperHeroes()
        {
            return new List<Models.SuperHero>
            {
                new Models.SuperHero
                {
                   Name = "Spider Man",
                   FirstName = "Peter",
                   LastName = "Parker",
                   Place = "New York"

                }
            };
        }
    }
}
