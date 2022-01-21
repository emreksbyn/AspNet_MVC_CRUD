using AspNet_MVC_CRUD.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNet_MVC_CRUD.Controllers
{

    // Veri tabanı karşılığı olan ProjectContext.cs sınıfının nesnesini getirecek olan Controller' ımız BaseController' dır. Nesneyi işi bittiğinde Dispose edecek metodu burada override ediyoruz.
    public class BaseController : Controller
    {
        public ProjectContext db;
        public BaseController()
        {
            db = new ProjectContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}