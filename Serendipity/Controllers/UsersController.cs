﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serendipity.DTOs;
using Serendipity.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Serendipity.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        
        private readonly IUserRepository userRepo;
        private readonly IMapper mapper;

        public UsersController(IUserRepository userRepo, IMapper mapper)
        {
            this.userRepo = userRepo;
            this.mapper = mapper;
        }

        // api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await userRepo.GetMembersAsync();

            return Ok(users);
        }

        //api/users/1
        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            return await userRepo.GetMemberAsync(username);


        }
    }
}
