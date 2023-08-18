using DataLayer.Entities.User;
using LearningWeb_Core.DTOs.Account;

namespace LearningWeb_Core.Services
{
    public interface IUserServices
    {
        public bool IsEmailExist(string email);

        public bool IsUserNameExist(string userName);

        long AddUser(User user);

        User loginUser(LoginViewModel usee);
    }
}
