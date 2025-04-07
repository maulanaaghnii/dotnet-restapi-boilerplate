using UserProfileApi.Models;
using UserProfileApi.Repositories;

namespace UserProfileApi.Services;

public class UserProfileService : IUserProfileService
{
    private readonly IUserProfileRepository _repo;

    public UserProfileService(IUserProfileRepository repo)
    {
        _repo = repo;
    }

    public Task<IEnumerable<UserProfile>> GetAll() => _repo.GetAll();
    public Task<UserProfile?> GetById(Guid uuid) => _repo.GetById(uuid);
    public Task Create(UserProfile user) => _repo.Create(user);
    public Task Update(UserProfile user) => _repo.Update(user);
    public Task Delete(Guid uuid) => _repo.Delete(uuid);
}
