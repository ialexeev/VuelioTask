using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VuelioTask;
using VuelioTaskTest.Mocks;

namespace VuelioTaskTest
{
    [TestClass]
    public class UsersTest
    {
        [TestMethod]
        public void TestUserManager()
        {
            var userManager = new UserManager(new TestPasswordGenerator());
            const string userId = "user1";
            var password = userManager.CreateNewPassword(userId);

            var result = userManager.CheckPassword(userId, password);
            Assert.AreEqual(true, result);

            Thread.Sleep(TestPasswordGenerator.Lifetime);

            result = userManager.CheckPassword(userId, password);
            Assert.AreEqual(false, result);
        }
    }
}
