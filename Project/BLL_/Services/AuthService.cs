using AutoMapper;
using BLL_.DTO;
using BLL_.Interfaces;
using DAL_.Entyties;
using DAL_.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL_.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IMapper mapper,
             UserManager<User> userManager, 
             SignInManager<User> signInManager,
             IUnitOfWork unit)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unit;
        }

        public async Task<string> GenerateToken(UserDTO user, string keyWord)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Hash,user.PasswordHash)
            };

            var roles = await _userManager.GetRolesAsync(_mapper.Map<User>(user));

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyWord));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<UserDTO> LogIn(UserForLoginDTO user)
        {
            var mainUser = await _userManager.FindByEmailAsync(user.Email);

            if (mainUser == null)
            {
                return null;
            }

            var result = await _signInManager
                .CheckPasswordSignInAsync(mainUser, user.Password, false);

            if (result.Succeeded)
            {
                var appUser = await _userManager.FindByEmailAsync(mainUser.Email);

                return _mapper.Map<UserDTO>(appUser);
            }

            return null;
        }

        public async Task<UserDTO> Register(UserForRegisterDTO user)
        {
            var userToCreate = _mapper.Map<User>(user);

            var result = await _userManager.CreateAsync(userToCreate, user.Password);

            var userToReturn = _mapper.Map<UserDTO>(userToCreate);

            if (result.Succeeded)
            {
                var usertoAddRole = _userManager.FindByEmailAsync(userToReturn.Email).Result;
                _userManager.AddToRolesAsync(usertoAddRole, new[] { "Member" }).Wait();
                return userToReturn;
            }
            return null;
        }

        public async Task<bool> AddRole(string userEmail, string role)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(userEmail);
                var res = await _userManager.AddToRoleAsync(user, role);

                if (res.Succeeded)
                {
                    return await _unitOfWork.SaveChangesAsync();
                }

                return false;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
