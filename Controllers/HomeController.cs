using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission06.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06.Controllers
{
    public class HomeController : Controller
    {
        private TasksContext tasksContext { get; set; }

        public HomeController(TasksContext tc)
        {
            tasksContext = tc;
        }

        public IActionResult Index()
        {
            return View("Quadrant");
        }

        public IActionResult Quadrant()
        {
            return View();
        }

        public IActionResult Tasks()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Cat = tasksContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddTask(TaskResponse tr)
        {
            if (ModelState.IsValid)
            {
                tasksContext.Add(tr);
                tasksContext.SaveChanges();
                return RedirectToAction("Tasks");
            }
            else
            {
                ViewBag.Cat = tasksContext.Categories.ToList();
                return View(tr);
            }
        }
        

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Cat = tasksContext.Categories.ToList();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        
    }
}
