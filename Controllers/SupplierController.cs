using MVC_ViewModel_ModalWindow.Models;
using MVC_ViewModel_ModalWindow.ViewModels;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ViewModel_ModalWindow.Controllers
{
    public class SupplierController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Supplliers.ToList());
        }

        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(SupplierVM svm)
        {
            Suppllier s = new Suppllier();
            if (ModelState.IsValid)
            {
                s.SupplierName = svm.SupplierName;
                s.Email = svm.Email;
                s.Phone = svm.Phone;
                s.Address = svm.Address;

                db.Supplliers.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index");


            }

            return PartialView("_SuppliersView", db.Supplliers.ToList());
        }
        public ActionResult Edit(int id)
        {
            SupplierVM svm = new SupplierVM();
            Suppllier s = db.Supplliers.Find(id);
            svm.SupplierName = s.SupplierName;
            svm.Email = s.Email;
            svm.Phone = s.Phone;
            svm.Address = s.Address;


            if (s == null)
            {
                return HttpNotFound();

            }

            return PartialView(svm);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SupplierVM svm, int id)
        {
            Suppllier s = new Suppllier();
            s = db.Supplliers.Find(id);
            if (ModelState.IsValid)
            {
                s.SupplierName = svm.SupplierName;
                s.Email = svm.Email;
                s.Phone = svm.Phone;
                s.Address = svm.Address;
                db.Supplliers.Add(s);
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }




            return PartialView("_SuppliersView", db.Supplliers.ToList());


        }

        public ActionResult Delete(int id)
        {
            Suppllier s = db.Supplliers.Find(id);
            SupplierVM svm = new SupplierVM();

            svm.SupplierName = s.SupplierName;
            svm.Email = s.Email;
            svm.Phone = s.Phone;
            svm.Address = s.Address;
            return PartialView(svm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSupplier(int id)
        {
            Suppllier s = db.Supplliers.Find(id);
            if (s != null)
            {
                db.Supplliers.Remove(s);
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteSupplier(int id)
        //{
        //    try
        //    {
        //        Suppllier s = db.Supplliers.Find(id);
        //        if (s != null)
        //        {
        //            db.Supplliers.Remove(s);
        //            db.SaveChanges();
        //            return Json(new { success = true });
        //        }
        //        else
        //        {
        //            return Json(new { success = false, message = "Supplier not found." });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { success = false, message = "Error occurred while deleting the supplier: " + ex.Message });
        //    }
        //}

        //[HttpPost]
        //public ActionResult DeleteSupplier(int id)
        //{
        //    try
        //    {
        //        Suppllier s = db.Supplliers.Find(id);

        //        if (s == null)
        //            throw new Exception("Supplier not found.");

        //        db.Supplliers.Remove(s);
        //        db.SaveChanges();

        //        return Json(new { success = true });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { success = false, message = ex.Message });
        //    }
        //}


        public ActionResult Details(int id)
        {

            Suppllier s = db.Supplliers.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            return View(s);

        }

    }
}