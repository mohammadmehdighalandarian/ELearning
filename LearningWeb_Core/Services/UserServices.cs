using DataLayer.Content;
using DataLayer.Entities.User;

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

        public long AddUser(User user)
        {
            _siteContext.Users.Add(user);
            _siteContext.SaveChanges();
            return user.Id;
        }
    }
}
