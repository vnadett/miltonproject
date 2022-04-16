using miltonProject.Client.Models;

namespace miltonProject.Client.Interfaces
{
    public interface IUserDetailRepository
    {
        Task<bool> Create(Details obj, int id);
        Task<Details> Get(int id);
        Task<List<UserDetailsAll>> GetAllUserInfo();
    }
}
