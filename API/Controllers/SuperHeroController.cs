using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SuperHeroController : ControllerBase
{
    private readonly SuperHeroContext _superHeroContext;

    public SuperHeroController(SuperHeroContext superHeroContext)
    {
        _superHeroContext = superHeroContext;
    }
    
    // GET
    [HttpGet]
    public async Task<ActionResult<List<SuperHero>>> Get()
    {
        var superheroes = await _superHeroContext.Superheroes.ToListAsync();
        return Ok(superheroes);
    }
    
    [HttpGet("{id}", Name = "GetSuperHero")]
    public async Task<ActionResult<SuperHero>> Get(int id)
    {
        var hero = await _superHeroContext.Superheroes.FindAsync(id);

        if (hero is null)
        {
            return NotFound("Hero not found.");
        }
        
        return Ok(hero);
    }

    // POST
    [HttpPost]
    public async Task<ActionResult<List<SuperHero>>> Post(SuperHero heroRequest)
    {
        _superHeroContext.Superheroes.Add(heroRequest);
        await _superHeroContext.SaveChangesAsync();
        
        return CreatedAtRoute("GetSuperHero", new { id = heroRequest.Id}, heroRequest);
    }
    
    // PUT
    [HttpPut]
    public async Task<ActionResult<List<SuperHero>>> Put(SuperHero heroRequest)
    {
        var hero = await _superHeroContext.Superheroes.FindAsync(heroRequest.Id);

        if (hero is null)
        {
            return BadRequest("Hero not found.");
        }

        hero.Name = heroRequest.Name;
        hero.FirstName = heroRequest.FirstName;
        hero.LastName = heroRequest.LastName;
        hero.Place = heroRequest.Place;
        
        await _superHeroContext.SaveChangesAsync();
        
        return Ok(await _superHeroContext.Superheroes.ToListAsync());
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<SuperHero>>> Delete(int id)
    {
        var hero = await _superHeroContext.Superheroes.FindAsync(id);

        if (hero is null)
        {
            return BadRequest("Hero not found.");
        }

        _superHeroContext.Remove(hero);
        await _superHeroContext.SaveChangesAsync();
        
        return Ok(await _superHeroContext.Superheroes.ToListAsync());
    }
} 