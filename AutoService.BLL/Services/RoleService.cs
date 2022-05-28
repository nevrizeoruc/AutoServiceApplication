﻿using AutoMapper;
using AutoService.BLL.Services.Interfaces;
using AutoService.Common.Utilities;
using AutoService.Core.DTOs;
using AutoService.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public RoleService(RoleManager<AppRole> roleManager, IMapper mapper, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<string> AssignRoleAsync(string email, string role)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);

                if (user == null)
                {
                    return Messages.MissingUserEmail;
                }

                var roleResult = await _roleManager.RoleExistsAsync(role);

                if (!roleResult)
                {
                    return Messages.MissingUserRole;
                }

                var roles = await _userManager.GetRolesAsync(user);

                if (roles != null)
                {
                    if (roles.Contains(role))
                    {
                        return Messages.UserHasThisRole;
                    }
                }

                var response = await _userManager.AddToRoleAsync(user, role);

                if (response.Succeeded)
                {
                    return Messages.Completed;
                }
                return Messages.Failed;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<string> AssignRoleByUserIdAsync(string id, string role)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);

                if (user == null)
                {
                    return Messages.MissingUserId;
                }

                var roleResult = await _roleManager.RoleExistsAsync(role);

                if (!roleResult)
                {
                    return Messages.MissingUserRole;
                }

                var roles = await _userManager.GetRolesAsync(user);

                if (roles != null)
                {
                    if (roles.Contains(role))
                    {
                        return Messages.UserHasThisRole;
                    }
                }

                var response = await _userManager.AddToRoleAsync(user, role);

                if (response.Succeeded)
                {
                    return Messages.Completed;
                }
                return Messages.Failed;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task CreateRoleAsync(string role)
        {
            try
            {
                var result = await _roleManager.RoleExistsAsync(role);
                if (!result)
                {
                    await _roleManager.CreateAsync(new AppRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = role,
                        IsActive = true,
                        CreatedDate = DateTime.Now
                    });
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<string> DeleteRoleAsync(string id)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(id);
                if (role != null)
                {
                    role.IsActive = false;
                    await _roleManager.UpdateAsync(role);
                    return Messages.Completed;
                }
                return Messages.MissingUserRole;

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public List<AppRoleDto> GetActiveRoles()
        {
            try
            {
                var roles = _roleManager.Roles.Where(x => x.IsActive == true);
                if (roles != null)
                {
                    var dtos = _mapper.Map<List<AppRoleDto>>(roles);
                    return dtos;
                }
                throw new InvalidOperationException(Messages.MissingUserRole);

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> IsInRoleAsync(string email, string role)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user != null)
                {
                    return await _userManager.IsInRoleAsync(user, role);
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<string> RemoveRoleFromDbAsync(string id)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(id);
                if (role != null)
                {
                    await _roleManager.DeleteAsync(role);
                    return Messages.Completed;
                }
                return Messages.MissingUserRole;

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> RoleExistAsync(string role)
        {
            try
            {
                return await _roleManager.RoleExistsAsync(role);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
