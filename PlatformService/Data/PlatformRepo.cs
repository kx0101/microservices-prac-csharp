using microservice_prac.Data;
using microservice_prac.Models;

namespace microservice_prac
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _context;

        public PlatformRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platform.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            Platform? plat = _context.Platform.FirstOrDefault(p => p.Id == id);

            if (plat == null)
            {
                throw new Exception("Platform not found");
            }

            return plat;
        }

        public void CreatePlatform(Platform plat)
        {
            if (plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }

            _context.Platform.Add(plat);
        }

        public void DeletePlatform(Platform plat)
        {
            if (plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }

            _context.Platform.Remove(plat);
        }

        public Platform UpdatePlatform(Platform plat)
        {
            // Nothing yet
            return plat;
        }
    }
}

