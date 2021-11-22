using BookMyShow.Models.DTOModels.InputDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShow.Interfaces
{
    public interface IUserService
    {
        void RegisterUser(RegisterUserDTO registerUserDTO);
        string Login(LoginDTO loginDTO);
    }
}
