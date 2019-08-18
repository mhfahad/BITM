using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManage.DatabaseContext.DatabaseContext;
using StockManage.Models.Models;
using System.Data.Entity;

namespace StockManageWeb.repository.Repository
{
    public class StockManageRepositoryProduct
    {
        StockManageDbContext Db = new StockManageDbContext();

        public int add(Product product)
        {
            Db.products.Add(product);
            int saved = Db.SaveChanges();
            return 0;
        }
        public List<Product> Show()
        {

            return Db.products.ToList();

        }

        public int Edit(Product product)
        {
            Product aProduct = Db.products.FirstOrDefault(x => x.ID == product.ID);
            aProduct.Name = product.Name;
            aProduct.Code = product.Code;
            aProduct.Category = product.Category;
            aProduct.Discription = product.Discription;
            aProduct.ReorderLevel = product.ReorderLevel;

            Db.SaveChanges();
            return 0;
        }

        public int Delete(Product product)
        {
            Product aProduct = Db.products.FirstOrDefault(x => x.ID == product.ID);
            Db.products.Remove(aProduct);
            Db.SaveChanges();
            return 0;
        }

        public Product GetByID(Product product)
        {
            Product aProduct = Db.products.FirstOrDefault(c => c.ID == product.ID);
            return aProduct;
        }
    }
}
