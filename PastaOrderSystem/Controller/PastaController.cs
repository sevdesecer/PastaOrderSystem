using Microsoft.AspNetCore.Mvc;
using WebApi.DTO;
using WebApi.Service.Pasta;

namespace WebApi.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class PastaController(IPastaService service) : ControllerBase
    {
        private readonly IPastaService _service = service ?? throw new ArgumentNullException(nameof(service));

        [HttpGet("getAll")]
        public ActionResult<IEnumerable<PastaDto>> GetAll()
        {
            var pastaList = _service.GetAll();
            return Ok(pastaList);
        }

        [HttpGet("getById")]
        public async Task<ActionResult<PastaDto>> GetById([FromQuery] Guid id)
        {
            var pasta = await _service.GetByIdAsync(id);
            if (pasta == null)
            {
                return NotFound();
            }
            return Ok(pasta);
        }

        [HttpPost("add")]
        public ActionResult Add(PastaDto pasta)
        {
            _service.Add(pasta);
            return CreatedAtAction(nameof(GetById), new { id = pasta.Id }, pasta);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromQuery] Guid id, PastaDto pasta)
        {
            if (id != pasta.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateAsync(pasta);
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
            var pastaToDelete = await _service.GetByIdAsync(id);
            if (pastaToDelete == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(pastaToDelete);

            return NoContent();
        }
    }
}