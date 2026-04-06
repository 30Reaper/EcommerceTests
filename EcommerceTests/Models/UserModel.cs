using System.Text.Json.Serialization;

namespace EcommerceTests.Models
{
    public class UserModel
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}