using IdentityMovie.Areas.Identity.Data;
using IdentityMovie.Interface;
using IdentityMovie.Models;
using IdentityMovie.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace IdentityMovie.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddComment(Comment comment)
        {
            _context.comments.Add(comment);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteComment(Guid id)
        {
            var cmt = _context.comments.Find(id);
            if (cmt != null)
            {
                _context.comments.Remove(cmt);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Comment> GetCommentById(int CommentId)
        {
            throw new NotImplementedException();
        }

        public List<CommentVM> GetComments(int MovieId)
        {
            var comments = _context.comments.Where(d => d.MovieId == MovieId);
            var result = new List<CommentVM>();
            foreach(var comment in comments)
            {
                var commentVm = new CommentVM()
                {
                    Text = comment.Text,
                    CommentId = comment.CommentId,
                    CreatedAt = comment.CreatedAt,
                    UserName = _context.Users.Find(comment.UserId).UserName
                };

                result.Add(commentVm);
            }

            return result;
        }
    }
}
