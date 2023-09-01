using DataLayer.Entities.User;
using LearningWeb_Core.DTOs.Account;

namespace LearningWeb_Core.Services
{
    public interface IUserServices
    {
        bool IsEmailExist(string email);

        bool IsUserNameExist(string userName);

        long AddUser(User user);

        User GetUserBy(string username);

        User getUserByActiveCode(string activeCode);

        User loginUser(LoginViewModel user);

        User GetUserByEmail(string email);

        bool ActiveUser(string activationCode);

        void ResetPassword(string activeCode,string newPassword);

        PannelAccountViewModel ShowInfoInPannel(string userName);

    }
}
