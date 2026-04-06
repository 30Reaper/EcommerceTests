namespace EcommerceTests.Models
{
    public class UsersData
    {
        public required List<UserModel> ValidUsers { get; set; }
        public required UserModel InvalidUser { get; set; }
    }
}