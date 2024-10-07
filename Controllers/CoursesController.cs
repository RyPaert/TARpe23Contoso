using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Controllers
{
    public class CoursesController : Controller
    {
        private readonly SchoolContext _context;

        public CoursesController(SchoolContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.Courses;
            return View(await schoolContext.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["InstructorID"] = new SelectList(_context.Courses, "ID", "Title", "Credits");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID, Title, Credits")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) 
            {
                return NotFound();
            }
            var course = await _context.Courses.FirstOrDefaultAsync(m => m.ID == id); 

            if (course == null) 
            {
                return NotFound();
            }

            return View(course); 
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DetailsDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = await _context.Courses.FirstOrDefaultAsync();
            if (course == null)
            {
                return NotFound();
            }
            return View(course);

        }
        public async Task<IActionResult> Edit([Bind("Title, Credits")] Course course )
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Update(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }
            public async Task<IActionResult> Clone(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var course = await _context.Courses.FirstOrDefaultAsync(m => m.ID == id);

                var courseClone = new Course
                {
                    Title = course.Title,
                    Credits = course.Credits
                };
                if (courseClone != null)
                {
                    _context.Courses.Add(courseClone);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));          
        }
    }
}
