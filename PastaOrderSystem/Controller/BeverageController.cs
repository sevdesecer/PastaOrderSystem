using Microsoft.AspNetCore.Mvc;
using WebApi.DTO;
using WebApi.Service.Beverage;

namespace WebApi.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class BeverageController : ControllerBase
    {
        private readonly IBeverageService _service;

        public BeverageController(IBeverageService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("getAll")]
        public ActionResult<IEnumerable<BeverageDto>> GetAll()
        {
            var beverageList = _service.GetAll();
            return Ok(beverageList);
        }

        [HttpGet("getById")]
        public async Task<ActionResult<BeverageDto>> GetById([FromQuery] Guid id)
        {
            var beverage = await _service.GetByIdAsync(id);
            if (beverage == null)
            {
                return NotFound();
            }
            return Ok(beverage);
        }

        [HttpPost("add")]
        public ActionResult Add(BeverageDto beverage)
        {
            _service.Add(beverage);
            return CreatedAtAction(nameof(GetById), new { id = beverage.Id }, beverage);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromQuery] Guid id, BeverageDto beverage)
        {
            if (id != beverage.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateAsync(beverage);
            }
            catch
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var beverageToDelete = await _service.GetByIdAsync(id);
            if (beverageToDelete == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(beverageToDelete);

            return NoContent();
        }
    }
}