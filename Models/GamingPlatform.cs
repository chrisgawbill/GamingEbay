using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApi.Models
{
    public class GamingPlatform
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name {get; set;}
        public string company{get;set;}
        public DateTime dateFirstSold {get; set;}
        public double price {get; set;}

        public GamingPlatform(string name, string company, DateTime dateFirstSold, double price){
            this.name = name;
            this.company = company;
            this.dateFirstSold = dateFirstSold;
            this.price = price;
        }
    }
}