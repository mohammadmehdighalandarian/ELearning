using DataLayer.Content;
using DataLayer.Entities.User;
using LearningWeb_Core.DTOs.Account;
using LearningWeb_Core.DTOs.UserPanel;
using LearningWeb_Core.Generator;

namespace LearningWeb_Core.Services
{
    public class UserServices : IUserServices
    {
        private readonly SiteContext _siteContext;

        public UserServices(SiteContext siteContext)
        {
            _siteContext = siteContext;
        }

        public bool IsEmailExist(string email)
        {
            return _siteContext.Users.Any(u => u.Email == email);
        }

        public bool IsUserNameExist(string userName)
        {
            return _siteContext.Users.Any(x => x.UserName == userName);
        }

        public void UpdateUser(User user)
        {
            _siteContext.Users.Update(user);
        }

        public void SaveChange()
        {
            _siteContext.SaveChanges();
        }

        public User GetUserBy(string username)
        {
            return _siteContext.Users.SingleOrDefault(x => x.UserName == username);
        }

        public User getUserByActiveCode(string activeCode)
        {
            return _siteContext.Users.SingleOrDefault(x => x.ActivateCode == activeCode);
        }

        public long AddUser(User user)
        {
            _siteContext.Users.Add(user);
            SaveChange();
            return user.Id;
        }

        public User loginUser(LoginViewModel user)
        {
            return _siteContext.Users.SingleOrDefault(x => x.Email == user.Email);
        }

        public User GetUserByEmail(string email)
        {
            return _siteContext.Users.SingleOrDefault(x => x.Email == email);
        }

        public bool ActiveUser(string activationCode)
        {
            var User = _siteContext.Users.SingleOrDefault(x => x.ActivateCode == activationCode);

            if (User == null || User.IsActive)
            {
                return false;
            }
            User.IsActive = true;
            User.ActivateCode = UniqCode.GenerateUniqCode();
            SaveChange();

            return true;
        }

        public void ResetPassword(string activeCode, string newPassword)
        {
            var User = getUserByActiveCode(activeCode);
            User.Password = newPassword;
            _siteContext.Users.Update(User);
            SaveChange();

        }

        public PannelAccountViewModel GetInformaion(string username)
        {
            var User = GetUserBy(username);
            PannelAccountViewModel UserVM = new PannelAccountViewModel()
            {
                UserName = User.UserName,
                Email = User.Email,
                RegisterDate = User.RegisterDate,
                Wallet = 0
            };
            return UserVM;
        }


        public EditUserViewModel EditUser(string username)
        {
            return _siteContext.Users.Where(x => x.UserName == username).Select(x => new EditUserViewModel()
            {
                userName = x.UserName,
                Email = x.Email,
            }).Single();
        }

        public EditPictureUser editPicture(string username)
        {
            return _siteContext.Users.Where(x => x.UserName == username).Select(u => new EditPictureUser()
            {
                AvatarName = u.UserAvatar
            }).Single();
        }

        public void EditPicture(string username, EditPictureUser editPicture)
        {
            if (editPicture.UserAvatar != null)
            {
                string imagePath = "";
                if (editPicture.AvatarName != "Defualt.png")
                {
                    imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", editPicture.AvatarName);
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }

                editPicture.AvatarName = UniqCode.GenerateUniqCode() + Path.GetExtension(editPicture.UserAvatar.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", editPicture.AvatarName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    editPicture.UserAvatar.CopyTo(stream);
                }
            }

            var user = GetUserBy(username);
            
            user.UserAvatar = editPicture.AvatarName;
           

            UpdateUser(user);
            SaveChange();
        }

        public SideBarUserPanelViewModel sideBarInfo(string username)
        {
            return _siteContext.Users.Where(x => x.UserName == username).Select(u => new SideBarUserPanelViewModel()
            {
                UserName = u.UserName,
                ImageName = u.UserAvatar,
                RegisterDate = u.RegisterDate
            }).Single();
        }

        public bool IsOldPassTrue(string username, string oldPass)
        {
            return _siteContext.Users.Any(x => x.UserName == username && x.Password == oldPass);
        }

        public void ChangePassword(string username, string newPassword)
        {
            var user= GetUserBy(username);
            user.Password = newPassword;
            UpdateUser(user);
            SaveChange();
        }

        public void EditProfile(string username, EditUserViewModel editUser)
        {
            
            var user = GetUserBy(username);
            user.UserName = editUser.userName;
            user.Email = editUser.Email;

            UpdateUser(user);
            SaveChange();
        }
    }
}
