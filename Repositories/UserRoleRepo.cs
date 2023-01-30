﻿using Microsoft.AspNetCore.Identity;
using Paypal.NET.ViewModels;

namespace Paypal.NET.Repositories
{
    public class UserRoleRepo
    {
        IServiceProvider serviceProvider;

        public UserRoleRepo(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        // Assign a role to a user.
        public async Task<bool> AddUserRole(string email, string roleName)
        {
            var UserManager = serviceProvider
                .GetRequiredService<UserManager<IdentityUser>>();
            var user = await UserManager.FindByEmailAsync(email);
            if (user != null)
            {
                await UserManager.AddToRoleAsync(user, roleName);
            }
            return true;
        }

        // Remove role from a user.
        public async Task<bool> RemoveUserRole(string email, string roleName)
        {
            var UserManager = serviceProvider
                .GetRequiredService<UserManager<IdentityUser>>();
            var user = await UserManager.FindByEmailAsync(email);
            if (user != null)
            {
                await UserManager.RemoveFromRoleAsync(user, roleName);
            }
            return true;
        }

        // Get all roles of a specific user.
        public async Task<IEnumerable<RoleVM>> GetUserRoles(string email)
        {
            var UserManager = serviceProvider
                .GetRequiredService<UserManager<IdentityUser>>();
            var user = await UserManager.FindByEmailAsync(email);
            var roles = await UserManager.GetRolesAsync(user);
            List<RoleVM> roleVMObjects = new List<RoleVM>();
            foreach (var item in roles)
            {
                roleVMObjects.Add(new RoleVM() { Id = item, RoleName = item });
            }
            return roleVMObjects;
        }
    }
}
