using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Product.Models;
using System.Text.Json;
using Newtonsoft.Json;

namespace Product.Controllers
{
    public class ProductController : Controller
    {
        ProductEntities dbObj = new ProductEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            var result = dbObj.products.ToList();
            return View(result);
        }

        public ActionResult AddToCart(product p)
        {
            List<object> Cart = new List<object>();
            string json;
            if (Session["cart"] == null)
            {
                Cart[]
                Cart.Add(p);
                json = new JavaScriptSerializer().Serialize(Cart);
                Session["cart"] = json;
            }

            else
            {
               // var L = JavaScriptSerializer().Deserialize<List< object >> (Session["cart"]);
                var model = JsonConvert.DeserializeObject<List<MatrixModel.RootObject>>(json);
            }
           

            return View(result);
        }



    }
}