using Microsoft.AspNetCore.Mvc;
using net_restfull_api.Models;
using net_restfull_api.Services;

namespace net_restfull_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HerosController : ControllerBase
    {
        private readonly IHeroService _herosService;

        public HerosController(IHeroService herosService)
        {
            _herosService = herosService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hero>>> GetAll()
        {
            var heroes = await _herosService.GetAll();
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> GetById(int id)
        {
            var hero = await _herosService.GetById(id);
            if (hero is null) return NotFound("Hero not found");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<Hero>> Create(Hero hero)
        {
            var result = await _herosService.Create(hero);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Hero>> Update(int id, Hero heroRequest)
        {
            var result = await _herosService.Update(id, heroRequest);
            if (result is null) return NotFound("Hero not found");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Hero>> Delete(int id)
        {
            var hero = await _herosService.Delete(id);
            if (hero is null) return NotFound("Hero not found");
            return Ok(hero);
        }
    }
}