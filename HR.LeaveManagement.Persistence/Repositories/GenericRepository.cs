using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly LeaveManagementDbContext _dbContext;
        public GenericRepository(LeaveManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);    //add
            await _dbContext.SaveChangesAsync();  //savechanges 
            return entity;
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);  //نحوه حذف بر اساس مدل
            await _dbContext.SaveChangesAsync();  //برای حذف هم savechanges  را میزنیم
        }

        public async Task<bool> Exists(int id)
        {
            return (await Get(id)) != null; //اول پیدا میکند اگر پیدا بشه تال نیست  و حاصل محاسبه برگشت داده میشود

            //var findedEntity = await Get(id);
            //return findedEntity != null;

            //var findedEntity = await Get(id);
            //if (findedEntity == null) return false;
            //return true;
        }

        public async Task<T> Get(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);  //اول دی بی کانتکست رو ست میکنیم روی مدل مورد نظر و سپس فایند میکنیم 

        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
