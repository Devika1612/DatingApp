using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{

    [Authorize]
    public class UsersController:BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository,IMapper mapper)
        {
            _mapper=mapper;
        _userRepository=userRepository;
        }

[HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users=await _userRepository.GetUsersAsync();
            var usersToReturn=_mapper.Map<IEnumerable<MemberDTO>>(users);
        
            return Ok(usersToReturn);
           
        } 
        [Authorize]
        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDTO>> GetUser(string username)
        {
        var user=await  _userRepository.GetUserByUsernameAsync(username);
        return _mapper.Map<MemberDTO>(user);
       
        }
    }
}