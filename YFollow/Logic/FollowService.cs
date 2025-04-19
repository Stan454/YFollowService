using YFollow.Models;

public class FollowService : IFollowService
{
    private readonly IFollowRepository _followRepository;

    public FollowService(IFollowRepository followRepository)
    {
        _followRepository = followRepository;
    }

    public async Task FollowUserAsync(FollowDto followDto)
    {
        await _followRepository.AddFollowAsync(followDto);
    }

    public async Task UnfollowUserAsync(Guid userId)
    {
        await _followRepository.RemoveFollowAsync(userId);
    }

    public async Task<IEnumerable<FollowDto>> GetFollowingsAsync(Guid userId)
    {
        return await _followRepository.GetFollowingsAsync(userId);
    }
}
