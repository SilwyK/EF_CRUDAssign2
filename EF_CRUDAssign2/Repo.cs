using Core.Entities;
using Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CRUDAssign2
{
    public class Repo : IRepo
    {
        private BloggingContext dataContext { get; set; }
        public Repo()
        {
            dataContext = new BloggingContext();
        }
        public void Create<T>(T entity) where T : BaseEntity
        {
            var dbSet = dataContext.Set<T>();
            entity.CreateDateTime = DateTime.Now;
            entity.UpdateDateTime = DateTime.Now;
            dbSet.Add(entity);
            dataContext.SaveChanges();

        }

        public void Delete<T>(int id) where T : BaseEntity
        {
            var dbSet = dataContext.Set<T>();
            var entity = dbSet.FirstOrDefault(x => x.UserId == id);
            if (entity != null)
            {
                entity.IsDeleted = true;
            }
            dataContext.SaveChanges();
        }

        public T Read<T>(int id) where T : BaseEntity
        {
            var dbSet = dataContext.Set<T>();
            var entity = dbSet.FirstOrDefault(x => x.UserId == id);
            if (entity != null)
            {
                return entity;
            }
            else
            {
                Console.WriteLine("Select a valid user id");
                return null;
            }


        }

        public void Update<T>(T entity) where T : BaseEntity
        {
            var dbSet = dataContext.Set<T>();
            var foundEntity = dbSet.FirstOrDefault(x => x.UserId == entity.UserId);
            if (foundEntity != null)
            {
                entity.UpdateDateTime = DateTime.Now;
                foundEntity = entity;
                dataContext.SaveChanges();
            }

        }
    }

}
