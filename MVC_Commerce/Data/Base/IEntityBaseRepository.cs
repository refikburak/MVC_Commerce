﻿using MVC_Commerce.Models;
using System.Linq.Expressions;

namespace MVC_Commerce.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T newEntity);
        Task DeleteAsync(int id);
    }
}
