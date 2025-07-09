namespace ArERP.Models.Entity
{
    public class UserEntity
    {
        public int UserId;
        public string Username;
        public string Password;
        public string Email;
        public string Gender;
        public UserEntity() { }
        public UserEntity(string username, string password) { }
    }
}
