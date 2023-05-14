using Labb4Models;

namespace Labb4API.Services
{
    public interface ILinkRepo : IRepository<Link>
    {
        Task<dynamic> GetPersonLinks(int personid);
    }
}
