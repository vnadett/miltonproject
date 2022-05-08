using miltonProject.Client.Models;

namespace miltonProject.Client.Interfaces
{
    public interface IRegistrationRepository
    {
        Task<bool> Create(Registration obj);
        Task<bool> ChangePassword(User obj);
    }
}
