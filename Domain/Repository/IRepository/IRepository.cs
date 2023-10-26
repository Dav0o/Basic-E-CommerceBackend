using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        //Commands
        public T Add(T request);


        //Queries
        public List<T> GetAll();
        public T GetById(string id);
    }
}
