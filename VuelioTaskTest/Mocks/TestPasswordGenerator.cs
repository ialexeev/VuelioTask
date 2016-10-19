using System;
using VuelioTask.Data;
using VuelioTask.Interfaces;

namespace VuelioTaskTest.Mocks
{
    internal class TestPasswordGenerator : IPasswordGenerator
    {
        internal const int Lifetime = 10;
        
        public void SetUserPassword(User user)
        {
            user.Password = new Password
            {
                Pass = "test",
                ExpirationTime = DateTime.Now.AddMilliseconds(Lifetime)
            };
        }
    }
}
