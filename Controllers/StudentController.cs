using Microsoft.AspNetCore.Mvc;
using MVCformNupat.Data;
using MVCformNupat.Model;
using System.Security.Principal;

namespace MVCformNupat.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _ctx;

        public StudentController(AppDbContext context)
        {
            _ctx = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Student> students = _ctx.Students;
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if(ModelState.IsValid)
            {
                _ctx.Students.Add(student);
                await _ctx.SaveChangesAsync();

                return RedirectToAction("index");
            }
            return View(student);
        }

        public IActionResult Update(int?id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var user = _ctx.Students.Find(id);
            if(user != null)
            {
                return View(user);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Update(Student student)
        {
            if(ModelState.IsValid)
            {
                _ctx.Students.Update(student);
                await _ctx.SaveChangesAsync();
                return RedirectToAction("index");
            }
            else
            {
                return View(student);
            }            
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var user = _ctx.Students.Find(id);
            if (user != null)
            {
                return View(user);
            }
            return NotFound();

        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int? id)
        {
            var user = _ctx.Students.Find(id);
            if (user != null)
            {
                _ctx.Students.Remove(user);
                await _ctx.SaveChangesAsync();
                return RedirectToAction("index");
            }
            return NotFound();

        }


    }
}
