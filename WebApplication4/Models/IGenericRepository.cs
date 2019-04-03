using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> SelectAll();
        T SelectByID(object id);
        T ByID(int id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}