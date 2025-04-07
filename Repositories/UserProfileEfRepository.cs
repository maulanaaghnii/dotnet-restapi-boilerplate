using Microsoft.EntityFrameworkCore;
using UserProfileApi.Data;
using UserProfileApi.Models;

namespace UserProfileApi.Repositories;

public class UserProfileEfRepository : IUserProfileRepository
{
    private readonly AppDbContext _context;

    public UserProfileEfRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserProfile>> GetAll()
    {
        return await _context.UserProfiles
            .Where(u => u.IsDeleted == 0)
            .ToListAsync();
    }

    public async Task<UserProfile?> GetById(Guid uuid)
    {
        return await _context.UserProfiles
            .FirstOrDefaultAsync(u => u.Uuid == uuid && u.IsDeleted == 0);
    }

    public async Task Create(UserProfile user)
    {
        _context.UserProfiles.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task Update(UserProfile user)
    {
        _context.UserProfiles.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid uuid)
    {
        var user = await _context.UserProfiles.FirstOrDefaultAsync(u => u.Uuid == uuid);
        if (user != null)
        {
            user.IsDeleted = 1;
            user.DeletedAt = DateTime.UtcNow;
            _context.UserProfiles.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}