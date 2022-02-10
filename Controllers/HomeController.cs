using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var tasks = tasksContext.Responses
                .Include(x => x.Category)
                .Where(x => x.Completed == false)
                .ToList();
            return View(tasks);
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
        public IActionResult Edit(int taskid)
        {
            ViewBag.Cat = tasksContext.Categories.ToList();
            var task = tasksContext.Responses.Single(x => x.TaskId == taskid);
            return View("AddTask", task);
        }

        [HttpPost]
        public IActionResult Edit(TaskResponse tr)
        {
            tasksContext.Update(tr);
            tasksContext.SaveChanges();
            return RedirectToAction("Tasks");
        }

        [HttpGet]
        public IActionResult Delete(int taskid)
        {
            TaskResponse task = tasksContext.Responses.Single(x => x.TaskId == taskid);
            tasksContext.Responses.Remove(task);
            tasksContext.SaveChanges();
            return RedirectToAction("Tasks");
        }

        [HttpGet]
        public IActionResult Complete(int taskid)
        {
            var task = tasksContext.Responses.Single(x => x.TaskId == taskid);
            return View(task);
        }

        [HttpPost]
        public IActionResult Complete(TaskResponse tr)
        {
            var task = tasksContext.Responses.Single(x => x.TaskId == tr.TaskId);
            task.Completed = true;
            tasksContext.Update(task);
            tasksContext.SaveChanges();
            return RedirectToAction("Tasks");
        }

    }
}
