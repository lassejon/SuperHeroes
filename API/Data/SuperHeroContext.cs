using API.Models;

namespace API.Data;

public class SuperHeroContext : DbContext
{
    public SuperHeroContext(DbContextOptions<SuperHeroContext> options) : base(options)
    {
        
    }

    public DbSet<SuperHero> Superheroes { get; set; }
}