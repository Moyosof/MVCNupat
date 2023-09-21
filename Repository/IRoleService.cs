namespace MVCformNupat.Repository
{
    public interface IRoleService
    {
        Task<string> CreateRole(string roleName, string username);
        Task<string> AddUserToRole(string user, string roleName);
    }
}
