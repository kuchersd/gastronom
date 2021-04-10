using gastronom.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gastronom.Services
{   // Coolest guide from guniuse: https://www.youtube.com/watch?v=7pkmqrrjAAQ&list=PLA8ZIAm2I03jSfo18F7Y65XusYzDusYu5&index=2
    public class GenericDataService<T> : IDataService<T> where T : ModelsIdentity
    {
        private readonly DbContextFactory _contextFactory;

        public GenericDataService(DbContextFactory contextFactory   )
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using(DatabaseContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdResult.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (DatabaseContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<T> Get(int id)
        {
            using (DatabaseContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);

                return entity;
            }
            
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (DatabaseContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> allEntities = await context.Set<T>().ToListAsync();

                return allEntities;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (DatabaseContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }
    }
}
