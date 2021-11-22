using BookMyShow.Database.ApplicationDbContext;
using BookMyShow.Interfaces;
using BookMyShow.Models.DTOModels.InputDTO;
using System;
using System.Linq;
using System.Text;

namespace BookMyShow.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext _applicationContext;
        public UserService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

   
        public void RegisterUser(RegisterUserDTO registerUserDTO)
        {
            if (_applicationContext.User.Any(x => x.UserName == registerUserDTO.UserName))
            {
                throw new Exception("Plese choose different username");
            }

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
            {
                throw new Exception("No User Found");
            }

            if (!_applicationContext.User.Any(x => x.UserName == loginDTO.UserName && x.Password == loginDTO.Password))
            {
                throw new Exception("Invalid Password");
            }


            byte[] username = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            return Convert.ToBase64String(time.Concat(key).ToArray());
        }


        private string GenerateToken(string userName)
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            byte[] userNamekey = Encoding.ASCII.GetBytes(userName);
            return Convert.ToBase64String(userNamekey.Concat(time).Concat(key).ToArray());
        }


        private string ValidateToken(string token)
        {
            byte[] data = Convert.FromBase64String(token);
            DateTime when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
            if (when < DateTime.UtcNow.AddHours(-24))
            {
                //expire
            }
            return "";
        }

    }
}
