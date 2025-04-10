public interface IFollowRepository
{
    Task AddFollowAsync(Guid followerId ,Guid userId);
    Task RemoveFollowAsync(Guid userId);
    Task<IEnumerable<Guid>> GetFollowingsAsync(Guid userId);
}
