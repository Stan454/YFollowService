using YFollow.Models;

public interface IFollowService
{
    Task FollowUserAsync(FollowDto follow);
    Task UnfollowUserAsync(Guid userId);
    Task<IEnumerable<FollowDto>> GetFollowingsAsync(Guid userId);
}