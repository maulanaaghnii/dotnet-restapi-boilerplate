using UserProfileApi.Models;

namespace UserProfileApi.Repositories;

public class InMemoryUserProfileRepository : IUserProfileRepository
{
    private readonly List<UserProfile> _users = new();

    public Task<IEnumerable<UserProfile>> GetAll() =>
        Task.FromResult(_users.Where(u => u.IsDeleted == 0).AsEnumerable());

    public Task<UserProfile?> GetById(Guid uuid) =>
        Task.FromResult(_users.FirstOrDefault(u => u.Uuid == uuid && u.IsDeleted == 0));

    public Task Create(UserProfile user)
    {
        _users.Add(user);
        return Task.CompletedTask;
    }

    public Task Update(UserProfile user)
    {
        var existing = _users.FirstOrDefault(u => u.Uuid == user.Uuid);
        if (existing != null)
        {
            existing.Username = user.Username;
            existing.Email = user.Email;
            existing.FirstName = user.FirstName;
            existing.LastName = user.LastName;
            existing.BirthDate = user.BirthDate;
        }
        return Task.CompletedTask;
    }

    public Task Delete(Guid uuid)
    {
        var user = _users.FirstOrDefault(u => u.Uuid == uuid);
        if (user != null)
        {
            user.IsDeleted = 1;
            user.DeletedAt = DateTime.UtcNow;
        }
        return Task.CompletedTask;
    }
}
