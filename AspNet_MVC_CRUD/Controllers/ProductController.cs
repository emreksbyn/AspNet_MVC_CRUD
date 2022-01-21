using AspNet_MVC_CRUD.Models.DataTransferObjects;
using AspNet_MVC_CRUD.Models.Entities.Abstract;
using AspNet_MVC_CRUD.Models.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNet_MVC_CRUD.Controllers
{
    public class ProductController : BaseController
    {
        #region Create Product
        [HttpGet]
        public ActionResult Create()
        {
            CreateProductDTO model = new CreateProductDTO();
            model.Categories = db.Categories.Where(x => x.Status != Status.Passive).ToList();
            return View(model);
        }
        public ActionResult Create(CreateProductDTO model)
        {
            model.Categories = db.Categories.Where(x => x.Status != Status.Passive).ToList();
            if (ModelState.IsValid)
            {
                Product product = new Product();
                product.Name = model.Name;
                product.Description = model.Description;
                product.UnitPrice = model.UnitPrice;
                product.UnitInStock = model.UnitInStock;
                product.CategoryId = model.CategoryId;
                db.Products.Add(product);
                db.SaveChanges();
                ViewBag.ProcessStatus = 1;
                // Art arda ekleme yapabilmek için :
                return View(model);

                //return RedirectToAction("List");
            }
            else
            {
                ViewBag.ProcessStatus = 2;
                return View(model);
            }
        }
        #endregion

        #region List
        public ActionResult List()
        {
            return View(db.Products.Where(x => x.Status != Status.Passive).ToList());
        }
        #endregion

        #region Update
        [HttpGet]
        public ActionResult Update(int id)
        {
            Product product = db.Products.FirstOrDefault(x => x.Id == id);
            UpdateProductDTO model = new UpdateProductDTO();
            model.Id = product.Id;
            model.Name = product.Name;
            model.Description = product.Description;
            model.UnitInStock = product.UnitInStock;
            model.UnitPrice = product.UnitPrice;
            model.Categories = db.Categories.Where(x => x.Status != Status.Passive).ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(UpdateProductDTO model)
        {
            Product product = db.Products.FirstOrDefault(x => x.Id == model.Id);
            model.Categories = db.Categories.Where(x => x.Status != Status.Passive).ToList();
            if (ModelState.IsValid)
            {
                product.Name = model.Name;
                product.Description = model.Description;
                product.UnitPrice = model.UnitPrice;
                product.UnitInStock = model.UnitInStock;
                product.CategoryId = model.CategoryId;
                product.Status = Status.Modified;
                product.UpdateDate = DateTime.Now;
                db.SaveChanges();
                ViewBag.ProcessStatuss = 1;
                return View(model);
            }
            else
            {
                ViewBag.ProcessStatus = 2;
                return View(model);
            }
        }
        #endregion

        #region Delete
        public ActionResult Delete(int id)
        {
            Product product = db.Products.FirstOrDefault(x => x.Id == id);
            product.Status = Status.Passive;
            product.DeleteDate = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("List");
        }
        #endregion

        #region Details
        public ActionResult Details(int id)
        {
            Product product = db.Products.FirstOrDefault(x => x.Id == id);
            return View(product);
        }
        #endregion

    }
}