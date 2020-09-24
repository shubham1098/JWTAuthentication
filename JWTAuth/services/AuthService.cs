using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using JWTAuth.Dtos;
using JWTAuth.models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace JWTAuth.services
{
    public class AuthService : IAuthService
    {

        private readonly AppSettings _appSettings;

        public JWTAuthContext _context { get; }

        private readonly IMapper _mapper;

        public AuthService(IOptions<AppSettings> appSettings, JWTAuthContext context, IMapper mapper)
        {
            _appSettings = appSettings.Value;
            _context = context;
            _mapper = mapper;
        }

        public UserReadDto tokenGenerator(UserReadDto user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Version, "v3.1")
                }),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.TokenExpirationDate = token.ValidTo;
            return user;
        }

        public UserReadDto VerifyUser(string email, string password)
        {
            UserReadDto user = _mapper.Map<UserReadDto>(_context.Users.FirstOrDefault(user => user.Email == email && user.Password == password));
            if (user == null)
            {
                return null;
            }
            return tokenGenerator(user);
        }

        public UserReadDto SignUpUser(UserCore user)
        {
            if (_context.Users.Any(users => users.Email == user.Email))
            {
                return null;
            }
            // user.UserRole = "user";
            // user.DateCreated = DateTime.Now;
            _context.Add(_mapper.Map<User>(user));
            _context.SaveChanges();
            UserReadDto newUser = _mapper.Map<UserReadDto>(_context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password));

            return tokenGenerator(newUser);
        }
    }
}