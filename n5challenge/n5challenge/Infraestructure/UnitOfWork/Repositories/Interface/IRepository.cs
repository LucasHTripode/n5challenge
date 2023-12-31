﻿using n5challenge.Core.Entity;
using System.Linq.Expressions;
using System.Security.Principal;

namespace n5challenge.Infraestructure.UnitOfWork.Repositories.Interface
{
    public interface IRepository
    {
        Task<T?> GetById<T>(int id) where T : IEntity;
        IQueryable<T> FindQueryable<T>(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null) where T : IEntity;
        Task<List<T>> FindListAsync<T>(Expression<Func<T, bool>>? expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, CancellationToken cancellationToken = default) where T : class;
        Task<List<T>> FindAllAsync<T>() where T : IEntity;
        Task<bool> Exist<T>(Expression<Func<T, bool>> expression) where T : IEntity;
        T Add<T>(T entity) where T : IEntity;
        void Update<T>(T entity) where T : IEntity;
        void UpdateRange<T>(IEnumerable<T> entities) where T : IEntity;
        void Delete<T>(T entity) where T : IEntity;
    }
}
