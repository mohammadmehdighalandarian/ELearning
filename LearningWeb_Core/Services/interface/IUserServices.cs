using DataLayer.Entities.User;
using LearningWeb_Core.DTOs.Account;

namespace LearningWeb_Core.Services
{
    public interface IUserServices
    {
        public bool IsEmailExist(string email);

        public bool IsUserNameExist(string userName);

        public User GetUserBy(string username);

        long AddUser(User user);

        User loginUser(LoginViewModel user);

        bool ActiveUser(string activationCode);
            
        PannelAccountViewModel ShowInfoInPannel(string userName);

    }
}
