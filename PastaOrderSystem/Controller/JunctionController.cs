using Microsoft.AspNetCore.Mvc;
using PastaOrderSystem.DTO;
using PastaOrderSystem.Service.Junction;

namespace PastaOrderSystem.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class JunctionController : ControllerBase
    {
        private readonly IJunctionService _service;

        public JunctionController(IJunctionService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("getAll")]
        public ActionResult<IEnumerable<JunctionDto>> GetAll()
        {
            var junctionList = _service.GetAll();
            return Ok(junctionList);
        }

        [HttpGet("getById")]
        public async Task<ActionResult<JunctionDto>> GetById([FromQuery] Guid id)
        {
            var junction = await _service.GetByIdAsync(id);
            if (junction == null)
            {
                return NotFound();
            }
            return Ok(junction);
        }

        [HttpPost("add")]
        public ActionResult Add(JunctionDto junction)
        {
            _service.Add(junction);
            return CreatedAtAction(nameof(GetById), new { id = junction.PastaId }, junction);
        }

        [HttpPost("addRange")]
        public async Task<ActionResult> AddRange(IEnumerable<JunctionDto> junctions)
        {
            await _service.AddRangeAsync(junctions);
            return Ok();
        }


        [HttpPut("update")]
        public async Task<IActionResult> Update([FromQuery] Guid id, JunctionDto junction)
        {
            if (id != junction.PastaId)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateAsync(junction);
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
            var junctionToDelete = await _service.GetByIdAsync(id);
            if (junctionToDelete == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(junctionToDelete);

            return NoContent();
        }
    }
}
