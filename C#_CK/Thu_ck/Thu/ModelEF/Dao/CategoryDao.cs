using ModelEF.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Dao
{
    public class CategoryDao
    {
        private hoangthudb db;
        public CategoryDao()
        {
            db = new hoangthudb();
        }
        public IEnumerable<Category> ListWhereAll(string keySearch, int page, int pagesize)
        {
            IQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(keySearch))
            {
                model = model.Where(x => x.Name.Contains(keySearch));
            }

            return model.OrderBy(x => x.Name).ToPagedList(page, pagesize);
        }
        public List<Category> ListAll()
        {
            return db.Categories.ToList();
        }
        public bool FindName(string name)
        {
            return db.Categories.Any(x => x.Name == name);
        }
        public string Insert(Category entityCategory)
        {
            //var user = FindId(entityUser.admin_id);
            db.Categories.Add(entityCategory);
            db.SaveChanges();
            return entityCategory.Name;
        }
        public Category FindId(System.Int32 id)
        {
            return db.Categories.Find(id);
        }
        public string Update(Category entityCategory)
        {
            var category = FindId(entityCategory.ID);
            if (category != null)
            {
                category.Name = entityCategory.Name;
                category.Description = entityCategory.Description;
            }
            db.SaveChanges();
            return entityCategory.Name;
        }
        public bool Delete(System.Int32 id)
        {
            try
            {
                var category = db.Categories.Find(id);
                db.Categories.Remove(category);
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
