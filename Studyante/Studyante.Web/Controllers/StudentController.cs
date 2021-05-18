using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Studyante.DTO;
using Studyante.Service;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studyante.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }
        // GET: StudentController
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAll());
        }

        // GET: StudentController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(await _service.Get(id));
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentDTO student)
        {
            try
            {
                await _service.Add(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _service.Get(id));
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StudentDTO student)
        {
            try
            {
                await _service.Update(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _service.Get(id));
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(StudentDTO student)
        {
            try
            {
                await _service.Delete(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
