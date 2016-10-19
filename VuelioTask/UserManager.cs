using System;
using System.Collections.Generic;
using VuelioTask.Data;
using VuelioTask.Interfaces;

namespace VuelioTask
{
    public class UserManager : IUserManager
    {
        private readonly IPasswordGenerator _passwordGenerator;

        public UserManager(IPasswordGenerator passwordGenerator)
        {
            _passwordGenerator = passwordGenerator;
        }

        private readonly Dictionary<string, User> _users = new Dictionary<string, User>();

        public string CreateNewPassword(string userId)
        {
            User user;
            if(_users.TryGetValue(userId, out user))
            {
                if (user.Password.ExpirationTime >= DateTime.Now)
                {
                    return user.Password.Pass;
                }

                _users.Remove(userId);
            }

            user = new User(userId);
            _passwordGenerator.SetUserPassword(user);
            _users.Add(userId, user);
            return user.Password.Pass;
        }

        public bool CheckPassword(string userId, string password)
        {
            User user;
            if (_users.TryGetValue(userId, out user))
            {
                if (user.Password.ExpirationTime >= DateTime.Now)
                {
                    return true;
                }
            }
            
            _users.Remove(userId);
            return false;
        }
    }
}
