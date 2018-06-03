using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcInternetShop.Models.Repositories
{
    public class ProductRepository : IDisposable
    {
        private MvcInternetShop.Models.DomainModels.MvcShopEntities db = null;

        public ProductRepository()
        {
            db = new DomainModels.MvcShopEntities();
        }

        public bool Add(MvcInternetShop.Models.DomainModels.Product entity, bool autoSave = true)
        {
            try
            {
                db.Products.Add(entity);
                if (autoSave)
                    return Convert.ToBoolean(db.SaveChanges());
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(MvcInternetShop.Models.DomainModels.Product entity, bool autoSave = true)
        {
            try
            {
                db.Products.Attach(entity);
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                if (autoSave)
                    return Convert.ToBoolean(db.SaveChanges());
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(MvcInternetShop.Models.DomainModels.Product entity, bool autoSave = true)
        {
            try
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                if (autoSave)
                    return Convert.ToBoolean(db.SaveChanges());
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id, bool autoSave = true)
        {
            try
            {
                var entity = db.Products.Find(id);
                db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                if (autoSave)
                    return Convert.ToBoolean(db.SaveChanges());
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public MvcInternetShop.Models.DomainModels.Product Find(int id)
        {
            try
            {
                return db.Products.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<MvcInternetShop.Models.DomainModels.Product> Where(System.Linq.Expressions.Expression<Func<MvcInternetShop.Models.DomainModels.Product, bool>> predicate)
        {
            try
            {
                return db.Products.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<MvcInternetShop.Models.DomainModels.Product> Select()
        {
            try
            {
                return db.Products.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<MvcInternetShop.Models.DomainModels.Product, TResult>> selector)
        {
            try
            {
                return db.Products.Select(selector);
            }
            catch
            {
                return null;
            }
        }

        public int GetLastIdentity()
        {
            try
            {
                if (db.Products.Any())
                    return db.Products.OrderByDescending(p => p.Id).First().Id;
                else
                    return 0;
            }
            catch
            {
                return -1;
            }
        }

        public int Save()
        {
            try
            {
                return db.SaveChanges();
            }
            catch
            {
                return -1;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.db != null)
                {
                    this.db.Dispose();
                    this.db = null;
                }
            }
        }

        ~ProductRepository()
        {
            Dispose(false);
        }
    }
}