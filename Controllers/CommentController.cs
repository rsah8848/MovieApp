using IdentityMovie.Areas.Identity.Data;
using IdentityMovie.Interface;
using IdentityMovie.Models;
using IdentityMovie.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityMovie.Controllers
{
    public class CommentController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICommentRepository _commentRepository;
        public CommentController(UserManager<ApplicationUser> userManager, ICommentRepository commentRepository)
        {
            _userManager = userManager;
            _commentRepository = commentRepository;
        }

        [HttpPost]
        public IActionResult AddComment([Bind("MovieId,Text")] AddCommentVM comment)
        {
            comment.UserId = _userManager.GetUserId(User) ?? throw new ArgumentNullException(nameof(User));
            Comment cmt = new()
            {
                CommentId = Guid.NewGuid(), 
                Text = comment.Text,
                MovieId = comment.MovieId,
                UserId = comment.UserId,
                CreatedAt = DateTime.Now
            };
            _commentRepository.AddComment(cmt);
            //return RedirectToAction("ViewComment", new { MovieId = comment.MovieId });
            return RedirectToAction("Details", "Movie", new { id = comment.MovieId });

        }

        [HttpGet]
        public IActionResult ViewComment(int MovieId)
        {
            var comments = _commentRepository.GetComments(MovieId);
            CommentsVM cmts = new CommentsVM()
            {
                Comments = comments
            };
            return PartialView("ViewComment", cmts); //The ViewComment path should match the actual views
        }

        [HttpGet]
        public IActionResult DeleteComment(int MovieId, Guid CommentId)
        {
            _commentRepository.DeleteComment(CommentId);
            //return RedirectToAction("ViewComment", new { MovieId = MovieId });
            return RedirectToAction("Details", "Movie", new { id = MovieId });

        }

    }
}
