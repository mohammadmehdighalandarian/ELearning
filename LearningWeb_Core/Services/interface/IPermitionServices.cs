using DataLayer.Entities.User;

namespace LearningWeb_Core.Services
{
    public interface IPermitionServices
    {
        #region Roles

        List<Role> GetAllRoles();
        void AddRole(List<long> role, long userId);

        void UpdateRoles(List<long> role, long userId);


        #endregion
    }
}
