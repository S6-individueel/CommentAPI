using CommentAPI.CommentData;
using CommentAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        private ICommentData _commentData;

        public CommentController(ICommentData commentData)
        {
            _commentData = commentData;
        }

        [HttpGet]
        public IActionResult GetAllComments()
        {
            return Ok(_commentData.GetAllComments());
        }

        [HttpGet("{id}")]
        public IActionResult GetCommentById(int id)
        {
            var comment = _commentData.GetCommentById(id);

            if (comment != null)
            {
                return Ok(comment);
            }
            return NotFound($"Comment with id: {id} was not found");
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            _commentData.AddComment(comment);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + comment.Id, comment);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            var comment = _commentData.GetCommentById(id);

            if (comment != null)
            {
                _commentData.DeleteComment(comment);
                return Ok();
            }
            return NotFound($"Comment with id: {id} was not found");
        }

        [HttpPatch("{id}")]
        public IActionResult ModifyComment(int id, Comment comment)
        {
            var existingComment = _commentData.GetCommentById(id);

            if (existingComment != null)
            {
                comment.Id = existingComment.Id;
                comment.MovieId = existingComment.MovieId;
                comment.UserId = existingComment.UserId;
                comment.Likes = existingComment.Likes;
                _commentData.ModifyComment(comment);
                return Ok();
            }
            return NotFound($"Comment with id: {id} was not found");
        }

        [HttpGet("movie/{id}")]
        public IActionResult GetCommentsByMovieId(int id)
        {
            var existingMovieComments = _commentData.GetCommentsByMovieId(id);

            if (existingMovieComments != null)
            {
                return Ok(existingMovieComments);
            }
            return NotFound($"Comments for the movie with id: {id} was not found");
        }

        [HttpGet("user/{id}")]
        public IActionResult GetCommentsByUserId(Guid id)
        {
            var existingUserComments = _commentData.GetCommentsByUserId(id);

            if (existingUserComments != null)
            {
                return Ok(existingUserComments);
            }
            return NotFound($"Comments for the user with id: {id} was not found");
        }
    }
}
