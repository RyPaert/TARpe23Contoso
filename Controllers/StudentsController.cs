using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolContext _context;

        public StudentsController(SchoolContext Context)
        {
            _context = Context;
        }

        // get all for index, retrieve all students
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }
        /*
        public async Task<IActionResult> Index(
            string sortOrder,
            string CurrentFilter,
            string searchString,
            int? pageNumber
            )
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParam"] = String.IsNullOrEmpty(CurrentFilter) ? "name_desc" : "";
            ViewData["DateSortParam"] = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = CurrentFilter;
            }

            ViewData["currentFilter"] = searchString;

            var students = from student in _context.Students
                           select student;
            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(student => 
                student.LastName.Contains(searchString) || 
                student.FirstMidName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(student => student.LastName);
                    break;
                case "firstname_desc":
                    students = students.OrderByDescending(student => student.FirstMidName);
                    break;
                case "Date":
                    students = students.OrderByDescending(student => student.EnrollmentDate);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(student => student.EnrollmentDate);
                    break;
                default:
                    students = students.OrderBy(student => student.LastName);
                    break;
            } 

            int pageSize = 3;
            return View(await _context.Students.ToListAsync());
        }
        */

        // Create get, haarab vaatest andmed, mida Create method vajab.
        public IActionResult Create()
        {
            return View();
        }
        //Create method, sisestab andmebaasi uue õpilase. insert new student into database

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID, LastName, FirstMidName, EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }
        // Delete method, otsib andmebaasist kaasaantud id järgi õpilast
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) // kui id on tühi, siis õpilast ei leita
            {
                return NotFound();
            }
            var student = await _context.Students.FirstOrDefaultAsync(m => m.ID == id); // Tehakse õpilase objekt andmebaasis oleva ID järgi
            
            if (student == null) // Kui student object on tühi, siis ka ei leia.
            {
                return NotFound();
            }

            return View(student); 
        }

        // Delete POST meethod, teostab andmebaasis vajaliku muudatuse. ehk kustutab objekti.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id); // Otsime databaseist õpilast id järgi ja panema ta student variablei

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int id)
        {
            if (id == null) // kui id on tühi, siis õpilast ei leita
            {
                return NotFound();
            }
            var student = await _context.Students.FirstOrDefaultAsync(m => m.ID == id); // Tehakse õpilase objekt andmebaasis oleva ID järgi

            if (student == null) // Kui student object on tühi, siis ka ei leia.
            {
                return NotFound();
            }
            return View(student);
        }
        public async Task<IActionResult> Edit([Bind("ID, LastName, FirstMidName, EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
<<<<<<< HEAD
            return View(student);   
        }
        public async Task<IActionResult> Clone(int? id)
        {
            if (id == null) 
            {
                return NotFound();
            }
            var student = await _context.Students.FirstOrDefaultAsync(m => m.ID == id);

            var studentClone = new Student
            {
                FirstMidName = student.FirstMidName,
                LastName = student.LastName,
                EnrollmentDate = student.EnrollmentDate
            };

            if (studentClone != null)
            {
                _context.Students.Add(studentClone);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
=======
            return View(student);
>>>>>>> cb0b6100c00ca5f2c32dc0080786808ff416c336
        }
    }
}
