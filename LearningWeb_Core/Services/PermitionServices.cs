using DataLayer.Content;
using DataLayer.Entities.User;

namespace LearningWeb_Core.Services
{
    public class PermitionServices:IPermitionServices
    {
        private readonly SiteContext _siteContext;

        public PermitionServices(SiteContext siteContext)
        {
            _siteContext = siteContext;
        }
        public List<Role> GetAllRoles()
        {
            return _siteContext.Roles.ToList();
        }

        public void AddRole(List<long> role, long userId)
        {
            foreach (var roleid in role)
            {
                _siteContext.UserRoles.Add(new UserRole()
                {
                    RoleId = roleid,
                    UserId = userId
                });

            }

            _siteContext.SaveChanges();
        }
    }
}
