using StockManage.BLL.BLL;
using StockManage.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;

namespace StockManageWeb.Controllers
{
    public class CustomerController : Controller
    {
       StockManageCustomerManager _stockManageManger = new StockManageCustomerManager();
        Customer _customer= new Customer();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {

            _customer.customers= _stockManageManger.Show();

            return View(_customer);
        }


        //public ActionResult Add(HttpPostedFileBase postedFile)
        //{

        //    using (BinaryReader br = new BinaryReader(postedFile.InputStream))
        //    {

        //        _customer.Image = br.ReadBytes(postedFile.ContentLength);
        //    }

        //    _stockManageManger.Add(_customer);

        //    return View();
        //}


        [HttpPost]
        public ActionResult Add(Customer customer)
        {
            _stockManageManger.Add(customer);

            _customer.customers = _stockManageManger.Show();
            return View(_customer);
        }
            
    

        [HttpPost]
        public ActionResult Show(Customer customer)
        {
            _customer.customers = _stockManageManger.Show();
            if (customer.Name != null)
            {
                _customer.customers= _customer.customers.Where(c => c.Name.ToLower().Contains(customer.Name.ToLower())).ToList();
            }


            return View(_customer);
        }

        public ActionResult Show()
        {

            _customer.customers= _stockManageManger.Show();

            return View(_customer);
        }

        public ActionResult Edit(int? id)
        {
            _customer.ID = Convert.ToInt32(id);

            _customer.customers= _stockManageManger.Show();
            var customer = _stockManageManger.GetByID(_customer);
            ViewBag.message = "Inserted";
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {


            _customer.Name = customer.Name;
            _customer.ID = customer.ID;
            _customer.Code = customer.Code;
            _customer.Address = customer.Address;
            _customer.Email = customer.Email;
            _customer.Contact = customer.Contact;
            _customer.Loyalty = customer.Loyalty;
            _stockManageManger.Edit(_customer);


            _customer.customers = _stockManageManger.Show();

            return View(_customer);
        }


        public ActionResult Delete(int? id)
        {
            _customer.ID = Convert.ToInt32(id);
            if (id != null)
            {
                var customer = _stockManageManger.GetByID(_customer);
                _stockManageManger.Delete(customer);
            }




            _customer.customers= _stockManageManger.Show();
            return View(_customer);

        }


    }
}