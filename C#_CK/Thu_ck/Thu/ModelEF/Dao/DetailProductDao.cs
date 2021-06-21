using ModelEF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Dao
{
    public class DetailProductDao
    {
        private hoangthudb db;
        public DetailProductDao()
        {
            db = new hoangthudb();
        }
        public List<Product> ListWhereAll(System.Int32 id)
        {
            return db.Products.Where(x => x.ID == id).ToList();
        }
    }
}
