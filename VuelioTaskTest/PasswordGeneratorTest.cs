using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VuelioTask;
using VuelioTask.Data;

namespace VuelioTaskTest
{
    [TestClass]
    public class PasswordGeneratorTest
    {
        [TestMethod]
        public void TestPasswordGenerator()
        {
            var passwordGenerator = new PasswordGenerator();

            var dateTime = DateTime.Now.AddSeconds(30);
            var user1 = new User("user1");
            passwordGenerator.SetUserPassword(user1);
            Assert.AreEqual(user1.Password.ExpirationTime.Second, dateTime.Second);


            var user2 = new User("user2");
            passwordGenerator.SetUserPassword(user2);
            Assert.AreNotEqual(user1.Password.Pass, user2.Password.Pass);
        }
    }
}
