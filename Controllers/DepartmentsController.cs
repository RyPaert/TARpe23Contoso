using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversity.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
