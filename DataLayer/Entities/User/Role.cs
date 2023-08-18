namespace DataLayer.Entities.User
{
    public class Role
    {
        public long Id { get; set; }

        public string RoleName { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
