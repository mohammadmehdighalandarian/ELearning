using DataLayer.Entities.User;

namespace LearningWeb_Core.Services
{
    public interface IPermitionServices
    {
        #region Roles

        List<Role> GetAllRoles();
        void AddRole(List<long> role, long userId);
        void UpdateRolesOfUser(List<long> role, long userId);
        Role GetRole(long roleId);
        void UpdateRole(Role role);
        void DeleteRole(Role role);
        void SaveChange();


        #endregion
    }
}
