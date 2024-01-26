using microservice_prac.Models;

namespace microservice_prac
{
    public interface IPlatformRepo
    {
        bool SaveChanges();

        IEnumerable<Platform> GetAllPlatforms();

        Platform GetPlatformById(int id);

        void CreatePlatform(Platform plat);

        Platform UpdatePlatform(Platform plat);

        void DeletePlatform(Platform plat);
    }
}
