using Microsoft.AspNetCore.Mvc;
using Mini_Social_API.Services;
using Mini_Social_API.Models;

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
		public async Task<ActionResult<List<User>>> GetUsers() 
		{
			var users = await _userService.GetAllAsync();
			return Ok(users);
		}
		[HttpPost]
		public async Task<ActionResult<User>> CreateUser(User user)
		{
			var createdUser = await _userService.CreateAsync(user);
			return CreatedAtAction(nameof(GetUsers), new { id = createdUser.Id }, createdUser);
		}
	}
}