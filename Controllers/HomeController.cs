using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using YemekSiparis.Context;
using YemekSiparis.Entities;
using YemekSiparis.Models;

namespace YemekSiparis.Controllers
{
    public class HomeController : Controller
    {

        private DatabaseContext db = new DatabaseContext();
        // GET: Home
        public ActionResult Index()
        {
            var products = db.Products.Select(p=> new ProductModel()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description.Length > 50 ? p.Description.Substring(0,50) + "..." : p.Description,
                Price = p.Price,
                Stock = p.Stock,
                Image = p.Image,
                CategoryId = p.CategoryId,
            }).ToList();

                return View(products);
        }

        public ActionResult Urunler(int id)
        {
            var urunler = db.Products.Select(p => new ProductModel()
               {
                   Id = p.Id,
                   Name = p.Name,
                   Description = p.Description.Length > 50 ? p.Description.Substring(0, 50) + "..." : p.Description,
                   Price = p.Price,
                   Stock = p.Stock,
                   Image = p.Image,
                   CategoryId = p.CategoryId
               }).AsQueryable();

                urunler = urunler.Where(i => i.CategoryId == id);
            

            return View(urunler.ToList());
            
        }

        public ActionResult Details(int id)
        {
            ProductModel model = new ProductModel();
            var product = db.Products.Find(id);

            model.Name=product.Name;
            model.Description=product.Description;
            model.Price=product.Price;
            model.Stock=product.Stock;
            model.Image=product.Image;
            model.CategoryId=product.CategoryId;


            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            //if (ModelState.IsValid)
            //{

                    var obj = db.Users.Where(a => a.Name.Equals(user.Name) && a.Password.Equals(user.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        
                        return RedirectToAction("Index");
                    }

            // }
            
            return View(user);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                var check = db.Users.FirstOrDefault(u=> u.Email.Equals(user.Email) || u.Name.Equals(user.Name));
                if (check == null)
                {
                    User user1 = new User();
                    user1.Email = user.Email;
                    user1.Name = user.Name;
                    user1.Password = user.Password;
                    user1.RegisterDate = DateTime.Now;
                    user1.ConfirmPassword = user.ConfirmPassword;
                    if (user1 != null)
                    {
                        db.Users.Add(user1);
                        //try
                        //{
                        //    db.SaveChanges();
                        //}
                        //catch (DbEntityValidationException dbEx)
                        //{
                        //    foreach (var validationErrors in dbEx.EntityValidationErrors)
                        //    {
                        //        foreach (var validationError in validationErrors.ValidationErrors)
                        //        {
                        //            Trace.TraceInformation("Property: {0} Error: {1}",
                        //                                    validationError.PropertyName,
                        //                                    validationError.ErrorMessage);
                        //        }
                        //    }
                        //}
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }
            }
            return View(user);
        }
    }
}