namespace YFollow.Models
{
    public class Mapper
    {
        public static FollowDto ToDto(Follow follow)
        {
            return new FollowDto
            {
                FollowerId = follow.FollowerId,
                UserId = follow.UserId,
                UserName = follow.UserName
            };
        }

        public static Follow ToEntity(FollowDto followDto)
        {
            return new Follow
            {
                FollowerId = followDto.FollowerId,
                UserId = followDto.UserId,
                UserName = followDto.UserName
            };
        }

    }
}
