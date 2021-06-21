using ModelEF.EF;
using ModelEF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Dao
{
    public class ProductDao
    {
        private hoangthudb db;
        public ProductDao()
        {
            db = new hoangthudb();
        }
        public List<ProductModel> ListWhereAll(string keysearch)
        {
            var list_product = from s in db.Products
                               join c in db.Categories
                               on s.ID equals c.ID
                               orderby s.Quantity, s.UnitCost descending
                               select new ProductModel
                               {
                                   ID = s.ID,
                                   Name = s.Name,
                                   UnitCost = (decimal)s.UnitCost,
                                   Quantity = s.Quantity,
                                   Image = s.Image,
                                   Description = s.Description,
                                   category_name=c.Name
                               };
            var list_product_1 = from s in db.Products
                                 join c in db.Categories
                                 on s.ID equals c.ID
                                 where s.Name.Contains(keysearch)
                                 orderby s.Quantity, s.UnitCost descending
                                 select new ProductModel 
                                 {
                                     ID = s.ID,
                                     Name = s.Name,
                                     UnitCost = (decimal)s.UnitCost,
                                     Quantity = s.Quantity,
                                     Image = s.Image,
                                     Description = s.Description,
                                     category_name = c.Name
                                 };
            if (!string.IsNullOrEmpty(keysearch))
                return list_product_1.ToList();
            return list_product.ToList();
        }
        public Product FindId(System.Int32 id)
        {
            return db.Products.Find(id);
        }
        public bool Delete(System.Int32 id)
        {
            try
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
