using Exam.Core.Service;
using Exam.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using twitterClone.Models;

namespace Exam.Web.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class StudentController : Controller
    {
        private readonly ICoreService<Student> _studentService;
        private readonly IWebHostEnvironment _env;

        public StudentController(ICoreService<Student> studentService, IWebHostEnvironment env)
        {
            _studentService = studentService;
            _env = env;
        }

        public IActionResult Index()
        {
            return View(_studentService.GetAll());
        }

        public IActionResult Delete(Guid id)
        {
            _studentService.Remove(_studentService.GetById(id));
            return RedirectToAction("Index");
        }

        public IActionResult Activate(Guid id)
        {
            _studentService.Active(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return View(HttpStatusCode.BadRequest);
            }
            var student = _studentService.GetById(id.GetValueOrDefault());
            if (student == null)
            {
                return View(HttpStatusCode.NotFound);
            }
            return View(student);
        }

        public IActionResult Update(Guid? id)
        {
            if (id == null)
            {
                return View(HttpStatusCode.BadRequest);
            }
            var student = _studentService.GetById(id.GetValueOrDefault());
            if (student == null)
            {
                return View(HttpStatusCode.NotFound);
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Update(Student student)
        {
            if (ModelState.IsValid)
            {
                Student updated = _studentService.GetById(student.ID);
                updated.Name = student.Name;
                updated.Class = student.Class;
                updated.Department = student.Department;
                updated.Email = student.Email;
                updated.Password = student.Password;
                updated.isAdmin = student.isAdmin;
                updated.Phone = student.Phone;
                updated.Status = student.Status;
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

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(Student student, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                var upload = new Upload();
                //Avatar
                bool imgResult;
                string imgPath = upload.ImageUpload(files, _env, out imgResult);
                if (imgResult)
                {
                    student.ProfileImageURL = imgPath;
                }
                else
                {
                    ViewBag.Message = imgPath;
                    return View(student);
                }
                bool result = _studentService.Add(student);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = $"Kayıt işlemi sırasında bir hata oluştu. " +
                        $"Lütfen tüm alanları kontrol edip tekrar deneyin.";
                }
            }
            else
            {
                TempData["Message"] = $"İşlem başarısız oldu.";
            }
            return View(student);
        }
    }
}
