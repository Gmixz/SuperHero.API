using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHero.API.Data;


namespace SuperHero.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.SuperHero>>> GetSuperHeroes()
        {
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Models.SuperHero>>> CreateSuperHero(Models.SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Models.SuperHero>>> UpdateSuperHero(Models.SuperHero hero)
        {
            var heroToUpdate = await _context.SuperHeroes.FindAsync(hero.Id);

            if (heroToUpdate == null)
            {
                return BadRequest("Hero not found");
            }

            heroToUpdate.Name = hero.Name;
            heroToUpdate.FirstName = hero.FirstName;
            heroToUpdate.LastName = hero.LastName;
            heroToUpdate.Place = hero.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Models.SuperHero>>> DeleteSuperHero(int id)
        {
            var heroToDelete = await _context.SuperHeroes.FindAsync(id);

            if (heroToDelete == null)
            {
                return BadRequest("Hero not found");
            }

            _context.SuperHeroes.Remove(heroToDelete);

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }
    }
}
