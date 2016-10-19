using System;
using VuelioTask.Data;
using VuelioTask.Interfaces;

namespace VuelioTask
{
    public class PasswordGenerator : IPasswordGenerator
    {
        private static readonly Random random = new Random();

        public void SetUserPassword(User user)
        {
            user.Password = new Password
            {
                Pass = random.Next(0, 10000).ToString(),
                ExpirationTime = DateTime.Now.AddSeconds(30)
            };
        }
    }
}
