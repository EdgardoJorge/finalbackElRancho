using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using DbModel.ElRancho;
using IRepository;

namespace Repository
{
    public class CrudRepository<TEntity> : ICrudRepository<TEntity> where TEntity : class
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly ElRanchoDbContext _db;
        protected readonly DbSet<TEntity> dbSet;

        public CrudRepository(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, DbContextOptions<ElRanchoDbContext> options)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _db = new ElRanchoDbContext(options);
            this.dbSet = _db.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            dbSet.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            dbSet.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<int> Delete(object id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> DeleteMultipleItems(List<TEntity> lista)
        {
            dbSet.RemoveRange(lista);
            return await _db.SaveChangesAsync();
        }

        public async Task<List<TEntity>> InsertMultiple(List<TEntity> lista)
        {
            dbSet.AddRange(lista);
            await _db.SaveChangesAsync();
            return lista;
        }

        public async Task<List<TEntity>> UpdateMultiple(List<TEntity> lista)
        {
            dbSet.UpdateRange(lista);
            await _db.SaveChangesAsync();
            return lista;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
