using BusinessLogic.Interfaces;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace PresentationLayer.Controllers
{
    [Route("api/likes")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        // Get likes for a post
        [HttpGet("post/{postId}")]
        public ActionResult<IEnumerable<Like>> GetLikesByPostId(int postId)
        {
            try
            {
                var likes = _likeService.GetLikesByPostId(postId);
                return Ok(likes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get like count for a post
        [HttpGet("count/{postId}")]
        public ActionResult<int> GetLikeCountByPostId(int postId)
        {
            try
            {
                var count = _likeService.GetLikeCountByPostId(postId);
                return Ok(count);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Add a like
        [HttpPost]
        public ActionResult AddLike([FromQuery] int userId, [FromQuery] int postId)
        {
            try
            {
                _likeService.AddLike(userId, postId);
                return Ok("Like added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Remove a like
        [HttpDelete]
        public ActionResult RemoveLike([FromQuery] int userId, [FromQuery] int postId)
        {
            try
            {
                _likeService.RemoveLike(userId, postId);
                return Ok("Like removed successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
