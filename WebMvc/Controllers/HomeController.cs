using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace WebMvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private DB_Item item = new DB_Item();
        private Item newitem = new Item();

        public ActionResult Index()
        {
            return View(item.ListItem());
        }
        public ActionResult Crud(string id = "")
        {
            return View(
                        id != "" ? item.Obtener(id)
                            : newitem
                );
        }
        public ActionResult Ver(string id)
        {
            return View(item.Obtener(id));
        }
        public ActionResult Save(Item model)
        {
            item.Guardar(model);
            return Redirect("~/home/crud/" + newitem.ItemId);
        }
    }
}