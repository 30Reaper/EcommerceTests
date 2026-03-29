using System.Text.Json.Serialization;

namespace EcommerceTests.Models
{
    public class UserModel
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    public class UsersData
    {
        [JsonPropertyName("validUser")]
        public required UserModel ValidUser { get; set; }

        [JsonPropertyName("invalidUser")]
        public required UserModel InvalidUser { get; set; }
    }
}