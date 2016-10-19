namespace VuelioTask.Data
{
    public class User
    {
        public string UserId { get; }
        public Password Password { get; set; }

        public User(string userId)
        {
            UserId = userId;
        }
    }
}
