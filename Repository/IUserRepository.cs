using ArERP.Models;

namespace ArERP.Repository;

public interface IUserRepository
{
    List<User> GetAllUsers();
    User? GetUserById(int id);
    User? GetUserByUsername(string username);
    void AddUser(User user);
}