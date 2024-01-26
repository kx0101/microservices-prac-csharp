using AutoMapper;
using microservice_prac.DTOs;
using microservice_prac.Models;
using Microsoft.AspNetCore.Mvc;

namespace microservice_prac.Controllers
{
    [ApiController]
    [Route("api/platforms")]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repo;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatformReadDto>>> GetAllPlatforms()
        {
            Console.WriteLine("--> Getting Platforms...");

            var platformItems = await _repo.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public async Task<ActionResult<PlatformReadDto>> GetPlatformById(int id)
        {
            Console.WriteLine("--> Getting Platform by Id...");

            var platform = await _repo.GetPlatformById(id);

            if (platform == null)
            {
                Console.WriteLine("--> Not Found");
                return NotFound();
            }

            Console.WriteLine("--> Found Platform for id: {0}", id);
            return Ok(_mapper.Map<PlatformReadDto>(platform));
        }

        [HttpPost]
        public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreateDto platformDto)
        {
            if (platformDto == null)
            {
                Console.WriteLine("--> Bad Request");
                return BadRequest();
            }

            Console.WriteLine("--> Creating Platform...");

            var platformModel = _mapper.Map<Platform>(platformDto);

            await _repo.CreatePlatform(platformModel);
            await _repo.SaveChanges();

            Console.WriteLine("--> Platform Created");
            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformModel.Id }, _mapper.Map<PlatformReadDto>(platformModel));
        }

        [HttpPut("{id}", Name = "UpdatePlatform")]
        public async Task<ActionResult<PlatformReadDto>> UpdatePlatform(int id, PlatformUpdateDto platformDto)
        {
            if (platformDto == null)
            {
                Console.WriteLine("--> Bad Request");
                return BadRequest();
            }

            Console.WriteLine("--> Updating Platform...");

            var platformModel = await _repo.GetPlatformById(id);

            if (platformModel == null)
            {
                Console.WriteLine("--> Not Found");
                return NotFound();
            }

            if (platformDto.Name != null)
            {
                platformModel.Name = platformDto.Name;
            }

            if (platformDto.Publisher != null)
            {
                platformModel.Publisher = platformDto.Publisher;
            }

            if (platformDto.Cost != null)
            {
                platformModel.Cost = platformDto.Cost;
            }

            await _repo.UpdatePlatform(platformModel);
            await _repo.SaveChanges();

            Console.WriteLine("--> Platform Updated");
            return Ok(_mapper.Map<PlatformReadDto>(platformModel));
        }

        [HttpDelete("{id}", Name = "DeletePlatform")]
        public async Task<ActionResult> DeletePlatform(int id)
        {
            Console.WriteLine("--> Deleting Platform...");

            var platformModel = await _repo.GetPlatformById(id);

            if (platformModel == null)
            {
                Console.WriteLine("--> Not Found");
                return NotFound();
            }

            await _repo.DeletePlatform(platformModel);
            await _repo.SaveChanges();

            Console.WriteLine("--> Platform Deleted");
            return NoContent();
        }
    }
}
