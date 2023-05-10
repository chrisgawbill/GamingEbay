using Microsoft.AspNetCore.Mvc;
using ConsoleApi.Data;
using ConsoleApi.Models;
using ConsoleApi.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;

namespace ConsoleApi.Controllers
{
    [ApiController]
    [Route("api/GamingPlatform")]
    public class GamingPlatformController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;
        public GamingPlatformController(ApplicationDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }
        [HttpGet("GetGamingPlatformList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<ConsoleDto>> GetAllConsoles() {
            return Ok(db.GamingPlatforms);
        }
        [HttpGet("GetGamingPlatformById/{id:int?}", Name = "GetConsoleById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ConsoleDto> GetConsoleById(int id)
        {
            if (id == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var tempObj = db.GamingPlatforms.FirstOrDefault(console => console.id == id);
            if (tempObj == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return StatusCode(StatusCodes.Status200OK, tempObj);
        }
        [HttpPost("CreateGamingPlatform")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ConsoleDto> CreateConsole([FromBody] GamingPlatform gamingPlatform)
        {
            if (gamingPlatform == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            } else if (gamingPlatform.id > 0) {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            db.GamingPlatforms.Add(gamingPlatform);
            db.SaveChanges();
            return CreatedAtRoute("GetConsoleById", new { id = gamingPlatform.id }, gamingPlatform);
        }
        [HttpDelete("DeleteGamingPlatformById/{id:int?}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteConsoleById(int id)
        {
            if (id == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var tempObj = db.GamingPlatforms.FirstOrDefault(console => console.id == id);
            if (tempObj == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            db.GamingPlatforms.Remove(tempObj);
            db.SaveChanges();
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpPut("UpdateGamingPlatformById/{id:int?}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateConsoleById(int id, [FromBody] GamingPlatform gamingPlatform)
        {
            if (id != gamingPlatform.id || gamingPlatform == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var tempObj =db.GamingPlatforms.FirstOrDefault(console => console.id == id);
            if(tempObj == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            db.GamingPlatforms.Update(gamingPlatform);
            db.SaveChanges();

            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpPatch("UpdateGamingPlatformByPatch/{id:int?}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateConsoleByPatch(int id, JsonPatchDocument<GamingPlatform> gamingPlatformPatch)
        {
            if (id == 0 || gamingPlatformPatch == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var tempObj = db.GamingPlatforms.FirstOrDefault(console => console.id == id);
            if (tempObj == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            gamingPlatformPatch.ApplyTo(tempObj, ModelState);

            if(!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            db.GamingPlatforms.Update(tempObj);
            db.SaveChanges();
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}