using Labb4API.Data;
using Labb4Models;
using Microsoft.EntityFrameworkCore;

namespace Labb4API.Services
{
    public class PersonRepo : IPersonRepo
    {
        private AppDbContext _appContext;

        public PersonRepo(AppDbContext context)
        {
            _appContext = context;
        }

        public async Task<Person> Add(Person entity)
        {
            if (entity != null)
            {
                var result = await _appContext.persons.AddAsync(entity);
                await _appContext.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        public async Task<Person> Get(int id)
        {
            return await _appContext.persons.FirstOrDefaultAsync(x => x.PersonID == id);
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _appContext.persons.ToListAsync();
        }

        public async Task<Person> Remove(int id)
        {
            var result = await _appContext.persons.FirstOrDefaultAsync(x => x.PersonID == id);
            if (result != null)
            {
                _appContext.persons.Remove(result);
                await _appContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task<Person> Update(int id, Person updatedEntity)
        {
            var entityToUpdate = await _appContext.persons.FirstOrDefaultAsync(x => x.PersonID == id);
            if (entityToUpdate != null && updatedEntity != null)
            {
                entityToUpdate.FirstName = updatedEntity.FirstName;
                entityToUpdate.LastName = updatedEntity.LastName;
                entityToUpdate.Age = updatedEntity.Age;
                entityToUpdate.Phone = updatedEntity.Phone;
                entityToUpdate.DateOfBirth = updatedEntity.DateOfBirth;
                entityToUpdate.Interests = updatedEntity.Interests;
                await _appContext.SaveChangesAsync();
            }
            return entityToUpdate;
        }

        public async Task<Person> AddInterest(int personid, int interestid)
        {
            var person = await _appContext.persons.FirstOrDefaultAsync(x => x.PersonID == personid);
            var interest = await _appContext.interests.FirstOrDefaultAsync(x => x.InterestID == interestid);

            if (person.Interests == null)
            {
                person.Interests = new List<Interest>() { };
                await _appContext.SaveChangesAsync();
            }

            if (person != null && interest != null)
            {
                person.Interests.Add(interest);
                await _appContext.SaveChangesAsync();
                return person;
            }
            return null;
        }

        public async Task<Person> DeleteInterest(int personid, int interestid)
        {
            var person = await _appContext.persons.Include(x => x.Interests).FirstOrDefaultAsync(x => x.PersonID == personid);
            var interest = person.Interests.FirstOrDefault(x => x.InterestID == interestid);

            if (person != null && interest != null)
            {
                person.Interests.Remove(interest);
                await _appContext.SaveChangesAsync();
            }
            return person;
        }

        public async Task<dynamic> GetInterests(int personid)
        {
            var person = await _appContext.persons
                .Where(x => x.PersonID == personid)
                .Select(x => new { x.PersonID, x.FirstName, x.LastName, x.Interests })
                .FirstOrDefaultAsync();
            if (person != null)
            {
                return person;
            }
            return null;
        }
    }
}
