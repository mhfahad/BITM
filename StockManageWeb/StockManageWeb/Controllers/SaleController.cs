using AutoMapper;
using StockManage.BLL.BLL;
using StockManage.Models.Models;
using StockManageWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockManageWeb.Controllers
{
    public class SaleController : Controller
    {
        StockManageSaleManager _stockManageManger = new StockManageSaleManager();
        Sale _supplier = new Sale();
        Customer _Customer = new Customer();
        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {

            var model = new SalesVm();
            model.CustomerList = _stockManageManger.Show()
                                                    .Select(c => new SelectListItem
                                                    {
                                                        Value = c.ID.ToString(),
                                                        Text = c.Name
                                                    })
                                                    .ToList();


            model.ProductList = _stockManageManger.ShowProduct()
                                                    .Select(c => new SelectListItem
                                                    {
                                                        Value = c.ID.ToString(),
                                                        Text = c.Name
                                                    })
                                                    .ToList();


            return View(model);

        }

        [HttpPost]
        public ActionResult Add(SalesVm model)
        {
            

            if (ModelState.IsValid)
            {

                var sale = Mapper.Map<Sale>(model);

                var sales = new List<Sale>();
                var customerID = model.CustomerID;
                var productID = model.ProductID;

                foreach (var item in model.sales)
                {
                    item.CustomerID= customerID;
                    item.ProductID = productID;
                    sales.Add(item);
                }


                bool isAdded = _stockManageManger.Add(sales);

                if (isAdded)
                {
                    return RedirectToAction("Add");
                }

            }

            return View(model);

        }

      

        [HttpPost]
        public ActionResult Index(Sale sale)
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetbyID( int customerID)
        {
            

            
            var aCustomer = _stockManageManger.GetByID(customerID);

            return Json(aCustomer, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetbyID2(int productID)
        {
            
            var aProduct = _stockManageManger.GetByID2(productID);

            return Json(aProduct, JsonRequestBehavior.AllowGet);
        }
    }
}