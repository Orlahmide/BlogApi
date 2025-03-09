using BusinessLogic.Services;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace PresentationLayer.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        // Get all posts
        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetAllPosts()
        {
            return Ok(_postService.GetAllPosts());
        }

        // Get post by ID
        [HttpGet("{id}")]
        public ActionResult<Post> GetPostById(int id)
        {
            try
            {
                var post = _postService.GetPostById(id);
                return Ok(post);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Add a new post
        [HttpPost]
        public ActionResult AddPost([FromBody] Post post)
        {
            try
            {
                _postService.AddPost(post);
                return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update an existing post
        [HttpPut("{id}")]
        public ActionResult UpdatePost(int id, [FromBody] Post post)
        {
            try
            {
                post.Id = id; // Ensure the correct post is being updated
                _postService.UpdatePost(post);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete a post
        [HttpDelete("{id}")]
        public ActionResult DeletePost(int id)
        {
            try
            {
                _postService.DeletePost(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
