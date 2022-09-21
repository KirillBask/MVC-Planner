using Microsoft.AspNetCore.Mvc;
using System;

namespace MvcPlanner.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Details(int id)
        {
            return Ok("You have entered id = " + id);
        }
    }
}
