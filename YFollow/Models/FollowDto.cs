namespace YFollow.Models
{
    public class FollowDto
    {
        public Guid FollowerId { get; set; } //The user who wants to follow a account
        public Guid UserId { get; set; } //The account the user wants to follow
        public string UserName { get; set; } //The UserId account name
    }
}
