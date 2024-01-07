using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project.business.DTOs.PortifolioDto;
using project.business.Services.Interfaces;

namespace MyBizLandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortifoliosController : ControllerBase
    {
        private readonly IPortifolioService _portfolioService;

        public PortifoliosController(IPortifolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            if (id == null && id <= 0) return NotFound();

            PortifolioGetDto portfolioGetDto = null;

            try
            {
                portfolioGetDto = await _portfolioService.GetByIdAsync(id);

            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(portfolioGetDto);
        }
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<PortifolioGetDto> portifolioGetDtos = await _portfolioService.GetAllAsync();

            return Ok(portifolioGetDtos);
        }
        [HttpPost("")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromForm] PortifolioCreateDto portifolioCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("error!");
            }


            try
            {
                await _portfolioService.CreateAsync(portifolioCreateDto);
            }
            catch { }

            return StatusCode(201, new { message = "Object yaradildi" });
        }
        [HttpPut("")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromForm] PortifolioUpdateDto portfolioUpdateDto)
        {
            if (portfolioUpdateDto.Id == null && portfolioUpdateDto.Id <= 0) return NotFound();

            try
            {
                await _portfolioService.UpdateAsync(portfolioUpdateDto);

            }

            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
        [HttpDelete("/Delete/{id}")]
        [Authorize(Roles = "SuperAdmin")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null && id <= 0) return NotFound();

            try
            {
                await _portfolioService.DeleteAsync(id);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
        [HttpPatch("/ToggleDelete/{id}")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ToggleDelete(int id)
        {
            if (id == null && id <= 0) return NotFound();

            try
            {
                await _portfolioService.ToggleDelete(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
    }
}
