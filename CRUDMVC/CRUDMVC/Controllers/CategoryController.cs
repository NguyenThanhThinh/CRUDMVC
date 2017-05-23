using CRUDMVC.Models;
using CRUDMVC.Models.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;

namespace CRUDMVC.Controllers
{
    [RoutePrefix("Category")]
    public class CategoryController : Controller
    {
        private readonly PetCrudMvcDbContext db = null;
        public CategoryController()
        {
            db = new PetCrudMvcDbContext();
        }
        [Route("Index")]
        public ActionResult Index()
        {
            var getAll = db.Categorys.ToList();
            return View(getAll);
        }
        [HttpGet]
        [Route("InsertUpdate/{id?}")]
        public ActionResult InsertUpdate(int? id)
        {
            var getID = db.Categorys.SingleOrDefault(n => n.ID == id);
            if (getID != null)
            {
                return View("InsertUpdateCategory", getID);
            }
            return View("InsertUpdateCategory");
        }
        [HttpPost]
        [Route("InsertUpdate")]
        public ActionResult InsertUpdate(Category vm)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    if (vm.ID == 0)
                    {
                        db.Categorys.Add(vm);
                        db.SaveChanges();
                        TempData["Message"] = "Thêm Thành công";
                    }
                    else
                    {
                        db.Entry(vm).State = EntityState.Modified;
                        db.SaveChanges();
                        TempData["Message"] = "Cập nhật thành công";
                    }
                }
                catch (DbEntityValidationException ex)
                {

                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                        }
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "error");
                return View("InsertUpdateCategory", vm);
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("Delete/{id?}")]
        public ActionResult Delete(int? id)
        {
            var success = DeleteAsync(id);
            if (success)
            {
                var all = db.Categorys.ToList();
                if (all != null)

                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = success }, JsonRequestBehavior.AllowGet);
        }

        private bool DeleteAsync(object id)
        {
            try
            {
                var existing = db.Categorys.Find(id);
                if (existing != null)
                    db.Categorys.Remove(existing);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}