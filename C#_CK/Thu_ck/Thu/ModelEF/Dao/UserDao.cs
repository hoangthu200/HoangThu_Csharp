using ModelEF.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Dao
{
    public class UserDao
    {
        private hoangthudb db;
        public UserDao()
        {
            db = new hoangthudb();
        }
        public int login(string username, string password)
        {
            var result = db.UserAccounts.SingleOrDefault(x => x.UserName.Contains(username) && x.PassWord.Contains(password) && x.Status.Contains("Active"));
            if (result == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public IEnumerable<UserAccount> ListWhereAll(string keySearch, int page, int pagesize)
        {
            IQueryable<UserAccount> model = db.UserAccounts;
            if (!string.IsNullOrEmpty(keySearch))
            {
                model = model.Where(x => x.UserName.Contains(keySearch));
            }

            return model.OrderBy(x => x.UserName).ToPagedList(page, pagesize);
        }
        public UserAccount FindId(System.Int32 admin_id)
        {
            return db.UserAccounts.Find(admin_id);
        }
        public string Insert(UserAccount entityUser)
        {
            db.UserAccounts.Add(entityUser);
            db.SaveChanges();
            return entityUser.UserName;
        }
        public string Update(UserAccount entityUser)
        {
            var user = FindId(entityUser.ID);
            if (user != null)
            {
                user.UserName = entityUser.UserName;
                if (!string.IsNullOrEmpty(entityUser.PassWord))
                {
                    user.PassWord = entityUser.PassWord;
                }
            }
            db.SaveChanges();
            return entityUser.UserName;
        }
        public bool Delete(System.Int32 id)
        {
            try
            {
                var user = db.UserAccounts.Find(id);
                db.UserAccounts.Remove(user);
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
