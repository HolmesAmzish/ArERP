using ArERP.Data;
using ArERP.Models;

namespace ArERP.Repository.Impl;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        this._context = context;
    }

    public List<User> GetAllUsers() => 
        _context.Users
            .ToList();

    public User? GetUserById(int id) =>
        _context.Users
            .FirstOrDefault(u => u.Id == id);

    public User? GetUserByUsername(string username) =>
        _context.Users
            .FirstOrDefault(u => u.Username == username);

    public void AddUser(User user)
    {
        _context.Add(user);
        _context.SaveChanges();
    }
}