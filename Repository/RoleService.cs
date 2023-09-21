using Microsoft.AspNetCore.Identity;
using MVCformNupat.Model;

namespace MVCformNupat.Repository
{
    public class RoleService : IRoleService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(RoleManager<IdentityRole> role, UserManager<ApplicationUser> user)
        {
            _roleManager = role;
            _userManager = user;
        }

        public async Task<string> AddUserToRole(string user, string roleName)
        {
            var find = await _userManager.FindByNameAsync(user);
            if (find != null)
            {
                var checkrole = await _roleManager.RoleExistsAsync(roleName);
                if (checkrole == true)
                {
                    var checkuser = await _userManager.IsInRoleAsync(find, roleName);
                    if (checkuser == false)
                    {
                        var result = await _userManager.AddToRoleAsync(find, roleName);
                        if (result.Succeeded)
                        {
                            return string.Empty;
                        }
                        else
                        {
                            return result.Errors.First().Description;
                        }
                    }
                    return $"User already in {roleName}";
                }
                return "Role not Exist";
            }
            return "User not found";
        }

        public async Task<string> CreateRole(string roleName, string username)
        {

            // Check if the role already exists
            var checkIfRoleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!checkIfRoleExist)
            {
                // Create the role
                var role = new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = roleName,
                };
                var roleResult = await _roleManager.CreateAsync(role);

                if (roleResult.Succeeded)
                {
                    // Find the user by username
                    var user = await _userManager.FindByNameAsync(username);

                    if (user != null)
                    {
                        // Assign the role to the user
                        var assignmentResult = await _userManager.AddToRoleAsync(user, roleName);

                        if (assignmentResult.Succeeded)
                        {
                            return string.Empty;
                        }
                        else
                        {
                            // Handle role assignment error
                            return assignmentResult.Errors.First().Description;
                        }
                    }
                    else
                    {
                        // Handle user not found error
                        return "User not found";
                    }
                }
                else
                {
                    // Handle role creation error
                    return roleResult.Errors.First().Description;
                }
            }
            else
            {
                // Handle role already exists error
                return "Role already exists";
            }
        }
    }
}

