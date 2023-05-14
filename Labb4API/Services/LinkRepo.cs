using Labb4API.Data;
using Labb4Models;
using Microsoft.EntityFrameworkCore;

namespace Labb4API.Services
{
    public class LinkRepo : ILinkRepo
    {
        private AppDbContext _appContext;

        public LinkRepo(AppDbContext context)
        {
            _appContext = context;
        }

        public async Task<Link> Add(Link entity)
        {
            if (entity != null)
            {
                var result = await _appContext.links.AddAsync(entity);
                await _appContext.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        public async Task<Link> Get(int id)
        {
            return await _appContext.links.FirstOrDefaultAsync(x => x.LinkID == id);
        }

        public async Task<IEnumerable<Link>> GetAll()
        {
            return await _appContext.links.ToListAsync();
        }

        public async Task<Link> Remove(int id)
        {
            var result = await _appContext.links.FirstOrDefaultAsync(x => x.LinkID == id);
            if (result != null)
            {
                _appContext.links.Remove(result);
                await _appContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task<Link> Update(int id, Link updatedEntity)
        {
            var entityToUpdate = await _appContext.links.FirstOrDefaultAsync(x => x.LinkID == id);
            if (entityToUpdate != null && updatedEntity != null)
            {
                entityToUpdate.URL = updatedEntity.URL;
                entityToUpdate.PersonID = updatedEntity.PersonID;
                entityToUpdate.LinkPerson = updatedEntity.LinkPerson;
                await _appContext.SaveChangesAsync();
            }
            return entityToUpdate;
        }

        public async Task<dynamic> GetPersonLinks(int personid)
        {
            var personlinks = await _appContext.links
                .Where(x => x.PersonID == personid)
                .Select(x => new { x.PersonID, x.LinkPerson.FirstName, x.LinkPerson.LastName, x.LinkInterest.Title, x.URL })
                .ToListAsync();
            return personlinks;
        } 
    }
}
