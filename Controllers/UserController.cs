using ConsoleApi.Data;
using ConsoleApi.Models;
using ConsoleApi.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApi.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("RegisterUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<User> RegisterUser([FromBody] User user)
        {
            if (user == null || user.id > 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            UserDto checkEmailObj = UserDataStore.userList.Find(userDto => userDto.email == user.email);
            if(checkEmailObj != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Email already taken");
            }
            int latestUserId = UserDataStore.userList.OrderByDescending(userDto => userDto.id).FirstOrDefault()!.id; 
            int newUserId = latestUserId + 1;   
            UserDto tempUserDtoObj = new UserDto(newUserId, user.email, user.password);
            UserDataStore.userList.Add(tempUserDtoObj);
            return CreatedAtRoute("GetUserById", new { id = user.id }, user);
        }
        [HttpGet("GetUserById/{id:int?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<User> GetUserById(int id)
        {
            if(id <= 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            UserDto tempUserDtoObj = UserDataStore.userList.FirstOrDefault(user => user.id == id);
            if(tempUserDtoObj == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return StatusCode(StatusCodes.Status200OK, tempUserDtoObj);
        }
        [HttpGet("GetUserByLogin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDto> GetUserByLogin([FromBody] Login login)
        {
            if(login == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            UserDto tempUserDtoObj = UserDataStore.userList.FirstOrDefault(user => (user.email == login.email && user.password== login.password));
            if(tempUserDtoObj == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return StatusCode(StatusCodes.Status200OK, tempUserDtoObj);
        }
        [HttpDelete("DeleteUserById/{id:int?}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteUserById(int id)
        {
            if(id <= 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            UserDto tempUserDtoObj = UserDataStore.userList.FirstOrDefault(user => user.id == id); 
            if(tempUserDtoObj == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            UserDataStore.userList.Remove(tempUserDtoObj);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpPut("UpdateUserById")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateUserById(int id, [FromBody] UserDto userDto)
        {
            if(id <= 0 || id != userDto.id)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            UserDto tempUserDtoObj = UserDataStore.userList.FirstOrDefault(user => user.id == userDto.id)!;

            tempUserDtoObj.email = userDto.email;
            tempUserDtoObj.password = userDto.password;
            tempUserDtoObj.cart = userDto.cart;
            tempUserDtoObj.sellingList = userDto.sellingList;

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
