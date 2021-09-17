using AudioStreaming.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Dal.Interfaces
{
   public interface IRepository
    {
        Task<TEntity> GetById<TEntity>(int id) where TEntity : BaseEntity;

        Task<List<TEntity>> GetAll<TEntity>() where TEntity : BaseEntity;
        Task<TEntity> GetByIdWithInclude<TEntity>(int id, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : BaseEntity;

        void Add<TEntity>(TEntity entity) where TEntity : BaseEntity;
        Task SaveChangesAsync();

        Task<TEntity> Delete<TEntity>(int id) where TEntity : BaseEntity;

    }
}
