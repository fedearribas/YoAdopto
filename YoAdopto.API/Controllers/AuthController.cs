using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using YoAdopto.API.Data;
using YoAdopto.API.Dtos;
using YoAdopto.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using YoAdopto.API.Contracts;

namespace YoAdopto.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public AuthController(IAuthRepository repo, IConfiguration configuration, IMapper mapper)
        {
            this._mapper = mapper;
            this._configuration = configuration;
            this._repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userDto)
        {
             //validate request
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!string.IsNullOrEmpty(userDto.Username))
                userDto.Username = userDto.Username.ToLower();

            if (await _repo.UserExists(userDto.Username, userDto.Email))
                return BadRequest("El nombre de usuario ya existe");
           
            var userToCreate = _mapper.Map<User>(userDto);
            var createdUser = await _repo.Register(userToCreate, userDto.Password);

            var userToReturn = _mapper.Map<UserToReturnDto>(createdUser);

            return CreatedAtRoute("GetUser", new {controller = "Users", id = createdUser.Id }, userToReturn);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserForLoginDto userDto)
        {
            var userFromRepo = await _repo.Login(userDto.Email.ToLower(), userDto.Password);

            if (userFromRepo == null)
                return Unauthorized();

            // generate token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                    new Claim(ClaimTypes.Name, userFromRepo.Username)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            var user = _mapper.Map<UserToReturnDto>(userFromRepo);

            return Ok(new { tokenString, user });

        }
    }
}