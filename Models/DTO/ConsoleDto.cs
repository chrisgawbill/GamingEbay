using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Globalization;
using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApi.Models.DTO
{
    public class ConsoleDto
    {
        public int id { get; set; }
        public string name {get; set;}
        public string company{get;set;}
        public DateTime dateFirstSold {get; set;}
        public double price {get; set;}

        public ConsoleDto(int id, string name, string company, DateTime dateFirstSold, double price){
            this.id = id;
            this.name = name;
            this.company = company;
            this.dateFirstSold = dateFirstSold;
            this.price = price;
        }
    }
}