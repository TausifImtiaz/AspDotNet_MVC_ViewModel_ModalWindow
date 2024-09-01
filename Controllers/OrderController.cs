using MVC_ViewModel_ModalWindow.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ViewModel_ModalWindow.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getProductCategories()
        {
            List<Category> categories = new List<Category>();
            categories = db.Categories.OrderBy(c => c.CategoryName).ToList();
            return new JsonResult { Data = categories, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult getProducts(int categoryId)
        {
            List<Product> products = new List<Product>();
            products = db.Products.Where(p => p.CategoryId.Equals(categoryId)).OrderBy(po => po.ProductName).ToList();
            return new JsonResult { Data = products, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult Save(Customer customer, Order order, HttpPostedFileBase file)
        {
            bool status = false;
            if (file != null)
            {
                string folderPath = Server.MapPath("~/Images/");
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(folderPath, fileName);
                file.SaveAs(filePath);
                customer.Image = fileName;
            }
            var isValidModel = TryUpdateModel(customer);
            if (isValidModel)
            {
                db.Customers.Add(customer);
                db.SaveChanges();

                order.CustomerId = customer.CustomerId;
                db.Orders.Add(order);

                db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };

        }
    }
}