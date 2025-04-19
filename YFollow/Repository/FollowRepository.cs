using Microsoft.EntityFrameworkCore;
using YFollow.Models;

public class FollowRepository : IFollowRepository
{
    private readonly ApplicationDbContext _context;

    private readonly RabbitMQPublisher _rabbitMQPublisher;

    public FollowRepository(ApplicationDbContext context, RabbitMQPublisher rabbitMQPublisher)
    {
        _context = context;
        _rabbitMQPublisher = rabbitMQPublisher;
    }

    public async Task AddFollowAsync(FollowDto followDto)
    {
        if (followDto.FollowerId == followDto.UserId)
        {
            throw new InvalidOperationException("A user cannot follow themselves.");
        }

        Follow Follow = Mapper.ToEntity(followDto);

        _context.Follows.Add(Follow);
        await _context.SaveChangesAsync();

        _rabbitMQPublisher.PublishFollowUpdate(followDto);
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

    public async Task<IEnumerable<FollowDto>> GetFollowingsAsync(Guid userId)
    {
        return await _context.Follows
            .Where(f => f.FollowerId == userId)
            .Select(f => new FollowDto
            {
                UserId = f.UserId,
                UserName = f.UserName 
            })
            .ToListAsync();
    }

}
