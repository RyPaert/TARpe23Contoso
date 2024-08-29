using ContosoUniversity.Data;
using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversity.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolContext _context;

        public StudentsController(SchoolContext Context)
        {
            _context = Context;
        }
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
            return View();
        }
    }
}
