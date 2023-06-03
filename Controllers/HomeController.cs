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

        public PartialViewResult GetCategories()
        {
            return PartialView(db.Categories.ToList());
        }

       
    }
}