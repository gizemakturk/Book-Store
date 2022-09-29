﻿ using AutoMapper;
using BookStore.Application.UserOperations.Commands.CreateUser;
using BookStore.Application.UserOperations.CreateToken;
using BookStore.Application.UserOperations.RefreshToken;
using BookStore.DBOperations;
using BookStore.TokenOperations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.Eventing.Reader;
using static BookStore.Application.UserOperations.Commands.CreateUser.CreateUserCommand;
using static BookStore.Application.UserOperations.CreateToken.CreateTokenCommand;

namespace BookStore.Controllers
{
    [ApiController] 
    [Route("[Controller]s")]
   
    public class UserController:ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;

        public UserController(IBookStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        [HttpPost]
         public IActionResult Create([FromBody] CreateUserModel newUser)
        {
            CreateUserCommand command = new CreateUserCommand(_context, _mapper);
            command.Model = newUser;
            command.Handle();
            return Ok();
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        { 
            CreateTokenCommand command = new CreateTokenCommand(_context, _mapper,_configuration);
            command.Model = login;
            var token = command.Handle();
            return token;
        }
        [HttpPost("refreshToken")]
        public ActionResult<Token> RefreshToken([FromBody]string token)
        {
            RefreshTokenCommand command = new RefreshTokenCommand(_context, _configuration);
            command.RefreshToken = token;
            var resultToken = command.Handle();
            return resultToken;
        }
    }
}
