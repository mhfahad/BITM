using StockManage.BLL.BLL;
using StockManage.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockManageWeb.Controllers
{
    public class SupplierController : Controller
    {
        StockManageSupplierManager _stockManageManger = new StockManageSupplierManager();
        Supplier _supplier= new Supplier();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            _supplier.suppliers= _stockManageManger.Show();

            return View(_supplier);
        }

        [HttpPost]
        public ActionResult Add(Supplier supplier)
        {
            if (ModelState.IsValid)

            {
                if (supplier.Name != null && supplier.Code != null)
                {
                    _stockManageManger.Add(supplier);
                    ViewBag.message = "Inserted";
                }
            }

            else
            {
                ViewBag.message = "Not Inserted";
            }

            _supplier.suppliers= _stockManageManger.Show();

            return View(_supplier);
        }

        [HttpPost]
        public ActionResult Show(Supplier supplier)
        {
            _supplier.suppliers= _stockManageManger.Show();
            if (supplier.Name != null)
            {
                _supplier.suppliers= _supplier.suppliers.Where(c => c.Name.ToLower().Contains(supplier.Name.ToLower())).ToList();
            }


            return View(_supplier);
        }

        public ActionResult Show()
        {

            _supplier.suppliers= _stockManageManger.Show();

            return View(_supplier);
        }

        public ActionResult Edit(int? id)
        {
            _supplier.ID = Convert.ToInt32(id);

            _supplier.suppliers= _stockManageManger.Show();
            var supplier = _stockManageManger.GetByID(_supplier);
            ViewBag.message = "Inserted";
            return View(supplier);
        }

        [HttpPost]
        public ActionResult Edit(Supplier supplier)
        {


            _supplier.Name = supplier.Name;
            _supplier.ID = supplier.ID;
            _supplier.Code = supplier.Code;
            _supplier.Address = supplier.Address;
            _supplier.Email = supplier.Email;
            _supplier.Contact = supplier.Contact;
            _supplier.ContactPerson= supplier.ContactPerson;
            _stockManageManger.Edit(_supplier);


            _supplier.suppliers= _stockManageManger.Show();

            return View(_supplier);
        }


        public ActionResult Delete(int? id)
        {
            _supplier.ID = Convert.ToInt32(id);
            if (id != null)
            {
                var supplier= _stockManageManger.GetByID(_supplier);
                _stockManageManger.Delete(supplier);
            }




            _supplier.suppliers = _stockManageManger.Show();
            return View(_supplier);

        }

    }
}