using CCSANoteApp.Domain;

namespace CCSANoteApp.Infrastructure.Services
{
    public interface IUserService
    {
        void CreateUser(string username, string email, string password);
        void CreateUser(User user);
        void DeleteUser(Guid id);
        User GetUser(Guid id);
        List<User> GetUsers();
        void UpdateEmail(Guid id, string email);
        void UpdateName(Guid id, string name);
    }
}