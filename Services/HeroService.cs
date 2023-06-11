
using Microsoft.EntityFrameworkCore;
using net_restfull_api.Data;
using net_restfull_api.Models;

namespace net_restfull_api.Services
{
    public class HeroService : IHeroService
    {
        private readonly DataContext _context;

        public HeroService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Hero>> GetAll()
        {
            var heroes = await _context.Heroes.ToListAsync();
            return heroes;
        }

        public async Task<Hero> GetById(int id)
        {
            var hero = await _context.Heroes.FindAsync(id);
            if (hero is null) return null;
            return hero;
        }

        public async Task<Hero> Create(Hero hero)
        {
            _context.Heroes.Add(hero);
            await _context.SaveChangesAsync();
            return hero;
        }

        public async Task<Hero> Update(int id, Hero hero)
        {
            var heroToUpdate = await _context.Heroes.FindAsync(id);
            if (heroToUpdate is null) return null;

            heroToUpdate.Name = hero.Name;
            heroToUpdate.FirstName = hero.FirstName;
            heroToUpdate.LastName = hero.LastName;
            heroToUpdate.Place = hero.Place;

            await _context.SaveChangesAsync();

            return heroToUpdate;
        }

        public async Task<Hero> Delete(int id)
        {
            var hero = await _context.Heroes.FindAsync(id);
            if (hero is null) return null;

            _context.Heroes.Remove(hero);
            await _context.SaveChangesAsync();

            return hero;
        }
    }
}