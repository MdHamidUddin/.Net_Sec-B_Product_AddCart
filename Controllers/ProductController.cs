using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Product.Models;
using Newtonsoft.Json;
using Product.Models.Entity;
using AutoMapper;

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


            var config = new MapperConfiguration(cfg => cfg.CreateMap<product, ProductModel>());
         
            var mapper = new Mapper(config);
            
            var R = mapper.Map<List< ProductModel>>(result);
      

            return View(R);
        }
        public JsonResult Checking()
        {
            var result = dbObj.products.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddToCart(int  id)
        {

            var p2 = dbObj.products.Where(x => x.ID == id).FirstOrDefault();


            var config = new MapperConfiguration(cfg => cfg.CreateMap<product, ProductModel>());

            var mapper = new Mapper(config);

            var p = mapper.Map<ProductModel>(p2);





            // product pro = new product();
            //ProductModel pm = new ProductModel();
            //Database db = new Database();
            //var p = pm.Get(id);


            if (Session["Cart"] == null)
                {
                dbObj.Configuration.ProxyCreationEnabled = false;
                List<ProductModel> CartProduct = new List<ProductModel>();

                    CartProduct.Add(p);
                    string json = new JavaScriptSerializer().Serialize(CartProduct);
                    Session["Cart"] = json;
                    return RedirectToAction("Products");
                }

                else
                {
                dbObj.Configuration.ProxyCreationEnabled = false;
                var Cart = Session["Cart"];
                    var CartProduct = new JavaScriptSerializer().Deserialize<List<ProductModel>>(Cart.ToString());


                    CartProduct.Add(p);
                    string json = new JavaScriptSerializer().Serialize(CartProduct);
                    Session["Cart"] = json;
                    return RedirectToAction("Products");
                }
        }

        [HttpGet]
        public ActionResult Cart()
        {
            if (Session["Cart"] == null)
            {

            }
            else
            {
                var Cart = Session["Cart"];
                var CartProduct = new JavaScriptSerializer().Deserialize<List<product>>(Cart.ToString());
                return View(CartProduct);
            }

            return View();
        }

        public ActionResult ConfirmCart(product p)
        {
            Order obj = new Order();
            if(ModelState.IsValid)
            {
                DateTime now = DateTime.Now;
                string Date = now.ToString("YYYY-MM-dd");
                var Cart = Session["Cart"];
                var CartProduct = new JavaScriptSerializer().Deserialize<List<product>>(Cart.ToString());
                int len = CartProduct.Count();
                for(int i=0;i<len;i++)
                {
                    int  pd = CartProduct[i].ID;
                    obj.P_ID = pd;
                    obj.Date = DateTime.Now;
                    dbObj.Orders.Add(obj);
                    dbObj.SaveChanges();
                }

                Session["Cart"] = null;

                return RedirectToAction("Products");
            }
            else
            {
                return RedirectToAction("Cart");
            }
          

        }

        public ActionResult OrderDetails()
        {

            List<OrderDetails> O_Details = new List<OrderDetails> ();
            var P = dbObj.products.ToList();
            var O = dbObj.Orders.ToList();

            int len = O.Count();

            for(int i=0;i<len;i++)
            {
                O_Details[i].Name = P[0].Name;
                O_Details[i].Price = P[0].Price;
                O_Details[i].Description = P[0].Description;
                O_Details[i].Date = O[0].Date;
            }
            return View(O_Details);
        }



    }
}