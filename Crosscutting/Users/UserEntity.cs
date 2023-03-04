namespace Crosscutting.Users
{
    public class UserEntity : BaseEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public UserType UserType { get; set; }
    }

    public enum UserType
    {
        User = 0,
        Dev,
        HR,
        Investor,
    }
}
