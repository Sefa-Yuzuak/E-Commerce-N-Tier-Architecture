using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Demo_ProductUI.Controllers
{
    public class JobController : Controller
    {
        JobManager jobManager = new JobManager(new EfJobDal());
        public IActionResult Index()
        {
            var values = jobManager.TGetList(); // verileri getirmek için kullanıyorum
            return View(values);
        }
        [HttpGet]
        public IActionResult AddJob()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddJob(Job p)
        {
            JobValidator validationRules = new JobValidator();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid)
            {
                jobManager.TInsert(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteJob(int id)
        {
            var value = jobManager.TGetById(id);
            jobManager.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateJob(int id)
        {
            var value = jobManager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateJob(Job p)
        {
            jobManager.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
