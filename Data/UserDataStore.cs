using ConsoleApi.Models.DTO;

namespace ConsoleApi.Data
{
    public class UserDataStore
    {
        public static List<UserDto> userList = new List<UserDto>
        {
            new UserDto(0, "gawbillchris@outlook.com", "PoohBear25"),
            new UserDto(1, "gawbillchris@gmail.com", "School24"),
            new UserDto(2, "mattfoster@gmail.com", "ForgettonFores225")
        };
    }
}
