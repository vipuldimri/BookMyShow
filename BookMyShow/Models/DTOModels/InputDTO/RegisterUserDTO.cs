using System.ComponentModel.DataAnnotations;

namespace BookMyShow.Models.DTOModels.InputDTO
{
    public class RegisterUserDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
