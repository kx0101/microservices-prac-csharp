using microservice_prac.Data;
using microservice_prac.Models;
using Microsoft.EntityFrameworkCore;

namespace microservice_prac
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _context;

        public PlatformRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task<IEnumerable<Platform>> GetAllPlatforms()
        {
            return await _context.Platform.ToListAsync();
        }

        public async Task<Platform?> GetPlatformById(int id)
        {
            Platform? plat = await _context.Platform.FirstOrDefaultAsync(p => p.Id == id);

            return plat;
        }

        public async Task CreatePlatform(Platform plat)
        {
            await _context.Platform.AddAsync(plat);
        }

        public async Task<Platform> UpdatePlatform(Platform plat)
        {
            _context.Platform.Update(plat);

            await this.SaveChanges();

            return plat;
        }

        public async Task DeletePlatform(Platform plat)
        {
            _context.Platform.Remove(plat);

            await this.SaveChanges();
        }
    }
}

