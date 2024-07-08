using IdentityMovie.Models;
using IdentityMovie.Models.ViewModel;

namespace IdentityMovie.Interface
{
    public interface ICommentRepository
    {
        bool AddComment(Comment comment);
        List<CommentVM> GetComments(int MovieId);
        bool DeleteComment(Guid id);
        List<Comment> GetCommentById(int CommentId);

    }
}
