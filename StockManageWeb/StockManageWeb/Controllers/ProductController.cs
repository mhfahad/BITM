using StockManage.BLL.BLL;
using StockManage.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockManageWeb.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        StockManageProductManager _stockManageManger = new StockManageProductManager();
        StockManageManager _stockManageManagerCategory = new StockManageManager();
        Product _product = new Product();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            _product.products = _stockManageManger.Show();
            _product.categories = _stockManageManagerCategory.Show();
            return View(_product);
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (ModelState.IsValid)

            {
                if (product.Name != null)
                {
                    _stockManageManger.Add(product);
                    ViewBag.message = "Inserted";
                }
            }

            else
            {
                ViewBag.message = "Not Inserted";
            }

            _product.products = _stockManageManger.Show();
            _product.categories = _stockManageManagerCategory.Show();
            return View(_product);
        }

        [HttpPost]
        public ActionResult Show(Product product)
        {
            _product.products = _stockManageManger.Show();
          
            if (product.Name != null)
            {
                 _product.products = _product.products.Where(c => c.Name.ToLower().Contains(product.Name.ToLower())).ToList();

            }
            return View(_product);
        }

        public ActionResult Show()
        {

            _product.products = _stockManageManger.Show();

            return View(_product);
        }

        public ActionResult Edit(int? id)
        {
            _product.ID = Convert.ToInt32(id);

            _product.products = _stockManageManger.Show();
            var product = _stockManageManger.GetByID(_product);
            if(id==null)
            {
                _product.categories = _stockManageManagerCategory.Show();
                return View(_product);
            }
           
            ViewBag.message = "Edited";
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {


            _product.Name = product.Name;
            _product.ID = product.ID;
            _product.Code = product.Code;
            _product.Category = product.Category;
            _product.ReorderLevel = product.ReorderLevel;
            _product.Discription = product.Discription;
            _stockManageManger.Edit(_product);

           
            _product.products= _stockManageManger.Show();

            return View(_product);
        }


        public ActionResult Delete(int? id)
        {
            _product.ID = Convert.ToInt32(id);
            if (id != null)
            {
                var product = _stockManageManger.GetByID(_product);
                _stockManageManger.Delete(product);
            }




            _product.products= _stockManageManger.Show();
            return View(_product);

        }




    }
}
