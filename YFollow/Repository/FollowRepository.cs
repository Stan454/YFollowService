using Microsoft.EntityFrameworkCore;

public class FollowRepository : IFollowRepository
{
    private readonly ApplicationDbContext _context;

    public FollowRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddFollowAsync(Guid followerId, Guid userId)
    {
        var follow = new Follow
        {
            FollowerId = followerId,
            UserId = userId
        };

        _context.Follows.Add(follow);
        await _context.SaveChangesAsync();
    }


    public async Task RemoveFollowAsync(Guid userId)
    {
        var follow = await _context.Follows.FirstOrDefaultAsync(f => f.UserId == userId);
        if (follow != null)
        {
            _context.Follows.Remove(follow);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Guid>> GetFollowingsAsync(Guid userId)
    {
        return await _context.Follows
            .Where(f => f.FollowerId == userId)
            .Select(f => f.UserId)
            .ToListAsync();
    }
}
