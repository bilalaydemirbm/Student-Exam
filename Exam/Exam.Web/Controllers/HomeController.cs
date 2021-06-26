using Exam.Core.Entity.Enums;
using Exam.Core.Service;
using Exam.Model.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using twitterClone.Models;

namespace Exam.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICoreService<Student> _studentService;
        private readonly IWebHostEnvironment _env;

        public HomeController(ICoreService<Student> studentService, IWebHostEnvironment env)
        {
            _studentService = studentService;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Student student, List<IFormFile> files)
        {
            bool exist = _studentService.Any(x => x.Email == student.Email);
            ModelState.Remove("isAdmin");
            ModelState.Remove("Status");

            if (ModelState.IsValid)
            {
                var upload = new Upload();
                //Avatar
                bool imgResult;
                string imgPath = upload.ImageUpload(files, _env, out imgResult);

                if (imgResult )
                {
                    student.ProfileImageURL = imgPath;
                }
                else
                {
                    ViewBag.Message = imgPath;
                    return View(student);
                }

                if (student.Email == null || student.Password == null)
                {
                    TempData["Message"] = $"Alanlar boş geçilemez.";
                }
                else
                {
                    if (!exist)
                    {
                        student.isAdmin = false;
                        student.Status = Status.Passive;
                        bool result = _studentService.Add(student);
                        if (result)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        TempData["Message"] = $"Kayıt işlemi sırasında bir hata oluştu.";
                    }
                }
            }
            else
            {
                TempData["Message"] = $"Form \"Valid\" değil.";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Login(Student student)
        {
            if (student.Email == null || student.Password == null)
            {
                TempData["Message"] = $"Alanlar boş geçilemez.";
            }
            else
            {
                //Veriyi almadan, veri var mı onu kontrol ediyoruz.
                if (_studentService.Any(x => x.Email == student.Email && x.Password == student.Password && x.Status == Status.Active))
                {

                    //Mail, şifre eşleşiyor mu?
                    Student logged = _studentService.GetByDefault(x => x.Email == student.Email
                    && x.Password == student.Password);

                    var claims = new List<Claim>
                    {
                        new Claim("ID", logged.ID.ToString()),
                        new Claim(ClaimTypes.Name, logged.Name),
                        new Claim(ClaimTypes.Email, logged.Email)
                    };
                    var userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    HttpContext.Response.Cookies.Append("id", logged.ID.ToString());
                    if (logged.isAdmin)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin", id = logged.ID });
                    }

                    return RedirectToAction("Index", "MainPage", claims);
                }
                else
                {
                    TempData["Message"] = $"Hesap onaylı değil veya kaydı yok.";
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
