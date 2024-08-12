﻿using API.DTOs;
using API.Entities;
using API.Helpers;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Interfaces;

public interface IUserRepository
{
    void Update(AppUser user);

    Task<bool> SaveAllAsync();

    Task<IEnumerable<AppUser>> GetUsersAsync();

    Task<AppUser?> GetUserByIdAsync(int id);
    
    Task<AppUser?> GetUserByUsernameAsync(string username);

    Task<PageList<MemberDto>> GetMembersAsync(UserParams userParams);

    Task<MemberDto?> GetMemberAsync(string username);
    
    Task<MemberDto?> GetMemberByIdAsync(int id);
}