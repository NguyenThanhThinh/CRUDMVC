using CRUDMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly PetCrudMvcDbContext db = null;
        public CategoryController()
        {
            db = new PetCrudMvcDbContext();
        }
        public ActionResult Index()
        {
            var getAll = db.Categorys.ToList();
            return View(getAll);
        }
    }
}