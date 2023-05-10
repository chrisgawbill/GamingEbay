using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApi.Models.DTO;

namespace ConsoleApi.Data
{
    public class ConsoleDataStore
    {
           public static List<ConsoleDto> consoleList = new List<ConsoleDto>{
                new ConsoleDto(1, "64", "Nintendo", new DateTime(1996, 06, 23), 200.00),
                new ConsoleDto(2, "Gamecube", "Nintendo", new DateTime(2001, 09, 14), 200.00),
                new ConsoleDto(3, "Super NES", "Nintendo", new DateTime(1991, 08, 23), 200.00)
            };
    }
}