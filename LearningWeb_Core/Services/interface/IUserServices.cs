using DataLayer.Entities.User;
using LearningWeb_Core.DTOs.Account;
using LearningWeb_Core.DTOs.UserPanel;

namespace LearningWeb_Core.Services
{
    public interface IUserServices
    {
        bool IsEmailExist(string email);

        bool IsUserNameExist(string userName);

        long AddUser(User user);

        void UpdateUser(User user);

        void SaveChange();

        User GetUserBy(string username);

        User getUserByActiveCode(string activeCode);

        User loginUser(LoginViewModel user);

        User GetUserByEmail(string email);

        bool ActiveUser(string activationCode);

        void ResetPassword(string activeCode,string newPassword);

        #region Panel

        PannelAccountViewModel GetInformaion(string userName);
        //PannelAccountViewModel GetUserInformation(int userId);

        EditUserViewModel EditUser(string username);

        EditPictureUser editPicture(string username);

        void EditPicture(string username, EditPictureUser editPicture);
        void EditProfile(string username,EditUserViewModel editUser);
        SideBarUserPanelViewModel sideBarInfo(string username);

        bool IsOldPassTrue(string username,string oldPass);
        void ChangePassword(string username,string newPassword);


        #endregion



    }
}
