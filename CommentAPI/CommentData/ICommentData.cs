using CommentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommentAPI.CommentData
{
    public interface ICommentData
    {
        List<Comment> GetAllComments();

        Comment GetCommentById(int id);

        List<Comment> GetCommentsByUserId(Guid id);

        List<Comment> GetCommentsByMovieId(int id);

        Comment AddComment(Comment comment);

        void DeleteComment(Comment comment);

        void DeleteComments(Guid id);

        Comment ModifyComment(Comment comment);
    }
}
