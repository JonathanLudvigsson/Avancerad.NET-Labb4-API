using Labb4Models;

namespace Labb4API.Services
{
    public interface IPersonRepo : IRepository<Person>
    {
        Task<Person> AddInterest(int personid, int interestid);
        Task<dynamic> GetInterests(int personid);
        Task<Person> DeleteInterest(int personid, int interestid);
    }
}
