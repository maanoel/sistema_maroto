using System.Collections.Generic;
using LojaVirtual.Data.Converter;
using LojaVirtual.Model;
using System.Linq;

namespace LojaVirtual.Data.Converters
{
    public class UserConverter : IParser<UserVO, User>, IParser<User, UserVO>
    {
        public User Parse(UserVO origin)
        {
            if (origin == null) return new User();
            return new User
            {
                Login = origin.Login,
                AccessKey = origin.AccessKey,
                LastName = origin.LastName,
                Name = origin.Name,
                Birthday = origin.Birthday,
                Email = origin.Email,
                Id = origin.Id
            };
        }

        public UserVO Parse(User origin)
        {
            if (origin == null) return new UserVO();
            return new UserVO
            {
                Login = origin.Login,
                AccessKey = origin.AccessKey,
                Name= origin.Name,
                LastName = origin.LastName,
                Birthday = origin.Birthday,
                Email = origin.Email,
                Id = origin.Id


            };
        }

        public List<User> ParseList(List<UserVO> origin)
        {
            if (origin == null) return new List<User>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<UserVO> ParseList(List<User> origin)
        {
            if (origin == null) return new List<UserVO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
