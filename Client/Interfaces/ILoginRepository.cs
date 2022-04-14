using miltonProject.Client.Models;

namespace miltonProject.Client.Interfaces
{
    public interface ILoginRepository
    {
        Task<Login> LoginUser(Login obj);
    }
}
