
using APIAnime.Context;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace APIAnime.Repository;
public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly AnimeContext _context;

    public BaseRepository(AnimeContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<T>> GetAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public bool Create(T entity)
    {
        if (entity is null)
        {
            return false;
        }

        _context.Set<T>().Add(entity);
        _context.SaveChanges();
        return true;
    }

    public bool Put(T entity)
    {
        if(entity is null)
        {
            return false;
        }

        _context.Set<T>().Update(entity);
        _context.SaveChanges();
        return true;
    }
    public bool Delete(int id)
    {
        var findById = _context.Set<T>().Find(id);

        if(findById is null)
        {
            return false;
        }

        _context.Set<T>().Remove(findById);
        _context.SaveChanges();
        return true;

    }

    public T GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }
}

