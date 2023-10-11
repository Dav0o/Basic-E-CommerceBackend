using Domain.Data;
using Domain.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly MyDbContext _myDbContext;
        private readonly DbSet<T> _DbSet;
        public GenericRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
            _DbSet = _myDbContext.Set<T>();
        }

        //Commands
        public T Add(T entity)
        {
            _myDbContext.Add(entity);
            _myDbContext.SaveChanges();

            return entity;
        }
        //Queries

        public T GetById(int id)
        {
            return _DbSet.Find(id);
        }

        public List<T> GetAll()
        {
            return _DbSet.ToList();
        }
    }
}