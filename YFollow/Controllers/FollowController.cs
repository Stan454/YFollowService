using Microsoft.AspNetCore.Mvc;
using YFollow.Models;

[ApiController]
[Route("api/[controller]")]
public class FollowController : ControllerBase
{
    private readonly IFollowService _followService;

    public FollowController(IFollowService followService)
    {
        _followService = followService;
    }

    [HttpPost]
    public async Task<IActionResult> FollowUser(FollowDto follow)
    {
        await _followService.FollowUserAsync(follow);
        return Ok(new { Message = "User followed successfully." });
    }


    [HttpDelete("{userId}")]
    public async Task<IActionResult> UnfollowUser(Guid userId)
    {
        await _followService.UnfollowUserAsync(userId);
        return Ok(new { Message = "User unfollowed successfully." });
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetFollowings(Guid userId)
    {
        var followings = await _followService.GetFollowingsAsync(userId);
        return Ok(followings);
    }
}
