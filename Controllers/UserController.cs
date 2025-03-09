using BusinessLogic.Services;
using DomainLayer.Models;
using DomainLayer.NewFolder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace PresentationLayer.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Get all users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        // Get user by ID
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            try
            {
                var user = _userService.GetUserById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Add a new user
        [HttpPost]
        public ActionResult<UserResponseDto> AddUser([FromBody] CreateUserDto createUserDto)
        {
            try
            {
                // Validate the DTO and add the user
                var userResponse = _userService.AddUser(createUserDto);

                // Return the created user information in the response
                return userResponse;
            }
            catch (Exception ex)
            {
                // Handle exceptions and return appropriate error response
                return BadRequest(new { message = ex.Message });
            }
        }

        // Update an existing user
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, [FromBody] User user)
        {
            try
            {
                user.Id = id; // Ensure the correct user is being updated
                _userService.UpdateUser(user);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete a user
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
