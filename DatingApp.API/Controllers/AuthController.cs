using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Data.Entities;
using DatingApp.API.DTOs;
using DatingApp.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : BaseController
    {
        private readonly DataContext _context;

        private readonly ITokenService _tokenService;
        public AuthController(DataContext context, ITokenService tokenService)
        {
            this._context = context;
            this._tokenService = tokenService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] AuthUserDto authUserDto)
        {
            authUserDto.Username = authUserDto.Username.ToLower();
            if (_context.AppUsers.Any(u => u.Username == authUserDto.Username))
            {
                return BadRequest("Username is already registered!");
            }

            using var hmac = new HMACSHA512();
            var passwordBytes = Encoding.UTF8.GetBytes(authUserDto.Password);
            var newUser = new User
            {
                Username = authUserDto.Username,
                PasswordSalt = hmac.Key,
                PasswordHashed = hmac.ComputeHash(passwordBytes)
            };
            _context.AppUsers.Add(newUser);
            _context.SaveChanges();
            var token = _tokenService.CreateToken(newUser.Username);
            return Ok(token);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthUserDto authUserDto)
        {
            authUserDto.Username = authUserDto.Username.ToLower();
            var currentUser = _context.AppUsers
                .FirstOrDefault(u => u.Username == authUserDto.Username);

            if (currentUser == null)
            {
                return Unauthorized("Username is invalid.");
            }

            using var hmac = new HMACSHA512(currentUser.PasswordSalt);
            var passwordBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(authUserDto.Password));
            for (int i = 0; i < currentUser.PasswordHashed.Length; i++)
            {
                if (currentUser.PasswordHashed[i] != passwordBytes[i])
                {
                    return Unauthorized("Password is invalid.");
                }
            }

            var token = _tokenService.CreateToken(currentUser.Username);
            return Ok(token);
        }

        // [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.AppUsers.ToList());
        }
    }
}