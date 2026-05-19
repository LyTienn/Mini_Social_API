using Microsoft.AspNetCore.Mvc;
using Mini_Social_API.Dtos;
using Mini_Social_API.Services;

namespace Mini_Social_API.Controllers 
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;
		public UsersController(IUserService userService)
		{
			_userService = userService;
		}
		[HttpGet]
		public async Task<ActionResult<List<UserResponseDto>>> GetUsers() 
		{
			var users = await _userService.GetAllAsync();
			return Ok(users);
		}
		[HttpPost]
		public async Task<ActionResult<UserResponseDto>> CreateUser(CreateUserDto dto)
		{
			var createdUser = await _userService.CreateAsync(dto);
			return CreatedAtAction(nameof(GetUsers), new { id = createdUser.Id }, createdUser);
		}
	}
}