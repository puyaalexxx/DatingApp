using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class UsersController : BaseApiController
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository repository)
    {
        _userRepository = repository;
    }
    
    // /api/users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users = await _userRepository.GetMembersAsync();
        
        return Ok(users);
    }
    
    // /api/users/1
    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<MemberDto>> GetUserById(int id)
    {
        var user = await _userRepository.GetMemberByIdAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        return Ok(user);
    }
    
    [HttpGet("{username}")]
    public async Task<ActionResult<MemberDto>> GetUserByUsername(string username)
    {
        var user = await _userRepository.GetMemberAsync(username);

        if (user is null)
        {
            return NotFound();
        }

        return Ok(user);
    }
}