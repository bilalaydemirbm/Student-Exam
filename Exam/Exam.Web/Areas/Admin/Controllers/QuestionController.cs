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
    public class QuestionController : Controller
    {
        private readonly ICoreService<Question> _questionService;
        private readonly IWebHostEnvironment _env;

        public QuestionController(ICoreService<Question> questionService, IWebHostEnvironment env)
        {
            _questionService = questionService;
            _env = env;
        }

        public IActionResult Index()
        {
            return View(_questionService.GetAll());
        }

        public IActionResult Delete(Guid id)
        {
            _questionService.Remove(_questionService.GetById(id));
            return RedirectToAction("Index");
        }

        public IActionResult Activate(Guid id)
        {
            _questionService.Active(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return View(HttpStatusCode.BadRequest);
            }
            var question = _questionService.GetById(id.GetValueOrDefault());
            if (question == null)
            {
                return View(HttpStatusCode.NotFound);
            }
            return View(question);
        }

        public IActionResult Update(Guid? id)
        {
            if (id == null)
            {
                return View(HttpStatusCode.BadRequest);
            }
            var question = _questionService.GetById(id.GetValueOrDefault());
            if (question == null)
            {
                return View(HttpStatusCode.NotFound);
            }
            return View(question);
        }

        [HttpPost]
        public IActionResult Update(Question question)
        {
            if (ModelState.IsValid)
            {
                Question updated = _questionService.GetById(question.ID);
                updated.Content = question.Content;
                updated.Answer = question.Answer;
                updated.Status = question.Status;

                bool result = _questionService.Update(updated);
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
            return View(question);
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(Question question, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                var upload = new Upload();
                //Question Image
                bool imgResult;
                string imgPath = upload.ImageUpload(files, _env, out imgResult);
                if (imgResult)
                {
                    question.Content = imgPath;
                }
                else
                {
                    ViewBag.Message = imgPath;
                    return View(question);
                }
                bool result = _questionService.Add(question);
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
            return View(question);
        }

    }
}
