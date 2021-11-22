using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShow.Models.SystemModels
{
    public class User 
    {
        [Key]
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
