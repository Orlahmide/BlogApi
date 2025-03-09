using BusinessLogic.Interfaces;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace PresentationLayer.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // Get all comments for a post
        [HttpGet("post/{postId}")]
        public ActionResult<IEnumerable<Comment>> GetCommentsByPostId(int postId)
        {
            try
            {
                var comments = _commentService.GetCommentsByPostId(postId);
                return Ok(comments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get a comment by ID
        [HttpGet("{id}")]
        public ActionResult<Comment> GetCommentById(int id)
        {
            try
            {
                var comment = _commentService.GetCommentById(id);
                return Ok(comment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Add a new comment
        [HttpPost]
        public ActionResult AddComment([FromBody] Comment comment)
        {
            try
            {
                _commentService.AddComment(comment);
                return Ok("Comment added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update an existing comment
        [HttpPut("{id}")]
        public ActionResult UpdateComment(int id, [FromBody] Comment comment)
        {
            try
            {
                comment.Id = id; // Ensure ID consistency
                _commentService.UpdateComment(comment);
                return Ok("Comment updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete a comment
        [HttpDelete("{id}")]
        public ActionResult DeleteComment(int id)
        {
            try
            {
                _commentService.DeleteComment(id);
                return Ok("Comment deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
