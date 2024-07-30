﻿using Domain.Common;
using System.Linq.Expressions;

namespace Repository.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);
        Task EditAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllWithExpressionAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetFirstWithExpressionAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(int id);
    }
}
