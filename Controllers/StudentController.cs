using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCformNupat.Data;
using MVCformNupat.Model;
using MVCformNupat.Repository;
using System.Security.Principal;

namespace MVCformNupat.Controllers
{
    public class StudentController : Controller
    {
        private readonly IRepository _repo;
        public StudentController(IRepository repository)
        {
            _repo = repository;
        }

        [Authorize]
        public IActionResult Index()
        {
            var student = _repo.GetAllStudent();
            return View(student);
        }

        [Authorize(Roles ="User")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            _repo.Add(student);
            await _repo.SaveAsync();
            return RedirectToAction("index");
        }

        public IActionResult Update(int id)
        {
            var student = _repo.GetById(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Student student)
        {
            _repo.Update(student);
            await _repo.SaveAsync();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            var student = _repo.GetById(id);
            return View(student);

        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(Student student)
        {
            _repo.Delete(student);
            await _repo.SaveAsync();
            return RedirectToAction("index");
        }

    }
}
