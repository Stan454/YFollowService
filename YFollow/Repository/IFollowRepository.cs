using YFollow.Models;

public interface IFollowRepository
{
    Task AddFollowAsync(FollowDto follow);
    Task RemoveFollowAsync(Guid userId);
    Task<IEnumerable<FollowDto>> GetFollowingsAsync(Guid userId);
}
