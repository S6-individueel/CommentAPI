using CommentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommentAPI.CommentData
{
    public class SqlCommentData : ICommentData
    {
        private CommentsContext _commentsContext;

        public SqlCommentData(CommentsContext commentsContext)
        {
            _commentsContext = commentsContext;
        }

        public Comment AddComment(Comment comment)
        {
            comment.Likes = 0;

            _commentsContext.Add(comment);
            _commentsContext.SaveChanges();
            return comment;
        }

        public void DeleteComment(Comment comment)
        {
            _commentsContext.Remove(comment);
            _commentsContext.SaveChanges();
        }

        public void DeleteComments(Guid id)
        {
            foreach (var comment in _commentsContext.Comments.Where(r => r.UserId == id))
            {
                _commentsContext.Remove(comment);
                _commentsContext.SaveChanges();
            }
        }

        public List<Comment> GetAllComments()
        {
            return _commentsContext.Comments.ToList();
        }

        public Comment GetCommentById(int id)
        {
            return _commentsContext.Comments.Find(id);
        }

        public List<Comment> GetCommentsByMovieId(int id)
        {
            List<Comment> comments = new List<Comment>();
            foreach (var comment in _commentsContext.Comments.Where(r => r.MovieId == id))
            {
                comments.Add(new Comment()
                {
                    Id = comment.Id,
                    UserId = comment.UserId,
                    MovieId = comment.MovieId,
                    UserComment = comment.UserComment,
                    Likes = comment.Likes
                });
            }
            return comments;
        }

        public List<Comment> GetCommentsByUserId(Guid id)
        {
            List<Comment> comments = new List<Comment>();
            foreach (var comment in _commentsContext.Comments.Where(r => r.UserId == id))
            {
                comments.Add(new Comment()
                {
                    Id = comment.Id,
                    UserId = comment.UserId,
                    MovieId = comment.MovieId,
                    UserComment = comment.UserComment,
                    Likes = comment.Likes
                });
            }
            return comments;
        }

        public Comment ModifyComment(Comment comment)
        {
            var existingComment = _commentsContext.Comments.Find(comment.Id);
            if (existingComment != null)
            {
                existingComment.UserComment = comment.UserComment;

                _commentsContext.Comments.Update(existingComment);
                _commentsContext.SaveChanges();
            }
            return comment;
        }
    }
}
