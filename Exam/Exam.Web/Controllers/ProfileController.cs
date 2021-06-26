using Exam.Core.Service;
using Exam.Model.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using twitterClone.Models;

namespace Exam.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ICoreService<Student> _studentService;
        public ProfileController(ICoreService<Student> studentService)
        {
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            HttpContext.Request.Cookies.TryGetValue("id", out string gelen);
            var student = _studentService.GetById(Guid.Parse(gelen));
            return View(student);
        }

        [HttpPost]
        public IActionResult Update(Guid id)
        {
            HttpContext.Request.Cookies.TryGetValue("id", out string gelen);
            var student = _studentService.GetById(Guid.Parse(gelen));
            if (ModelState.IsValid)
            {
                Student updated = _studentService.GetById(student.ID);
                updated.Name = student.Name;
                updated.Class = student.Class;
                updated.Department = student.Department;
                updated.Email = student.Email;
                updated.Password = student.Password;
                updated.Phone = student.Phone;
                updated.ProfileImageURL = student.ProfileImageURL;
                bool result = _studentService.Update(updated);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "Güncelleme sırasında bir hata oluştu.";
                }

            }
            else
            {
                TempData["Message"] = "İşlem başarısız oldu. Lütfen tüm alanları kontol edin.";
            }
            return View(student);
        }

    }
}
