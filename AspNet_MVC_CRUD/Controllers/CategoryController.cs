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
    public class CategoryController : BaseController
    {
        // MVC deseninde gelen request' leri Controller' lar karşılar. Gelen request ActionResult' larda handle edilir. Sonuç olarak kullanıcıya istisnalar haricinde bir View dönülür. Burada 2 durum vardır. Sayfa kullanıcıya boş mu gönderilecek yoksa data olan sayfa mı ? Data gönderilecekse işin içine Model' ide dahil etmemiz gerekir.

        #region Create Category
        [HttpGet] // Yazmasakta olur. Default olarak Get' tir.
        public ActionResult Create()
        {
            return View();
        }
        // Category ekleme sayfasından delen data db' ye gider.
        [HttpPost]
        public ActionResult Create(CreateCategoryDTO model)
        {
            // Koyduğumuz kısıtlamalara uygunluğu test edilir.
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.Name = model.Name;
                category.Description = model.Description;
                db.Categories.Add(category);
                db.SaveChanges();
                ViewBag.ProcessStatus = 1;
                return View();
            }
            else
            {
                ViewBag.ProcessStatus = 2;
                return View(model);
            }
        }
        #endregion

        #region List
        // Normalde DTO yada ViewModel kullanmamız daha doğru olurdu. Biz category ile ilgili bütün bilgileri görmek istediğimiz için bu şekilde kullandık.

        [HttpGet]
        public ActionResult List()
        {
            var categoryList = db.Categories.Where(x => x.Status != Status.Passive).ToList();
            return View(categoryList);
        }
        #endregion

        #region Update Category
        [HttpGet]
        public ActionResult Update(int id)
        {
            Category category = db.Categories.FirstOrDefault(x => x.Id == id);
            UpdateCategoryDTO model = new UpdateCategoryDTO();
            model.Id = category.Id;
            model.Name = category.Name;
            model.Description = category.Description;
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(UpdateCategoryDTO model)
        {
            // Güncellemek istediğimiz category id' sinden yakalanır.
            Category category = db.Categories.FirstOrDefault(x => x.Id == model.Id);
            if (ModelState.IsValid)
            {
                category.Name = model.Name;
                category.Description = model.Description;
                category.UpdateDate = DateTime.Now;
                category.Status = Status.Modified;
                db.SaveChanges();
                ViewBag.ProcessStatus = 1;
                return RedirectToAction("List");
                // İşlem bitince List Action tetiklenecek.
            }
            else
            {
                ViewBag.ProcessStatus = 2;
                return View(model);
            }
        }

        #endregion

        #region Delete
        //public ActionResult Delete(int id)
        //{
        //    Category category = db.Categories.FirstOrDefault(x => x.Id == id);
        //    category.Status = Status.Passive;
        //    category.DeleteDate = DateTime.Now;
        //    db.SaveChanges();
        //    return RedirectToAction("List");
        //}
        public JsonResult Delete(int id)
        {
            Category category = db.Categories.FirstOrDefault(x => x.Id == id);
            category.Status = Status.Passive;
            category.DeleteDate = DateTime.Now;
            db.SaveChanges();
            ViewBag.ProcessStatus = 1;
            return Json("");
        }
        #endregion

        #region Category Details
        public ActionResult Details(int id)
        {
            Category category = db.Categories.FirstOrDefault(x => x.Id == id);
            return View(category);
        }
        #endregion
    }
}