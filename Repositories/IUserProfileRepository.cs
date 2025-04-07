using UserProfileApi.Models;

namespace UserProfileApi.Repositories;

public interface IUserProfileRepository
{
    Task<IEnumerable<UserProfile>> GetAll();
    Task<UserProfile?> GetById(Guid uuid);
    Task Create(UserProfile user);
    Task Update(UserProfile user);
    Task Delete(Guid uuid);
}
