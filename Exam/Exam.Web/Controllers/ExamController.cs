using Exam.Core.Service;
using Exam.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Web.Controllers
{
    public class ExamController : Controller
    {
        private readonly ICoreService<Question> _questionService;

        public ExamController(ICoreService<Question> questionService)
        {
            _questionService = questionService;
        }

        public IActionResult Index()
        {
            return View(_questionService.GetAll());
        }
    }
}
