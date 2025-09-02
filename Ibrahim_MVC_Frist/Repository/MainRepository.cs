﻿using Ibrahim_MVC_Frist.Data;
using Ibrahim_MVC_Frist.Models;
using Ibrahim_MVC_Frist.Repository.Base;

namespace Ibrahim_MVC_Frist.Repository
{
    public class MainRepository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public MainRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        public void Add(T entity)
        {

            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }


        public IEnumerable<T> FindAll()
        {
            return _context.Set<T>().ToList();
        }

        public T FindById(int id)
        {
            return _context.Set<T>().Find(id);
        
        }

        public IEnumerable<Category> FindAllCategory()
        {
            throw new NotImplementedException();
        }
    }
}
