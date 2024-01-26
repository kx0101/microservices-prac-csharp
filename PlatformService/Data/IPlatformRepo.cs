using microservice_prac.Models;

namespace microservice_prac
{
    public interface IPlatformRepo
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<Platform>> GetAllPlatforms();

        Task<Platform?> GetPlatformById(int id);

        Task CreatePlatform(Platform plat);

        Task<Platform> UpdatePlatform(Platform plat);

        Task DeletePlatform(Platform plat);
    }
}
