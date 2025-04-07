using UserProfileApi.Models;

namespace UserProfileApi.Services;

public interface IUserProfileService
{
    Task<IEnumerable<UserProfile>> GetAll();
    Task<UserProfile?> GetById(Guid uuid);
    Task Create(UserProfile user);
    Task Update(UserProfile user);
    Task Delete(Guid uuid);
}
