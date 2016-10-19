namespace VuelioTask.Interfaces
{
    public interface IUserManager
    {
        string CreateNewPassword(string userId);

        bool CheckPassword(string userId, string password);
    }
}
