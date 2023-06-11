using net_restfull_api.Models;

namespace net_restfull_api.Services
{
    public interface IHeroService
    {
        Task<List<Hero>> GetAll();
        Task<Hero> GetById(int id);
        Task<Hero> Create(Hero hero);
        Task<Hero> Update(int id, Hero hero);
        Task<Hero> Delete(int id);
    }
}