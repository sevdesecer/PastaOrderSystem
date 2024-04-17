using Microsoft.AspNetCore.Mvc;
using WebApi.DTO;
using WebApi.Service.ExtraIngredient;

namespace WebApi.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ExtraIngredientController : ControllerBase
    {
        private readonly IExtraIngredientService _service;

        public ExtraIngredientController(IExtraIngredientService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("getAll")]
        public ActionResult<IEnumerable<ExtraIngredientDto>> GetAll()
        {
            var extraIngredients = _service.GetAll();
            return Ok(extraIngredients);
        }

        [HttpGet("getById")]
        public async Task<ActionResult<ExtraIngredientDto>> GetById([FromQuery] Guid id)
        {
            var extraIngredient = await _service.GetByIdAsync(id);
            if (extraIngredient == null)
            {
                return NotFound();
            }
            return Ok(extraIngredient);
        }

        [HttpPost("add")]
        public ActionResult Add(ExtraIngredientDto extraIngredient)
        {
            _service.Add(extraIngredient);
            return CreatedAtAction(nameof(GetById), new { id = extraIngredient.Id }, extraIngredient);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromQuery] Guid id, ExtraIngredientDto extraIngredient)
        {
            if (id != extraIngredient.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateAsync(extraIngredient);
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
            var extraIngredientToDelete = await _service.GetByIdAsync(id);
            if (extraIngredientToDelete == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(extraIngredientToDelete);

            return NoContent();
        }
    }
}