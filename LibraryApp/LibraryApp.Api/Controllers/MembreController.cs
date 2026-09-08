using LibraryApp.Application.Interfaces;
using LibraryApp.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembreController : ControllerBase
    {
        private readonly IMembreService _membreService;

        public MembreController(IMembreService membreService)
        {
            _membreService = membreService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MembreDto>> Get(int id)
        {
            var dto = await _membreService.Get(id);
            return Ok(dto);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<MembreDto>> GetAll()
        {
            var dto = await _membreService.GetAll();
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<MembreDto>> Create(CreateMembreDto dto)
        {
            var result = await _membreService.Create(dto);

            return CreatedAtAction(
                nameof(Get),
                new { id = result.Id },
                result);
        }
    }
}
