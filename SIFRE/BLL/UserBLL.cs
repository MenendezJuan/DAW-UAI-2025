using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Infrastructure.Interfaces.DAL;
using Infrastructure.Interfaces.BLL;
using BE.Entities;
using BE.DTO;

namespace BLL
{
    public class UserBLL : IUserBLL
    {
        IUserDAL _userDAL;
        public UserBLL(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public void AssignRole(Role role, UserDTO user)
        {
            _userDAL.AssignRole(role, user);
        }

        public bool Block(string username)
        {
            return _userDAL.Block(username);
        }

        public List<UserDTO> GetAllUsers()
        {
            return _userDAL.GetAllUsers();
        }

        public UserDTO? GetByUsernameAndPassword(string username, string password)
        {
            return _userDAL.GetByUsernameAndPassword(username, password);
        }

        public void UpdateUserLanguage(Guid userId, int languageId)
        {
            _userDAL.UpdateUserLanguage(userId, languageId);
        }
    }
}
