using DataLayer.Content;
using DataLayer.Entities.User;
using LearningWeb_Core.DTOs.Account;
using LearningWeb_Core.Generator;

namespace LearningWeb_Core.Services
{
    public class UserServices:IUserServices
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

        public User GetUserBy(string username)
        {
            return _siteContext.Users.SingleOrDefault(x => x.UserName == username);
        }

        public long AddUser(User user)
        {
            _siteContext.Users.Add(user);
            _siteContext.SaveChanges();
            return user.Id;
        }

        public User loginUser(LoginViewModel user)
        {
            return _siteContext.Users.SingleOrDefault(x => x.Email == user.Email);
        }

        public bool ActiveUser(string activationCode)
        {
            var User=_siteContext.Users.SingleOrDefault(x=>x.ActivateCode==activationCode);

            if (User==null||User.IsActive)
            {
                return false;
            }
            User.IsActive= true;
            User.ActivateCode = ActivationCode.GenerateActivationCode();
            _siteContext.SaveChanges();

            return true;
        }

        public PannelAccountViewModel ShowInfoInPannel(string username)
        {
            var User = GetUserBy(username);
            PannelAccountViewModel UserVM = new PannelAccountViewModel()
            {
                Username = User.UserName,
                Email = User.Email,
                CreationDate = User.RegisterDate
            };
            return UserVM;
        }
    }
}
