﻿
using HotelManagementApplication.DAL;
using HotelManagementApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelManagementApplication.Repository
{
    public class HotelAppRepository<T> : IHotelAppRepository<T> where T : class
    {
        private readonly HotelDBContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public HotelAppRepository(HotelDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task<T> CreateAsync(T dbRecord)
        {
            _dbSet.Add(dbRecord);
            await _dbContext.SaveChangesAsync();
            return dbRecord;
        }
        public async Task<bool> DeleteAsync(T dbRecord)
        {
            _dbSet.Remove(dbRecord);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> filter, bool useNoTracking = false)
        {
            if (useNoTracking)
                return await _dbSet.AsNoTracking().Where(filter).FirstOrDefaultAsync();

            else
                return await _dbSet.Where(filter).FirstOrDefaultAsync();
        }
        public async Task<T> UpdateAsync(T dbRecord)
        {
           // _dbContext.Entry(dbRecord).State = EntityState.Modified;
           _dbContext.Update(dbRecord);
            await _dbContext.SaveChangesAsync();

            return dbRecord;
        }
    }
}
