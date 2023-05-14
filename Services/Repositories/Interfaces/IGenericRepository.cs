﻿using Ecom_API.DTO.Entities;
using System.Linq.Expressions;
namespace Services.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        /// <summary>
        ///      Add a new entity to database
        /// </summary>
        /// <param name="entity"> New enitity</param>
        /// <returns>Number of row in database have been changed</returns>
        Task<int> CreateAsync(T entity);
        /// <summary>
        ///      Update a entity to database
        /// </summary>
        /// <param name="entity">Entity for updating</param>
        /// <returns>Number of row in database have been changed</returns>
        Task<int> UpdateAsync(T entity);
        Task<T> DeleteAsync(int id);
        /// <summary>
        ///     Update IsDeleted property to true for a object
        /// </summary>
        /// <param name="id">Object's id for soft delete</param>
        /// <returns>A object have soft deleted</returns>
        Task<T> DeleteSoftAsync(int id);
        Task<T> FindWithCondition(Expression<Func<T, bool>> predicate);
        Task<IList<T>> WhereAsync(Expression<Func<T, bool>> predicate, params string[] navigationProperties);
        Task<IEnumerable<T>> FindAllWithCondition(Expression<Func<T, bool>> predicate = null);
        Task<IEnumerable<T>> GetAllActiveAsync();
        Task<T> GetByIdActiveAsync(int id);
    }
}