using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockManage.Models.Models;
using StockManageWeb.Models;
using StockManage.BLL.BLL;
using AutoMapper;

namespace StockManageWeb.Controllers
{
    public class CategoryController : Controller
    {
        StockManageManager _stockManageManger = new StockManageManager();
        Category _category = new Category();
        CategoryVM _categoryvm = new CategoryVM();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
           _categoryvm.categories = _stockManageManger.Show();

            return View(_categoryvm);
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {
            if (ModelState.IsValid)

            {
                if (category.Name != null && category.Code != null)
                {
                    _stockManageManger.Add(category);
                    ViewBag.message = "Inserted";
                }
            }

            else
            {
                ViewBag.message = "Not Inserted";
            }

            _categoryvm.categories = _stockManageManger.Show();

            return View(_categoryvm);
        }

        [HttpPost]
        public ActionResult Show(CategoryVM category)
        {
            _categoryvm.categories = _stockManageManger.Show();
            if (category.Name != null)
            {
                _categoryvm.categories = _categoryvm.categories.Where(c => c.Name.ToLower().Contains(category.Name.ToLower())).ToList();
            }


            return View(_categoryvm);
        }

        public ActionResult Show()
        {

            _categoryvm.categories = _stockManageManger.Show();

            return View(_categoryvm);
        }

        public ActionResult Edit(int? id)
        {
            CategoryVM model = new CategoryVM();
            model.ID = Convert.ToInt32(id);
            Category category = Mapper.Map<Category>(model);
            var categoris = _stockManageManger.GetByID(category);
            ViewBag.message = "Inserted";
            return View(categoris);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {


            _category.Name = category.Name;
            _category.ID = category.ID;
            _category.Code = category.Code;
            _stockManageManger.Edit(_category);


            _categoryvm.categories = _stockManageManger.Show();

            return View(_categoryvm);
        }


        public ActionResult Delete(int? id)
        {
            _category.ID = Convert.ToInt32(id);
            if (id != null)
            {
                var category = _stockManageManger.GetByID(_category);
                _stockManageManger.Delete(category);
            }




            _categoryvm.categories = _stockManageManger.Show();
            return View(_categoryvm);

        }




    }
}