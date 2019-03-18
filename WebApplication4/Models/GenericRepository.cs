using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private Contexto db = null;
        private DbSet<T> table = null;
        // ProductContext context = new ProductContext();
        public GenericRepository()
        {
            this.db = new Contexto();
            table = db.Set<T>();
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IEnumerable<T> SelectAll()
        {
            return table.ToList();
        }

        public T SelectByID(object id)
        {
            return table.Find(id);
            // var result = (from r in context.Products where r.Id == Id select r).FirstOrDefault();
          //  return result;
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
            // context.Entry(p).State = System.Data.Entity.EntityState.Modified;
        }
    }
}