using EcommerceTests.Models;
using EcommerceTests.Utilities;

namespace EcommerceTests.Tests
{
    public static class TestDataProvider
    {
        private static readonly UsersData users = JsonHelper.ReadJsonFile<UsersData>("TestData/Users.json");

        public static IEnumerable<object[]> ValidUsers => new[] { new object[] { users.ValidUsers[0] } };

        public static IEnumerable<object[]> InvalidUsers => new[]
        {
            new object[] { users.InvalidUser, "Username is incorrect.", "Password is incorrect." }
        };
    }
}
