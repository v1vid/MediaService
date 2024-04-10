using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Npgsql;

public abstract class RepositoryBase<TEntity, TModel> where TModel : class
{
    protected readonly DbContext _context;
    //private string connectionString = "Server=MediaService;Port=5432;Database=cms;User Id = postgres; Password=1111;";
    protected RepositoryBase(DbContext context)
    {
        _context = context;
    }

    protected abstract DbSet<TModel> DbSet { get; }

    public void Add(TEntity entity)
    {
        TModel model = MapFrom(entity);
        DbSet.Add(model);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        IEnumerable<TModel> models = entities.Select(MapFrom);
        DbSet.AddRange(models);
    }

    public void Update(TEntity entity)
    {
        TModel model = MapFrom(entity);
        _context.Entry(model).State = EntityState.Modified;
        UpdateModel(model, entity);
    }

    public void Remove(TEntity entity)
    {
        TModel model = MapFrom(entity);
        DbSet.Remove(model);
    }

    protected abstract TModel MapFrom(TEntity entity);

    protected abstract bool Equal(TEntity entity, TModel model);

    protected abstract void UpdateModel(TModel model, TEntity entity);

 
}