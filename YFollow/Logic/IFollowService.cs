public interface IFollowService
{
    Task FollowUserAsync(Guid followerId, Guid userId);
    Task UnfollowUserAsync(Guid userId);
    Task<IEnumerable<Guid>> GetFollowingsAsync(Guid userId);
}