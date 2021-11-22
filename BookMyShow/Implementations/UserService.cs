using BookMyShow.Database.ApplicationDbContext;
using BookMyShow.Interfaces;
using BookMyShow.Models.DTOModels.InputDTO;
using BookMyShow.Models.Helper;
using System;
using System.Linq;
using System.Text;

namespace BookMyShow.Implementations
{
    public class UserService : IUserService
    {
        private readonly ILoggerManager _logger;
        private readonly ApplicationContext _applicationContext;
        public UserService(ApplicationContext applicationContext, ILoggerManager logger)
        {
            _applicationContext = applicationContext;
            _logger = logger;
        }

   
        public void RegisterUser(RegisterUserDTO registerUserDTO)
        {
            if (_applicationContext.User.Any(x => x.UserName == registerUserDTO.UserName))
                throw new BusinessException("Duplicate", "User already exs.");

            _applicationContext.User.Add(new Models.SystemModels.User()
            {
                UserName =  registerUserDTO.UserName,
                Password =  registerUserDTO.Password
            }
            );
            _applicationContext.SaveChanges();
        }

        public string Login(LoginDTO loginDTO)
        {
            if (!_applicationContext.User.Any(x => x.UserName == loginDTO.UserName))
                throw new BusinessException("Not Found", "User not found.");

            if (!_applicationContext.User.Any(x => x.UserName == loginDTO.UserName && x.Password == loginDTO.Password))
                throw new BusinessException("Invalid Password", "Invalid Password.");

            byte[] username = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            return Convert.ToBase64String(time.Concat(key).ToArray());
        }
    }
}
