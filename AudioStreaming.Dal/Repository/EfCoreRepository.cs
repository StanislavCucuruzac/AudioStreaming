using AudioStreaming.Dal.Interfaces;
using AudioStreaming.Domain;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Dal.Repository
{
   public class EfCoreRepository : IRepository
    {
        private readonly AudioStreamingDbContext _audioStreamingDbContext;
        private readonly IMapper _mapper;

        public EfCoreRepository(AudioStreamingDbContext audioStreamingDbContext, IMapper mapper)
        {
            _audioStreamingDbContext = audioStreamingDbContext;
            _mapper = mapper;
        }

        public async Task<List<TEntity>> GetAll<TEntity>() where TEntity : BaseEntity
        {
            return await _audioStreamingDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById<TEntity>(int id) where TEntity : BaseEntity
        {
            return await _audioStreamingDbContext.FindAsync<TEntity>(id);
        }

        public async Task<TEntity> GetByIdWithInclude<TEntity>(int id, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : BaseEntity
        {
            var query = IncludeProperties(includeProperties);
            return await query.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _audioStreamingDbContext.SaveChangesAsync();
        }

        public void Add<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            _audioStreamingDbContext
                .Set<TEntity>()
                .Add(entity);
        }

        public async Task<TEntity> Delete<TEntity>(int id) where TEntity : BaseEntity
        {
            var entity = await _audioStreamingDbContext.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                throw new Exception($"Object of type {typeof(TEntity)} with id { id } not found");
            }

            _audioStreamingDbContext.Set<TEntity>().Remove(entity);

            return entity;
        }
        private IQueryable<TEntity> IncludeProperties<TEntity>(params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : BaseEntity
        {
            IQueryable<TEntity> entities = _audioStreamingDbContext.Set<TEntity>();
            foreach (var includeProperty in includeProperties)
            {
                entities = entities.Include(includeProperty);
            }
            return entities;
        }

    }
}
