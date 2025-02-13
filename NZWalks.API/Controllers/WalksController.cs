
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repository;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalksRepository walksRepository;

        public WalksController(IMapper mapper, IWalksRepository walksRepository)
        {
            this.mapper = mapper;
            this.walksRepository = walksRepository;
        }

        //Get All the walks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walksDomainModel = await walksRepository.GetAllAsync();

            return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
        }

        //Create walk
        //POST: http://api/wlaks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddwalkRequestDto addWalkRequestDto)
        {

            //Map DTO to Domain
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);
            await walksRepository.CreateAsync(walkDomainModel);

            //Map Domain model to DTO
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        //Getting a single walk by ID
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var walkDomain = await walksRepository.GetByIdAsync(id);

            if (walkDomain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto>(walkDomain));
        }

        //Updating a single walk
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkDto updateWalkDto)
        {
            //Map DTO to Domain Model.
            var walkDomainModel = mapper.Map<Walk>(updateWalkDto);

            walkDomainModel = await walksRepository.UpdateAsync(id, walkDomainModel);

            if(walkDomainModel == null)
            {
                return NotFound();
            }
            //Map Domain Model to Dto
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        //Deleting a single walk
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedWalkDomainModel = await walksRepository.DeleteAsync(id);
            if(deletedWalkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto>(deletedWalkDomainModel));
        }
    }

}
