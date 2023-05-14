using Labb4API.Data;
using Labb4Models;
using Microsoft.EntityFrameworkCore;

namespace Labb4API.Services
{
    public class InterestRepo : IRepository<Interest>
    {
        private AppDbContext _appContext;

        public InterestRepo(AppDbContext context)
        {
            _appContext = context;
        }

        public async Task<Interest> Add(Interest entity)
        {
            if (entity != null)
            {
                var result = await _appContext.interests.AddAsync(entity);
                await _appContext.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        public async Task<Interest> Get(int id)
        {
            return await _appContext.interests.FirstOrDefaultAsync(x => x.InterestID == id);
        }

        public async Task<IEnumerable<Interest>> GetAll()
        {
            return await _appContext.interests.ToListAsync();
        }

        public async Task<Interest> Remove(int id)
        {
            var result = await _appContext.interests.FirstOrDefaultAsync(x => x.InterestID == id);
            if (result != null)
            {
                _appContext.interests.Remove(result);
                await _appContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task<Interest> Update(int id, Interest updatedEntity)
        {
            var entityToUpdate = await _appContext.interests.FirstOrDefaultAsync(x => x.InterestID == id);
            if (entityToUpdate != null && updatedEntity != null)
            {
                entityToUpdate.Title = updatedEntity.Title;
                entityToUpdate.Description = updatedEntity.Description;
                entityToUpdate.Links = updatedEntity.Links;
                entityToUpdate.Persons = updatedEntity.Persons;
                await _appContext.SaveChangesAsync();
            }
            return entityToUpdate;
        }
    }
}
