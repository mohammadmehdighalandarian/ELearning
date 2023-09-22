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

        public void UpdateRolesOfUser(List<long> role, long userId)
        {
            var userRolesOfUser = _siteContext.UserRoles.Where(x => x.UserId == userId);
            _siteContext.UserRoles.RemoveRange(userRolesOfUser);
           
           AddRole(role,userId);
            
        }

        public Role GetRole(long roleId)
        {
            return _siteContext.Roles.Find(roleId);
        }

        public void UpdateRole(Role role)
        {
            _siteContext.Roles.Update(role);
            SaveChange();
        }

        public void DeleteRole(Role role)
        {
            role.IsDeleted = true;
            UpdateRole(role);
        }

        public void SaveChange()
        {
            _siteContext.SaveChanges();
        }
    }
}
