using Microsoft.AspNetCore.Mvc;
using PREFINALS_QUIZ_PORTFOLIO.Models;

namespace PREFINALS_QUIZ_PORTFOLIO.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
                return RedirectToAction("Login", "Account");

            return View(ProjectRepository.Projects);
        }

        public IActionResult Details(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
                return RedirectToAction("Login", "Account");

            var project = ProjectRepository.Projects.FirstOrDefault(p => p.Id == id);
            if (project == null) return NotFound();

            return View(project);
        }

        [HttpPost]
        public IActionResult AddComment(int projectId, string author, string content)
        {
            var project = ProjectRepository.Projects.FirstOrDefault(p => p.Id == projectId);
            if (project != null && !string.IsNullOrWhiteSpace(content))
            {
                project.Comments.Add(new Comment
                {
                    Id = project.Comments.Count + 1,
                    Author = string.IsNullOrWhiteSpace(author) ? "Anonymous" : author,
                    Content = content,
                    PostedAt = DateTime.Now
                });
            }
            return RedirectToAction("Details", new { id = projectId });
        }
    }
}