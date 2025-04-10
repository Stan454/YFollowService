public class FollowService : IFollowService
{
    private readonly IFollowRepository _followRepository;

    public FollowService(IFollowRepository followRepository)
    {
        _followRepository = followRepository;
    }

    public async Task FollowUserAsync(Guid followerId, Guid userId)
    {
        await _followRepository.AddFollowAsync(followerId, userId);
    }

    public async Task UnfollowUserAsync(Guid userId)
    {
        await _followRepository.RemoveFollowAsync(userId);
    }

    public async Task<IEnumerable<Guid>> GetFollowingsAsync(Guid userId)
    {
        return await _followRepository.GetFollowingsAsync(userId);
    }
}
